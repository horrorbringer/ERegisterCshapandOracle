using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Registration.Services;
using E_Registration.Models;
using Oracle.ManagedDataAccess.Client;

namespace E_Registration.Data
{
    public class StudentRepository
    {
        public static DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();
            using (var con = OracleDb.GetConnection())
            {
                con.Open();
                using (var cmd = new OracleCommand("PKG_STUDENT_MGMT.GET_ALL_STUDENTS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("RETURN_VALUE", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public static void RegisterAndEnroll(Student student, int programId)
        {
            using (var conn = OracleDb.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand("pkg_student_enroll.register_and_enroll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_full_name", OracleDbType.Varchar2).Value = student.FullName;
                    cmd.Parameters.Add("p_dob", OracleDbType.Date).Value = student.DOB;
                    cmd.Parameters.Add("p_gender", OracleDbType.Varchar2).Value = student.Gender;
                    cmd.Parameters.Add("p_phone", OracleDbType.Varchar2).Value = student.Phone;
                    cmd.Parameters.Add("p_address", OracleDbType.Varchar2).Value = student.Address;
                    cmd.Parameters.Add("p_program_id", OracleDbType.Int32).Value = programId;
                    cmd.Parameters.Add("p_enrollment_id", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //return Convert.ToInt32(cmd.Parameters["p_enrollment_id"].Value.ToString());
                }
            }
        }
        public static void AddStudent(Student s)
        {
            using (var con = OracleDb.GetConnection())
            {
                con.Open();
                using (var cmd = new OracleCommand("PKG_STUDENT_MGMT.ADD_STUDENT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_full_name", OracleDbType.Varchar2).Value = s.FullName;
                    cmd.Parameters.Add("p_dob", OracleDbType.Date).Value = s.DOB;
                    cmd.Parameters.Add("p_gender", OracleDbType.Varchar2).Value = s.Gender;
                    cmd.Parameters.Add("p_phone", OracleDbType.Varchar2).Value = s.Phone;
                    cmd.Parameters.Add("p_address", OracleDbType.Varchar2).Value = s.Address;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateStudent(Student s)
        {
            using (var con = OracleDb.GetConnection())
            {
                con.Open();
                using (var cmd = new OracleCommand("PKG_STUDENT_MGMT.UPDATE_STUDENT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = s.Id;
                    cmd.Parameters.Add("p_full_name", OracleDbType.Varchar2).Value = s.FullName;
                    cmd.Parameters.Add("p_dob", OracleDbType.Date).Value = s.DOB;
                    cmd.Parameters.Add("p_gender", OracleDbType.Varchar2).Value = s.Gender;
                    cmd.Parameters.Add("p_phone", OracleDbType.Varchar2).Value = s.Phone;
                    cmd.Parameters.Add("p_address", OracleDbType.Varchar2).Value = s.Address;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteStudent(int id)
        {
            using (var con = OracleDb.GetConnection())
            {
                con.Open();
                using (var cmd = new OracleCommand("PKG_STUDENT_MGMT.DELETE_STUDENT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
