﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using airoport;
using MySql.Data.MySqlClient;


namespace airoport
{
    internal class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "courier_deliveryy";
            string user = "root";
            string password = "76346347643786";

            return DBMySQLUtils.GetDBConnection(host, port, database, user, password);
        }

    }
}

