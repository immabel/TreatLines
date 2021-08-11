using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models.Appointment
{
    public class PrescriptionModel
    {
        public int Id { get; set; }
        public string DoctorEmail {get; set;}
        public string Position {get; set;}
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
