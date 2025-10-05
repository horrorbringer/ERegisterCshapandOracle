using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace E_Registration.Data
{
    public class OracleDb
    {

        private static readonly string connStr =
            "User Id=vanny;Password=va183729;Data Source=localhost:1521/XEPDB1;";

        public static OracleConnection GetConnection()
        {
            return new OracleConnection(connStr);
        }
    }
}
