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
        IEnumerable<PatientsInfoDTO> GetDoctorPatientsByEmailAsync(string email);
        Task<DoctorInfoDTO> GetDoctorInfoAsync(string id);
        Task<DoctorInfoDTO> GetDoctorInfoByEmailAsync(string email);
        Task<ScheduleInfoDTO> GetScheduleByEmailAsync(string email);
        IEnumerable<DoctorInfoDTO> GetDoctorsByHospital(Hospital hospital);
        IEnumerable<string> GetDoctorsEmailsByHospitalId(int id);
        IEnumerable<DoctorInfoDTO> GetDoctorsByHospitalAdminId(string id);
        Task AddAppointment(AppointmentCreationDTO appointmentDto);
        Task AddSkinInfoToAppointment(SkinInfoDTO skinInfoDto);
        Task AddPrescriptionToAppointment(PrescriptionDTO prescriptionDto);
        IEnumerable<AppointmentFutureInfoDTO> GetFutureAppointmentsByDoctorEmail(string email);
        AppointmentDTO GetNearestAppointment(string doctorId, string patientId);
        IEnumerable<AppointmentInfoDTO> GetLastAppointmentsByPatientId(string id);
        Task UpdateDoctor(DoctorInfoDTO doctor);
        Task CancelAppointment(int id);
        Task UpsertPrescriptionByAppointmentId(PrescriptionDTO prescriptionDTO);
        IEnumerable<string> GetPatientsEmailsByDoctorId(string id);
        Task<IEnumerable<FreeDateTimesDTO>> GetFreeDateTimesByDoctorEmail(string email);
    }
}
