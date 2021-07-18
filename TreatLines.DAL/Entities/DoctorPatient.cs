using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.DAL.Entities
{
    public class DoctorPatient : BaseEntity
    {
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
