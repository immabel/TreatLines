using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.Models.Tables
{
    public sealed class RequestInfoToCreateHospitalModel
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }        
        public string City { get; set; }        
        public string Country { get; set; }
        public string SubmitterFirstName { get; set; }        
        public string SubmitterLastName { get; set; }        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CreationDate { get; set; }
        public string DateOfRequestCreation { get; set; }
    }
}
