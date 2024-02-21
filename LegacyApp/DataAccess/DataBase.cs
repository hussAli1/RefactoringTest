using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.DataAccess
{
    public class DataBase : IDataBase
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["appDatabase"].ConnectionString;
        static SqlConnection _connection = new SqlConnection(_connectionString);
        public static SqlCommand sqlCommand;
        public static void Open()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        public static void Close()
        {

            if (_connection.State == ConnectionState.Open)
                _connection.Close();

        }
        public int ExecuteQuery(List<SqlParameter> sqlParameters, string sqlQuery, string nameReturnValue)
        {
            throw new NotImplementedException();
        }

        public DataTable Get(List<SqlParameter> sqlParameters, string sqlQuery)
        {
            try
            {
                DataTable dataTable = new DataTable();
                sqlCommand = new SqlCommand(sqlQuery, _connection);

                if (sqlParameters != null)
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(sqlParameters.ToArray());
                }

                Open();
                dataTable.Load(sqlCommand.ExecuteReader());
                Close();

                return dataTable;

            }            
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
