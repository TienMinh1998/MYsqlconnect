using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ConnectoMySQLUsingCShap
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection(string server)
        {
            string host = "192.168.1.195";
            int port = 3306;
            string database = server;
            string username = "TienMinh1999";
            string password = "1234561";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
