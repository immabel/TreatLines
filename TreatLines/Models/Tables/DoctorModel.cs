using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models.Tables
{
    public class DoctorModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string RegistrationDate { get; set; }
        public int OnHoliday { get; set; }
        public int Blocked { get; set; }
    }
}
