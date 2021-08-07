using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Schedule
{
    public class ScheduleInfoDTO
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<string> WorkDays { get; set; }
    }
}
