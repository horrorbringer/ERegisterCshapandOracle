using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Registration.Data;

namespace E_Registration.Services
{
    public class AdminService
    {
        private readonly AdminRepository _repo = new AdminRepository();

        public bool Login(string username, string password)
        {
            return _repo.ValidateLogin(username, password);
        }
    }
}
