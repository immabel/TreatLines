using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.DTOs.Schedule;
using TreatLines.BLL.Interfaces;
using TreatLines.Models;
using TreatLines.Models.Appointment;
using TreatLines.Models.Auth;
using TreatLines.Models.ProfileInfo;
using TreatLines.Models.Response;
using TreatLines.Models.Tables;

namespace TreatLines.Controllers
{
    public class HospitalAdminController : Controller
    {
        private readonly IAuthService authService;

        private readonly IHospitalService hospitalService;

        private readonly IDoctorService doctorService;

        private readonly IPatientService patientService;

        private readonly IScheduleService scheduleService;

        private readonly IPatientRegistrationRequestsService patientRegistrationRequestsService;

        private readonly IMapper mapper;

        private readonly ILogger<HospitalAdminController> _logger;

        public HospitalAdminController(
            ILogger<HospitalAdminController> logger,
            IAuthService authService,
        IHospitalService hospitalService,
            IScheduleService scheduleService,
            IDoctorService doctorService,
            IPatientService patientService,
            IPatientRegistrationRequestsService patientRegistrationRequestsService,
            IMapper mapper)
        {
            this.authService = authService;
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
            var doctors = hospitalService.GetDoctorsByHospitalAdminId(hospId);
            var result = mapper.Map<IEnumerable<DoctorModel>>(doctors);
            return View(result);
        }

        public IActionResult Patients()
        {
            string hospId = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09";
            var patients = hospitalService.GetPatientsByHospitalAdminId(hospId);
            var result = mapper.Map<IEnumerable<PatientModel>>(patients);
            return View(result);
        }

        public IActionResult MakeAppointment(string doctorEmail, string patientEmail)
        {
            int hospId = 1;
            /*if (doctorEmail == null)
            {
                
            }
            if (patientEmail == null)
            {

            }*/
            AppointmentCreationModel appointment = new AppointmentCreationModel
            {
                DoctorEmail = doctorEmail,
                PatientEmail = patientEmail
            };
            var docEmails = doctorService.GetDoctorsEmailsByHospitalId(hospId);
            var patEmails = patientService.GetPatientsEmailsByHospitalId(hospId);
            var freeDateTime = doctorService.GetFreeDateTimesByDoctorEmail(docEmails.First());

            appointment.DoctorsEmails = docEmails;
            appointment.PatientsEmails = patEmails;
            appointment.FreeDatesTime = mapper.Map<IEnumerable<FreeDateTimeModel>>(freeDateTime);

            return View(appointment);
        }

        public async Task<IActionResult> DoctorProfile(string email)
        {
            var docInfo = await doctorService.GetDoctorInfoByEmailAsync(email);
            var schedInfo = scheduleService.GetScheduleInfoByIdAsync(docInfo.ScheduleId);

            var result = mapper.Map<DoctorProfileInfoModel>(docInfo);
            result.Schedule = mapper.Map<ScheduleInfoModel>(schedInfo);
            result.Schedule.DoctorEmail = docInfo.Email;

            return View(result);
        }

        public async Task<IActionResult> PatientProfile(string email)
        {
            var patInfo = await patientService.GetPatientInfoByEmailAsync(email);
            var result = mapper.Map<PatientProfileInfoHospAdminModel>(patInfo);
            return View(result);
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
        public async Task<IActionResult> AddHospitalAdmin(RegistrationModel model)
        {
            var hospAdm = mapper.Map<HospitalAdminRegistrationDTO>(model);
            await authService.RegisterHospitalAdminAsync(hospAdm);
            return RedirectToAction("AddHospitalAdmin");
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorRegistrationModel model)
        {
            var doc = mapper.Map<DoctorRegistrationDTO>(model);
            await authService.RegisterDoctorAsync(doc);
            return RedirectToAction("AddDoctor");
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientRegistrationModel model)
        {
            var patient = mapper.Map<PatientRegistrationDTO>(model);
            await authService.RegisterPatientAsync(patient);
            return RedirectToAction("AddPatient");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctorInfo(DoctorProfileInfoModel model)
        {
            var doctor = mapper.Map<DoctorProfileInfoDTO>(model);
            await doctorService.UpdateDoctorAsync(doctor);
            return View("DoctorProfile", model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeSchedule(ScheduleInfoModel model)
        {
            var schedule = mapper.Map<ScheduleInfoDoctorDTO>(model);
            await doctorService.ChangeDoctorScheduleAsync(schedule);
            //return RedirectToAction("DoctorProfile", new { email = model.DoctorEmail });
            return PartialView("_ScheduleInfo", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientInfo(PatientProfileInfoHospAdminModel model)
        {
            var patient = mapper.Map<PatientInfoDTO>(model);
            await patientService.UpdatePatientAsync(patient);
            return View("PatientProfile", model);
        }
    }
}
