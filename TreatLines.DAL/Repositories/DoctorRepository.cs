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
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(DbContext context) : base(context)
        {    }

        public async Task<Doctor> GetByIdAsync(string id)
        {
            return await context.Set<Doctor>()
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<Doctor> GetByEmailAsync(string email)
        {
            return await context.Set<Doctor>()
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.User.Email == email);
        }

        public IEnumerable<Doctor> GetDoctors(int hospitalId)
        {
            return context.Set<Doctor>()
                .Include(d => d.User)
                .Where(d => d.HospitalId == hospitalId)
                .Select(d => d)
                .AsNoTracking()
                .ToArray();
        }
    }
}
