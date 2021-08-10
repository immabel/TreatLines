using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.Models.Appointment;

namespace TreatLines.Models.ProfileInfo
{
    public class DoctorProfileInfoHospAdminModel : HospitalAdminProfileInfoModel
    {
        public string Position { get; set; }
        public decimal Price { get; set; }
        public bool OnHoliday { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }
        public int ScheduleId { get; set; }
        public IEnumerable<ScheduleInfoModel> Schedules { get; set; }
    }
}
