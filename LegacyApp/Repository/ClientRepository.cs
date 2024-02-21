using LegacyApp.DataAccess;
using LegacyApp.GeneralFunctions;
using LegacyApp.Interface;
using LegacyApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LegacyApp.Repository
{
    public class ClientRepository : IClientRepository
    {
        private DataBase _db;
        public ClientRepository()
        {
            _db = new DataBase();
        }

        public Client GetById(int id)
        {
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@clientId", SqlDbType.Int) { Value = id },
                };

                List<Client> listClient = GeneralFunction.ConvertDataTableToList<Client>(_db.Get(sqlParameters, "uspGetClientById"));

                return listClient[0];
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}