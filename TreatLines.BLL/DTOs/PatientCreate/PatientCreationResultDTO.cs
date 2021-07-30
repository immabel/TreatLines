using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.PatientCreate
{
    public class PatientCreationResultDTO
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
