using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;

namespace TreatLines.DAL.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(
            DbContext context) : base(context)
        {  }
        public async Task<Patient> GetByIdAsync(string id)
        {
            return await context.Set<Patient>()
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<Patient> GetByEmailAsync(string email)
        {
            return await context.Set<Patient>()
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.User.Email == email);
        }

        public async Task<IEnumerable<Patient>> GetAllWithUserAsync()
        {
            return await context.Set<Patient>()
                .Include(u => u.User)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
