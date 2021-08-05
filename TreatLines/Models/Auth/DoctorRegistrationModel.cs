using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreatLines.Models.Auth
{
    public class DoctorRegistrationModel : RegistrationModel
    {
        [Required]
        public string Position { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string WorkDays { get; set; }
    }
}
