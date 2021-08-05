using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TreatLines.DAL.Entities
{
    public class Doctor
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public decimal Price { get; set; }
        public string Position { get; set; }
        public bool OnHoliday { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public int? ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public List<DoctorPatient> DoctorPatients { get; set; }
    }
}
