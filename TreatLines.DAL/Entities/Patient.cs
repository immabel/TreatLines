using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.DAL.Entities
{
    public class Patient
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string BloodType { get; set; }
        public string Sex { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        //public double HospitalRating { get; set; }
        public double Discount { get; set; }
        public int HospitalId { get; set; }
        public List<DoctorPatient> PatientDoctors { get; set; }
    }
}
