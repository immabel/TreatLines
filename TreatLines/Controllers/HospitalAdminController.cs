using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.Interfaces;
using TreatLines.Models.Auth;
using TreatLines.Models.Tables;

namespace TreatLines.Controllers
{
    public class HospitalAdminController : Controller
    {
        private readonly IHospitalService hospitalService;

        private readonly IDoctorService doctorService;

        private readonly IPatientService patientService;

        private readonly IScheduleService scheduleService;

        private readonly IPatientRegistrationRequestsService patientRegistrationRequestsService;

        private readonly IMapper mapper;

        private readonly ILogger<HospitalAdminController> _logger;

        public HospitalAdminController(
            ILogger<HospitalAdminController> logger,
            IHospitalService hospitalService,
            IScheduleService scheduleService,
            IDoctorService doctorService,
            IPatientService patientService,
            IPatientRegistrationRequestsService patientRegistrationRequestsService,
            IMapper mapper)
        {
            this.hospitalService = hospitalService;
            this.scheduleService = scheduleService;
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.patientRegistrationRequestsService = patientRegistrationRequestsService;
            this.mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Requests()
        {
            var requests = await patientRegistrationRequestsService.GetAllRequestsAsync();
            var result = mapper.Map<IEnumerable<RequestInfoToCreatePatientModel>>(requests);
            return View(result);
        }

        public IActionResult Doctors()
        {
            var doctors = doctorService.GetDoctorsByHospitalAdminId("");
            var result = mapper.Map<IEnumerable<DoctorModel>>(doctors);
            return View();
        }

        public IActionResult Patients()
        {
            var patients = patientService.GetPatientsByHospitalAdminId("");
            var result = mapper.Map<IEnumerable<PatientModel>>(patients);
            return View();
        }

        public IActionResult MakeAppointment()
        {

            return View();
        }

        public IActionResult AddHospitalAdmin()
        {
            return View();
        }

        public IActionResult AddDoctor()
        {
            return View();
        }

        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHospitalAdmin(RegistrationModel model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDoctor(DoctorRegistrationModel model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(PatientRegistrationModel model)
        {
            return View();
        }
    }
}
