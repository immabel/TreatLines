using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.Models.Appointment
{
    public class AppointmentFutureInfoModel
    {
        public int Id { get; set; }
        public string DateTimeAppointment { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Canceled { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithDiscount { get; set; }
        public string Position { get; set; }
    }
}
