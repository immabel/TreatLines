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
        Task<DoctorProfileInfoDTO> GetDoctorInfoAsync(string id);
        Task<DoctorProfileInfoDTO> GetDoctorInfoByEmailAsync(string email);
        Task<ScheduleInfoDTO> GetScheduleByEmailAsync(string email);
        IEnumerable<string> GetDoctorsEmailsByHospitalId(int id);
        Task AddAppointment(AppointmentCreationDTO appointmentDto);
        IEnumerable<AppointmentFutureInfoDTO> GetFutureAppointmentsByDoctorEmail(string email);
        AppointmentDTO GetNearestAppointment(string doctorId, string patientEmail);
        IEnumerable<AppointmentInfoDTO> GetLastAppointmentsByPatientId(string id);
        Task UpdateDoctorAsync(DoctorProfileInfoDTO doctor);
        Task CancelAppointmentAsync(int id);
        Task<IEnumerable<FreeDateTimesDTO>> GetFreeDateTimesByDoctorEmailAsync(string email);
        Task ChangeDoctorScheduleAsync(ScheduleInfoDoctorDTO infoDTO);
    }
}
