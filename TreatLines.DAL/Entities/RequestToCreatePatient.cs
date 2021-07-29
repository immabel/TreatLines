using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.DAL.Entities
{
    public class RequestToCreatePatient
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DateOfRequestCreation { get; set; }
    }
}
