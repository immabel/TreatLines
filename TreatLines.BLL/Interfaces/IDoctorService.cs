using System.Collections.Generic;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Appointment;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.DTOs.Prescription;
using TreatLines.BLL.DTOs.Schedule;
using TreatLines.DAL.Entities;

namespace TreatLines.BLL.Interfaces
{
    public interface IDoctorService
    {
        IEnumerable<PatientInfoDTO> GetDoctorPatientsByEmail(string email);
        IEnumerable<string> GetPatientsEmailsByDoctorEmail(string email);
        Task<DoctorProfileInfoDTO> GetDoctorInfoAsync(string id);
        Task<DoctorProfileInfoDTO> GetDoctorInfoByEmailAsync(string email);
        Task<ScheduleInfoDTO> GetScheduleByEmailAsync(string email);
        IEnumerable<string> GetDoctorsEmailsByHospitalId(int id);
        Task UpdateDoctorAsync(DoctorProfileInfoDTO doctor);
        Task<IEnumerable<FreeDateTimesDTO>> GetFreeDateTimesByDoctorEmailAsync(string email);
        Task ChangeDoctorScheduleAsync(ScheduleInfoDoctorDTO infoDTO);
    }
}
