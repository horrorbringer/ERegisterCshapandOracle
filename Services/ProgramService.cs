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
    public class ProgramService
    {

        public DataTable GetAllPrograms()
        {
            return ProgramRepository.GetAllPrograms();
        }
        public void AddProgram(ProgramModel program)
        {
            if (string.IsNullOrWhiteSpace(program.Name))
                throw new Exception("Program name cannot be empty.");

            ProgramRepository.AddProgram(program);
        }

        public void UpdateProgram(ProgramModel program)
        {
            if (program.Id <= 0)
                throw new Exception("Invalid program ID.");

            ProgramRepository.UpdateProgram(program);
        }

        public void DeleteProgram(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid program ID.");

            ProgramRepository.DeleteProgram(id);
        }
    }
}
