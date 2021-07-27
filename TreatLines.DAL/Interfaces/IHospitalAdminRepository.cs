using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Interfaces
{
    public interface IHospitalAdminRepository : IRepository<HospitalAdmin>
    {
        Task<IEnumerable<HospitalAdmin>> GetAllHospitalAdminsAsync();
        Hospital GetHospitalByHospitalAdminId(string id);
    }
}
