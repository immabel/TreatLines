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
        public int? ScheduleId { get; set; }
        public IEnumerable<ScheduleInfoModel> Schedules { get; set; }
        public string Experience { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        public decimal Price { get; set; }
    }
}
