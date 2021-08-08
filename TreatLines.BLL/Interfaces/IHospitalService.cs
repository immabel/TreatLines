using System.Collections.Generic;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.DAL.Entities;

namespace TreatLines.BLL.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<HospitalInfoDTO>> GetHospitalsAsync();
        Task<HospitalInfoDTO> GetHospitalInfoByIdAsync(int id);
        Task BlockHospitalByIdAsync(int hospitalId);
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(int hospitalId);
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsByHospAdminId(string hospitalAdminId);
        Task BlockUserAsync(string id);
        int GetDoctorsCountById(int hospitalId);
        Task<HospitalAdminInfoDTO> GetHospitalAdminProfileInfoAsync(string id);
        IEnumerable<DoctorInfoDTO> GetDoctorsByHospital(Hospital hospital);
        IEnumerable<DoctorInfoDTO> GetDoctorsByHospitalAdminId(string id);
        IEnumerable<PatientInfoDTO> GetPatientsByHospitalAdminId(string id);
    }
}
