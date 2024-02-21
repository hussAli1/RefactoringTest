﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.DataAccess
{
    public interface IDataBase
    {
        DataTable Get(List<SqlParameter> sqlParameters, string sqlQuery);
        int ExecuteQuery(List<SqlParameter> sqlParameters, string sqlQuery, string nameReturnValue);
    }
}