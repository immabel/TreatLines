using System.Collections.Generic;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;

namespace TreatLines.BLL.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<HospitalInfoDTO>> GetHospitals();
        Task<HospitalInfoDTO> GetHospitalInfoById(int id);
        Task<bool> DeleteHospitalByIdAsync(int hospitalId);
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(int hospitalId);
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(string hospitalAdminId);
        Task BlockUser(string email);
        int GetHospitalIdByHospitalAdminId(string id);
        Task DeleteUser(string email);
        int GetDoctorsCountById(int hospitalId);
    }
}
