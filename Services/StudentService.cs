using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Registration.Data;
using E_Registration.Models;

namespace E_Registration.Services
{
    public class StudentService
    {
        public DataTable GetAllStudents() => StudentRepository.GetAllStudents();
        public void AddStudent(Student s) => StudentRepository.AddStudent(s);
        public void UpdateStudent(Student s) => StudentRepository.UpdateStudent(s);
        public void DeleteStudent(int id) => StudentRepository.DeleteStudent(id);
        public void RegisterAndEnroll(Student s, int programId) => StudentRepository.RegisterAndEnroll(s, programId);
    }
}
