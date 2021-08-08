using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.Models.Tables
{
    public sealed class RequestInfoToCreatePatientModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }   
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfRequestCreation { get; set; }
    }
}
