using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.Models.Appointment;

namespace TreatLines.Models.ProfileInfo
{
    public class PatientProfileInfoModel : PatientProfileInfoHospAdminModel
    {
        public AppointmentNearestInfoModel Appointment { get; set; }
    }
}
