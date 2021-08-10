using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreatLines.Models.Auth
{
    public class PatientRegistrationModel : RegistrationModel
    {
        [Required]
        public string BloodType { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
    }
}
