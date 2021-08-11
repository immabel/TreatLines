using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Interfaces
{
    public interface IDoctorPatientRepository : IRepository<DoctorPatient>
    {
        Task<Patient> GetPatientByEmailAsync(string email);
        Task<Doctor> GetDoctorByEmailAsync(string email);
        IEnumerable<Patient> GetDoctorPatientsById(string doctorId);
        IEnumerable<Doctor> GetPatientDoctors(string patientId);
        IEnumerable<DoctorPatient> GetAppointmentsByDoctorEmail(string email);
        IEnumerable<DoctorPatient> GetAppointmentsByPatientId(string id);
        IEnumerable<DoctorPatient> GetAppointmentsByPatientEmail(string email);
        IEnumerable<DoctorPatient> GetAppointmentsInfoForDoctorByPatientId(string id);
        IEnumerable<Appointment> GetAppointments(string docId, string patId);
        IEnumerable<Patient> GetDoctorPatientsByEmail(string email);
    }
}
