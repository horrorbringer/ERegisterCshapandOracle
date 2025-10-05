using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Registration.Data;
using E_Registration.Models;
using Oracle.ManagedDataAccess.Client;

namespace E_Registration.Services
{
    public class EnrollmentService
    {
        public DataTable GetAllEnrolledStudents() => EnrollmentRepository.GetAllEnrolledStudents();
        public DataTable GetStudents() => EnrollmentRepository.GetAllStudents();
        public DataTable GetPrograms() => EnrollmentRepository.GetAllPrograms();

        public void SaveEnrollment(Enrollment enrollment)
        {
            try
            {
                if (enrollment.Id == 0)
                    EnrollmentRepository.Add(enrollment); // calls ADD_ENROLLMENT
                else
                    EnrollmentRepository.Update(enrollment);
            }
            catch (OracleException ex) when (ex.Number == 20001)
            {
                // Custom message from RAISE_APPLICATION_ERROR
                MessageBox.Show(ex.Message, "Duplicate Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DeleteEnrollment(int id)
        {
            EnrollmentRepository.Delete(id);
        }

    }
}
