using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.HospitalCreate
{
    public class HospitalCreationResultDTO
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
    }
}
