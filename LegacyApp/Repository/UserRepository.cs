using LegacyApp.DataAccess;
using LegacyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.Repository
{
    public static class UserRepository
    {
        public static void Add(User user) 
        {
            UserDataAccess.AddUser(user);
        }
    }
}
