using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Registration.Models;
using Oracle.ManagedDataAccess.Client;

namespace E_Registration.Data
{
    public class EnrollmentRepository
    {
        public static DataTable GetAllEnrolledStudents()
        {
            DataTable dt = new DataTable();

            using (var con = OracleDb.GetConnection())
            {
                con.Open();
                using (var cmd = new OracleCommand("PKG_ENROLLMENT_MGMT.GET_ENROLLMENTS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public static DataTable GetAllStudents()
        {
            using (var con = OracleDb.GetConnection())
            using (var cmd = new OracleCommand("SELECT id, full_name FROM students ORDER BY full_name", con))
            {
                var adapter = new OracleDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static DataTable GetAllPrograms()
        {
            using (var con = OracleDb.GetConnection())
            using (var cmd = new OracleCommand("SELECT id, name FROM programs ORDER BY name", con))
            {
                var adapter = new OracleDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
        public static int Add(Enrollment enrollment)
        {
            using (var con = OracleDb.GetConnection())
            using (var cmd = new OracleCommand("PKG_ENROLLMENT_MGMT.ADD_ENROLLMENT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_student_id", OracleDbType.Int32).Value = enrollment.StudentId;
                cmd.Parameters.Add("p_program_id", OracleDbType.Int32).Value = enrollment.ProgramId;
                cmd.Parameters.Add("p_enroll_date", OracleDbType.Date).Value = enrollment.EnrollmentDate;
                cmd.Parameters.Add("p_enrollment_id", OracleDbType.Int32, ParameterDirection.Output);

                con.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["p_enrollment_id"].Value.ToString());
            }
        }

        public static void Update(Enrollment enrollment)
        {
            using (var con = OracleDb.GetConnection())
            using (var cmd = new OracleCommand("PKG_ENROLLMENT_MGMT.UPDATE_ENROLLMENT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = enrollment.Id;
                cmd.Parameters.Add("p_student_id", OracleDbType.Int32).Value = enrollment.StudentId;
                cmd.Parameters.Add("p_program_id", OracleDbType.Int32).Value = enrollment.ProgramId;
                cmd.Parameters.Add("p_enroll_date", OracleDbType.Date).Value = enrollment.EnrollmentDate;

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var con = OracleDb.GetConnection())
            using (var cmd = new OracleCommand("PKG_ENROLLMENT_MGMT.DELETE_ENROLLMENT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = id;

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
