using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models.Requests
{
    public class RequestToCreateHospitalModel
    {
        [Required]
        public string HospitalName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string SubmitterFirstName { get; set; }
        [Required]
        public string SubmitterLastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        public DateTimeOffset HospitalCreationDate { get; set; }
    }
}
