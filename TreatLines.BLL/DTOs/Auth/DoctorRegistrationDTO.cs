﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Auth
{
    public class DoctorRegistrationDTO : RegistrationDTO
    {
        public string Position { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string WorkDays { get; set; }
    }
}
