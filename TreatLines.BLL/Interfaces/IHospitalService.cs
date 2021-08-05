using System.Collections.Generic;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;

namespace TreatLines.BLL.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<HospitalInfoDTO>> GetHospitalsAsync();
        Task<HospitalInfoDTO> GetHospitalInfoByIdAsync(int id);
        Task<bool> DeleteHospitalByIdAsync(int hospitalId);
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(int hospitalId);
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(string hospitalAdminId);
        Task BlockUserAsync(string id);
        int GetHospitalIdByHospitalAdminId(string id);
        Task DeleteUserAsync(string email);
        int GetDoctorsCountById(int hospitalId);
    }
}
