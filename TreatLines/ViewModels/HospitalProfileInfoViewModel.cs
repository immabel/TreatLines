using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.Models;
using TreatLines.Models.ProfileInfo;

namespace TreatLines.ViewModels
{
    public class HospitalProfileInfoViewModel
    {
        //public HospitalProfileInfoModel HospitalProfileInfo { get; set; }
        public HospitalInfoDTO HospitalProfileInfo { get; set; }
        public int DoctorsCount { get; set; }
        public IEnumerable<HospitalAdminContactInfoModel> HospitalAdmins { get; set; }
    }
}
