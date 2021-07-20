using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<Doctor> GetByIdAsync(string id);
        Task<Doctor> GetByEmailAsync(string email);
        IEnumerable<Doctor> GetDoctors(int hospitalId);
    }
}
