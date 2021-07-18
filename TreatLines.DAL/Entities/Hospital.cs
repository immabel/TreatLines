using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.DAL.Entities
{
    public class Hospital : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<HospitalAdmin> HospitalAdmins { get; set; }
    }
}
