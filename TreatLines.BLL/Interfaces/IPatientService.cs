using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Appointment;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.DTOs.Prescription;

namespace TreatLines.BLL.Interfaces
{
    public interface IPatientService
    {
        //IEnumerable<DoctorInfoDTO> GetPatientDoctorsAsync(string email);
        Task<PatientInfoDTO> GetPatientInfoAsync(string id);
        //Task<PatientInfoDTO> GetPatientInfoByEmailAsync(string email);
        IEnumerable<PastAppointmentsPatientInfoDTO> GetPastAppointmentsByPatientId(string id);
        IEnumerable<AppointmentsPatientFutureInfoDTO> GetFutureAppointmentsByPatientId(string id);
        //IEnumerable<PrescriptionInfoDTO> GetPrescriptionByPatientId(string id);
        //IEnumerable<PrescriptionInfoDTO> GetPrescriptionByPatientEmail(string email);
        IEnumerable<PatientsInfoDTO> GetPatientsByHospitalAdminId(string id);
        Task UpdatePatient(PatientInfoDTO patient);
    }
}
