using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.BLL.DTOs.Admin;

namespace TreatLines.BLL.DTOs.HospitalAdmin
{
    public class HospitalAdminInfoDTO : AdminProfileInfoDTO
    {
        public string Id { get; set; }
        public string HospitalName { get; set; }
        public int HospitalId { get; set; }
        public int Blocked { get; set; }
        public string RegistrationDate { get; set; }
    }
}
