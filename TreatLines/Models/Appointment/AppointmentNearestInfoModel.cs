using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models.Appointment
{
    public class AppointmentNearestInfoModel : AppointmentFutureInfoModel
    {
        public int? AppointmentId { get; set; }
        public int? PrescriptionId { get; set; }
        public string Description { get; set; }
    }
}
