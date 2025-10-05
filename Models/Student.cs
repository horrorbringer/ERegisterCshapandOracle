using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Registration.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
