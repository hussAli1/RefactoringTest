using LegacyApp.Services;

namespace LegacyApp.Tests
{
    internal class UserCreditServiceMocked : IUserCreditService
    {
        public int GetCreditLimit(string firstname, string surname, DateTime dateOfBirth)
        {
            return 50;
        }
    }
}