using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.PatientCreate
{
    public sealed class RequestToCreatePatientViewDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset DateOfRequestCreation { get; set; }
    }
}
