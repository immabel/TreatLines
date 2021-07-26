using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.DAL.Entities
{
    public class Appointment : BaseEntity
    {
        public int Price { get; set; }
        public bool Canceled { get; set; }
        public DateTimeOffset DateTimeAppointment { get; set; }
        public int? PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
