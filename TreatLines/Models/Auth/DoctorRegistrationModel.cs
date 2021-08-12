using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreatLines.Models.Auth
{
    public class DoctorRegistrationModel : RegistrationModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Position { get; set; }
        public int? ScheduleId { get; set; }
        public IEnumerable<ScheduleInfoModel> Schedules { get; set; }
        public string Experience { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Education { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression("^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d$",
            ErrorMessage = "Date is invalid")]
        public string DateOfBirth { get; set; }
        [Range(0, 200000, ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }
    }
}
