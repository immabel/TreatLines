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

        public IActionResult HospitalAdmins()
        {
            string hospAdminId = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09";
            var hospAdms = hospitalService.GetHospitalAdminsByHospAdminId(hospAdminId);
            var result = mapper.Map<IEnumerable<HospitalAdminModel>>(hospAdms);
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

        public async Task<IActionResult> MakeAppointment(string doctorEmail, string patientEmail)
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
            var freeDateTime = await doctorService.GetFreeDateTimesByDoctorEmailAsync(docEmails.First());

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
            if (ModelState.IsValid)
            {
                int id = 1;
                var hospAdm = mapper.Map<HospitalAdminRegistrationDTO>(model);
                hospAdm.HospitalId = id;
                await authService.RegisterHospitalAdminAsync(hospAdm);
                return RedirectToAction("AddHospitalAdmin");
            }
            return RedirectToAction("AddHospitalAdmin", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                int id = 1;
                var doc = mapper.Map<DoctorRegistrationDTO>(model);
                doc.HospitalId = id;
                await authService.RegisterDoctorAsync(doc);
                return RedirectToAction("AddDoctor");
            }
            return RedirectToAction("AddDoctor", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                int id = 1;
                var patient = mapper.Map<PatientRegistrationDTO>(model);
                patient.HospitalId = id;
                await authService.RegisterPatientAsync(patient);
                return RedirectToAction("AddPatient");
            }
            return RedirectToAction("AddPatient", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctorInfo(DoctorProfileInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var doctor = mapper.Map<DoctorProfileInfoDTO>(model);
                await doctorService.UpdateDoctorAsync(doctor);
                return View("DoctorProfile", model);
            }
            return View("DoctorProfile", model);
        }

        [HttpPost]
        public async Task<PartialViewResult> ChangeSchedule(ScheduleInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var schedule = mapper.Map<ScheduleInfoDoctorDTO>(model);
                await doctorService.ChangeDoctorScheduleAsync(schedule);
                //return RedirectToAction("DoctorProfile", new { email = model.DoctorEmail });
                return PartialView("_ScheduleInfo", model);
            }
            return PartialView("_ScheduleInfo", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientInfo(PatientProfileInfoHospAdminModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = mapper.Map<PatientInfoDTO>(model);
                await patientService.UpdatePatientAsync(patient);
                return View("PatientProfile", model);
            }
            return View("PatientProfile", model);
            //return RedirectToAction("PatientProfile", new { email = model.Email });
        }

        [HttpPost]
        public async Task<IActionResult> ApproveRequest(int id)
        {
            await patientRegistrationRequestsService.ApproveRequestAsync(id);
            return RedirectToAction("Requests");
        }

        [HttpPost]
        public async Task<IActionResult> RejectRequest(int id)
        {
            await patientRegistrationRequestsService.RejectRequestAsync(id);
            return RedirectToAction("Requests");
        }

        [HttpPost]
        public async Task<IActionResult> BlockUnblockUser(string id, int userType)
        {
            await hospitalService.BlockUserAsync(id);
            if (userType == 0)
                return RedirectToAction("HospitalAdmins");
            else if (userType == 1)
                return RedirectToAction("Doctors");
            else
                return RedirectToAction("Patients");
        }
    }
}
