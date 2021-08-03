using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Interfaces
{
    public interface IDoctorPatientRepository : IRepository<DoctorPatient>
    {
        IEnumerable<Patient> GetDoctorPatientsById(string doctorId);
        IEnumerable<Doctor> GetPatientDoctors(string patientId);
        IEnumerable<DoctorPatient> GetAppointmentsByDoctorEmail(string email);
        IEnumerable<DoctorPatient> GetAppointmentsByPatientId(string id);
        IEnumerable<DoctorPatient> GetAppointmentsInfoForDoctorByPatientId(string id);
        IEnumerable<Appointment> GetAppointments(string docId, string patId);
        IEnumerable<Patient> GetDoctorPatientsByEmail(string email);
    }
}
