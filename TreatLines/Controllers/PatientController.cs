using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;
using TreatLines.Models.ProfileInfo;

namespace TreatLines.Controllers
{
    public class PatientController : Controller
    {
        private readonly IDoctorService doctorService;

        private readonly IAppointmentService appointmentService;

        private readonly IScheduleService scheduleService;

        private readonly IPatientService patientService;

        private readonly IMapper mapper;

        public PatientController(
            IScheduleService scheduleService,
            IAppointmentService appointmentService,
            IPatientService patientService,
            IDoctorService doctorService,
            IMapper mapper)
        {
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.appointmentService = appointmentService;
            this.scheduleService = scheduleService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            string patId = "";
            string patientEmail = "";
            var patientInfo = await patientService.GetPatientInfoAsync(patId);
            var prescription = appointmentService.GetLatestPrescriptionByPatientEmail(patientEmail);

            var result = mapper.Map<PatientProfileInfoModel>(patientInfo);
            result.Appointment.Description = prescription.Description;
            return View(result);
        }
    }
}
