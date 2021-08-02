using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Doctor
{
    public class DoctorInfoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public int OnHoliday { get; set; }
        public int Blocked { get; set; }        
    }
}
