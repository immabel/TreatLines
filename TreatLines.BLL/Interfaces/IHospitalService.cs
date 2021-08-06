using System.Collections.Generic;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;
using TreatLines.DAL.Entities;

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
        Hospital GetHospitalByHospitalAdminId(string id);
        Task DeleteUserAsync(string email);
        int GetDoctorsCountById(int hospitalId);
        Task<HospitalAdminInfoDTO> GetHospitalAdminProfileInfoAsync(string id);
    }
}
