using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models.Requests
{
    public class RequestToCreatePatientModel
    {
        public int HospitalId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Email is invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$",
            ErrorMessage = "Phone number is invalid. Example: +(38)000-000-00-00")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string BloodType { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Sex { get; set; }
    }
}
