using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models
{
    public class ScheduleInfoModel
    {
        public int Id { get; set; }
        public string DoctorEmail { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<string> WorkDays { get; set; }
    }
}
