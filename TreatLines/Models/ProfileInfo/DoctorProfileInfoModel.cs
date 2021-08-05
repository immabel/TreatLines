using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.Models.Appointment;

namespace TreatLines.Models.ProfileInfo
{
    public class DoctorProfileInfoModel : HospitalAdminProfileInfoModel
    {
        public string Position { get; set; }
        public decimal Price { get; set; }
        public bool OnHoliday { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public ScheduleInfoModel Schedule { get; set; }
    }
}
