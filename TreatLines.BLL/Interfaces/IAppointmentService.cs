using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Appointment;
using TreatLines.BLL.DTOs.Prescription;

namespace TreatLines.BLL.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<PastAppointmentsPatientInfoDTO> GetPastAppointmentsByPatientEmail(string email);
        IEnumerable<AppointmentPatientFutureInfoDTO> GetFutureAppointmentsByPatientEmail(string email);
        PrescriptionInfoDTO GetLatestPrescriptionByPatientEmail(string email);
        Task UpsertPrescriptionByAppointmentIdAsync(PrescriptionDTO prescriptionDTO);
        Task AddAppointment(AppointmentCreationDTO appointmentDto);
        IEnumerable<AppointmentFutureInfoDTO> GetFutureAppointmentsByDoctorEmail(string email);
        AppointmentInfoDTO GetNearestAppointment(string doctorEmail, string patientEmail);
        IEnumerable<AppointmentInfoDTO> GetLastAppointmentsByPatientId(string id);
        Task CancelAppointmentAsync(int id);
    }
}
