using System.Collections.Generic;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.DTOs.Schedule;
using TreatLines.DAL.Entities;

namespace TreatLines.BLL.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<HospitalInfoDTO>> GetHospitalsAsync();
        Task<HospitalInfoDTO> GetHospitalInfoByIdAsync(int id);
        Task BlockHospitalByIdAsync(int hospitalId);
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(int hospitalId);
        IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsByHospAdmin(string email);
        Task BlockUserAsync(string id);
        int GetDoctorsCountById(int hospitalId);
        Task<HospitalAdminInfoDTO> GetHospitalAdminProfileInfoAsync(string email);
        IEnumerable<DoctorInfoDTO> GetDoctorsByHospital(Hospital hospital);
        IEnumerable<DoctorInfoDTO> GetDoctorsByHospitalAdmin(string email);
        Task<IEnumerable<DoctorInfoDTO>> GetDoctorsByPatientEmailAsync(string email);
        IEnumerable<string> GetDoctorsEmailsByPatientEmail(string email);
        IEnumerable<PatientInfoDTO> GetPatientsByHospitalAdmin(string email);
        Task UpdateHospitalAdminInfoAsync(HospitalAdminInfoDTO adminDTO);
        int GetHospitalIdByHospAdmin(string email);
        //IEnumerable<ScheduleInfoDTO> GetSchedulesByHospAdmin(string email);
    }
}
