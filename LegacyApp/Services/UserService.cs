using LegacyApp.DataAccess;
using LegacyApp.Enums;
using LegacyApp.Interface;
using LegacyApp.Model;
using LegacyApp.Repository;
using System;

namespace LegacyApp.Services
{
    public class UserService
    {
        private Client GetClientById(int clientId) 
            => new ClientRepository().GetById(clientId);
        
        private bool CheckUserAge(DateTime dateOfBirth, int ageLimit)
        {
            var dateTimeNow = DateTime.Now;
            int age = dateTimeNow.Year - dateOfBirth.Year;
            if (dateTimeNow < dateOfBirth.AddYears(age)) age--;

            return age >= ageLimit;
        }

        private void SetUserCreditLimit(Client client, User user)
        {
            switch (client.Name)
            {
                case nameof(CheckClientName.VeryImportantClient):
                    user.HasCreditLimit = false;
                    break;

                case nameof(CheckClientName.ImportantClient):
                default:
                    user.HasCreditLimit = true;
                    using (var userCreditService = new UserCreditServiceClient())
                    {
                        var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                        if (client.Name == nameof(CheckClientName.ImportantClient))
                             creditLimit *= 2;
                        
                        user.CreditLimit = creditLimit;
                    }
                    break;
            }
        }
        
        private bool CheckEmail(string email) 
            => email.Contains("@") && !email.Contains(".");
        
        public bool AddUser(string firstName, string surName, string email, DateTime dateOfBirth, int clientId)
        {
            try
            {
                if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surName))
                    return false;


                if (!CheckEmail(email)) return false;

                if (!CheckUserAge(dateOfBirth, (int)Age.Limit)) return false;

                var client = GetClientById(clientId);

                var user = new User
                {
                    Client = client,
                    DateOfBirth = dateOfBirth,
                    EmailAddress = email,
                    Firstname = surName,
                    Surname = surName
                };

                SetUserCreditLimit(client, user);

                if(user.HasCreditLimit && user.CreditLimit < (int)Credit.Limit) return false;

                UserRepository.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}