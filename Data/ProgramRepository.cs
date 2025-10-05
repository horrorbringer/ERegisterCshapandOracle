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
    public class ProgramRepository
    {
        public static DataTable GetAllPrograms()
        {
            DataTable dt = new DataTable();
            using (var con = OracleDb.GetConnection())
            {
                con.Open();
                using (var cmd = new OracleCommand("pkg_student_enroll.get_programs", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var refCursor = new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add(refCursor);

                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }
        public static void AddProgram(ProgramModel program)
        {
            using (var conn = OracleDb.GetConnection())
            {
                conn.Open();
                var cmd = new OracleCommand("pkg_student_enroll.add_program", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("p_name", program.Name);
                cmd.Parameters.Add("p_description", program.Description);
                cmd.Parameters.Add("p_duration", program.Duration);
                cmd.Parameters.Add("p_program_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateProgram(ProgramModel program)
        {
            using (var conn = OracleDb.GetConnection())
            {
                conn.Open();
                var cmd = new OracleCommand("pkg_student_enroll.update_program", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("p_program_id", program.Id);
                cmd.Parameters.Add("p_name", program.Name);
                cmd.Parameters.Add("p_description", program.Description);
                cmd.Parameters.Add("p_duration", program.Duration);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteProgram(int programId)
        {
            using (var conn = OracleDb.GetConnection())
            {
                conn.Open();
                var cmd = new OracleCommand("pkg_student_enroll.delete_program", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("p_program_id", programId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
