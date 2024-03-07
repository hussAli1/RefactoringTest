using LegacyApp.Interface;
using LegacyApp.Services;

namespace LegacyApp.Tests
{
    internal class UserServiceTests
    {
        private IClientRepository _clientRepositoryMocked = new ClientRepositoryMocked();
        private IUserCreditService _userCreditServiceMocked = new UserCreditServiceMocked();


        public bool TestIfUserFirstNameIsEmptyThenAddUserShouldReturnFalse()
        {
            UserService sut = new UserService(_clientRepositoryMocked, _userCreditServiceMocked);
            if (sut.AddUser("", "aa", "hussain1@gmail.com", DateTime.Now, 1) == false)
            {
                return true;
            }
            return false;
        }

        public bool TestIfUserCheckEmail()
        {
            UserService sut = new UserService(_clientRepositoryMocked, _userCreditServiceMocked);
            if (sut.AddUser("ali2", "ali2", "hussain2@gmailcom", DateTime.Now, 1) == false)
                return true;

            return false;
        }

        public bool TestIfUserCheckAge()
        {
            UserService sut = new UserService(_clientRepositoryMocked, _userCreditServiceMocked);
            if (sut.AddUser("ali3", "ali3", "hussa@ingmail.com", new DateTime(2010, 1, 1), 1) == false)
                return true;

            return false;
        }

        public bool CheckClientById()
        {
            UserService sut = new UserService(_clientRepositoryMocked, _userCreditServiceMocked);
            if (sut.AddUser("ali4", "ali4", "hussa@ingmailcom", new DateTime(2000, 1, 1), 2) == false)
                return true;

            return false;
        }
    }
}