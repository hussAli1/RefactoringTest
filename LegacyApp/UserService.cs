using LegacyApp.DataAccess;
using LegacyApp.Interface;
using LegacyApp.Model;
using LegacyApp.Repository;
using LegacyApp.Services;
using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;

        //solid principle #5
        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
        }
        public UserService() : this(new ClientRepository(), new UserCreditServiceClient())
        {

        }
        private bool CheckUserAge(DateTime dateOfBirth, int ageLimit)
        {
            var dateTimeNow = DateTime.Now;
            int age = dateTimeNow.Year - dateOfBirth.Year;
            if (dateTimeNow < dateOfBirth.AddYears(age)) age--;

            return age >= ageLimit;
        }

        private bool CheckEmail(string email)
            => email.Contains("@") && !email.Contains(".");

        public bool AddUser(string firstName, string surName, string email, DateTime dateOfBirth, int clientId)
        {
            try
            {
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surName))
                    return false;

                if (CheckEmail(email)) 
                    return false;

                if (!CheckUserAge(dateOfBirth, (int)Age.Limit)) 
                    return false;

                var client = _clientRepository.GetById(clientId);


                var user = new User
                {
                    Client = client,
                    DateOfBirth = dateOfBirth,
                    EmailAddress = email,
                    Firstname = surName,
                    Surname = surName
                };

                switch (client.Name)
                {
                    case nameof(CheckClientName.VeryImportantClient):
                        user.HasCreditLimit = false;
                        break;

                    case nameof(CheckClientName.ImportantClient):
                    default:

                        user.HasCreditLimit = true;
                        var creditLimit = _userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                        if (client.Name == nameof(CheckClientName.ImportantClient))
                            creditLimit *= 2;
                        user.CreditLimit = creditLimit;

                        break;
                }

                if (user.HasCreditLimit && user.CreditLimit < (int)Credit.Limit) 
                    return false;

                //UserRepository.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }


    }
}