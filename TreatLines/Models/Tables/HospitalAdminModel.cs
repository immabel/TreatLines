using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.Models.Tables
{
    public class HospitalAdminModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Blocked { get; set; }
        public string PhoneNumber { get; set; }
    }
}
