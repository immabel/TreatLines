using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Schedule
{
    public class ScheduleDTO
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string WorkDays { get; set; }
    }
}
