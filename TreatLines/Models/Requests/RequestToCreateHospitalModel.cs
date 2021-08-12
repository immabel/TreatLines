using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models.Requests
{
    public class RequestToCreateHospitalModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string HospitalName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string SubmitterFirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string SubmitterLastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Email is invalid.")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$",
            ErrorMessage = "Phone is invalid. Example: +(38)000-000-00-00")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression("^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d$",
            ErrorMessage = "Date is invalid")]
        public string HospitalCreationDate { get; set; }
    }
}
