using System.Collections.Generic;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;

namespace TreatLines.BLL.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<HospitalInfoDTO>> GetHospitals();
        Task<bool> DeleteHospitalByIdAsync(int hospitalId);
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdmins();
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(string id);
        Task BlockUser(string email);
        int GetHospitalIdByHospitalAdminId(string id);
        Task DeleteUser(string email);
    }
}
