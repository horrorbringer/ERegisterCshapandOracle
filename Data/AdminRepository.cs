using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace E_Registration.Data
{
    public class AdminRepository
    {
        public bool ValidateLogin(string username, string password)
        {
            var con = OracleDb.GetConnection();
            con.Open();

            var cmd = new OracleCommand("SELECT COUNT(*) FROM admins WHERE username = :username AND password = :password", con);
            cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
            cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }
    }
}
