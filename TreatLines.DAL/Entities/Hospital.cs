using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.DAL.Entities
{
    public class Hospital : BaseEntity
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool Blocked { get; set; }
        public DateTimeOffset RegisterDateTime { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<HospitalAdmin> HospitalAdmins { get; set; }
    }
}
