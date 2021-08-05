using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> GetByIdAsync(string id);
        Task<Patient> GetByEmailAsync(string email);
        Task<IEnumerable<Patient>> GetAllWithUserAsync();
    }
}
