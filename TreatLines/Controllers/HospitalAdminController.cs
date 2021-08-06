using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.Interfaces;
using TreatLines.Models;
using TreatLines.Models.Auth;
using TreatLines.Models.ProfileInfo;
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

        public async Task<IActionResult> Index()
        {
            string hospAdminId = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09";
            var hospAdm = await hospitalService.GetHospitalAdminProfileInfoAsync(hospAdminId);
            var result = mapper.Map<HospitalAdminProfileInfoModel>(hospAdm);
            return View(result);
        }

        public async Task<IActionResult> Requests()
        {
            int hospId = 1;
            var requests = await patientRegistrationRequestsService.GetAllRequestsAsync(hospId);
            var result = mapper.Map<IEnumerable<RequestInfoToCreatePatientModel>>(requests);
            return View(result);
        }

        public IActionResult Doctors()
        {
            string hospId = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09";
            var doctors = doctorService.GetDoctorsByHospitalAdminId(hospId);
            var result = mapper.Map<IEnumerable<DoctorModel>>(doctors);
            return View(result);
        }

        public IActionResult Patients()
        {
            string hospId = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09";
            var patients = patientService.GetPatientsByHospitalAdminId(hospId);
            var result = mapper.Map<IEnumerable<PatientModel>>(patients);
            return View(result);
        }

        public IActionResult MakeAppointment()
        {
            return View();
        }

        public async Task<IActionResult> DoctorProfile(string email)
        {
            var docInfo = await doctorService.GetDoctorInfoByEmailAsync(email);
            var result = mapper.Map<DoctorProfileInfoModel>(docInfo);
            result.Schedule.DoctorId = docInfo.Id;
            return View(result);
        }

        public IActionResult PatientProfile(string id)
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

        [HttpPost]
        public IActionResult ChangeSchedule(ScheduleInfoModel model)
        {
            return RedirectToAction("DoctorProfile");
        }
    }
}
