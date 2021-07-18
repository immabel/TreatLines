using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.DAL.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTimeOffset DateTimeAppointment { get; set; }
        public int? PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
