﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkNatural.Model
{
    public class SqliteDbConnection
    {
        public SqlConnection Sql()
        {
            return new SqlConnection("server=sharedbi.database.windows.net;database=WinkNaturalsReporting;uid=WinkNaturals_exigoweb;pwd=d6jTpYX7Hr2JREUuzqZ5aeF8;pooling=false;Encrypt=True;TrustServerCertificate=True;");
        }
        public SqlConnection Sql(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
