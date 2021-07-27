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
    public class HospitalAdminRepository : Repository<HospitalAdmin>, IHospitalAdminRepository
    {
        public HospitalAdminRepository(DbContext context) : base(context)
        { }

        public async Task<IEnumerable<HospitalAdmin>> GetAllHospitalAdminsAsync()
        {
            return await context.Set<HospitalAdmin>()
                .Include(dp => dp.User)
                .Include(dp => dp.Hospital)
                .AsNoTracking()
                .ToListAsync();
        }

        public Hospital GetHospitalByHospitalAdminId(string id)
        {
            return context.Set<HospitalAdmin>()
                .Where(ha => ha.UserId.Equals(id))
                .Select(h => h.Hospital)
                .FirstOrDefault();
        }
    }
    
}
