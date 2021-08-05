using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;
using TreatLines.Models.Appointment;

namespace TreatLines.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;

        private readonly IMapper mapper;

        private readonly ILogger<DoctorController> _logger;

        public DoctorController(
            ILogger<DoctorController> logger,
            IDoctorService doctorService,
            IMapper mapper)
        {
            this.doctorService = doctorService;
            this.mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUpcomingAppointments()
        {
            var appoints = doctorService.GetFutureAppointmentsByDoctorEmail("");
            var result = mapper.Map<IEnumerable<AppointmentFutureInfoDoctorModel>>(appoints);
            return PartialView(result);
        }

        public async Task<IActionResult> CancelAppointment(int? id)
        {
            await doctorService.CancelAppointmentAsync((int)id);
            return PartialView("_GetUpcomingAppointments");
        }

        public IActionResult Patients()
        {
            return View();
        }

        public IActionResult PatientProfile()
        {
            return View();
        }
    }
}
