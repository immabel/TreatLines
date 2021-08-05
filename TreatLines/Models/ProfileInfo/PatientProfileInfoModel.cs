using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models.ProfileInfo
{
    public class PatientProfileInfoModel : HospitalAdminProfileInfoModel
    {
        public string BloodType { get; set; }
        public string Sex { get; set; }
        public double Discount { get; set; }
    }
}
