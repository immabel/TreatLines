using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models
{
    public class ScheduleInfoModel
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public IEnumerable<string> WorkDays { get; set; }
    }
}
