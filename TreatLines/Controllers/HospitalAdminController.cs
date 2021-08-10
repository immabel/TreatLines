using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.HospitalAdmin;
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
    //[Authorize]
    public class HospitalAdminController : Controller
    {
        private readonly IAuthService authService;

        private readonly IHospitalService hospitalService;

        private readonly IDoctorService doctorService;

        private readonly IPatientService patientService;

        private readonly IScheduleService scheduleService;

        private readonly IPatientRegistrationRequestsService patientRegistrationRequestsService;

        private readonly IMapper mapper;

        public HospitalAdminController(
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
        }

        public async Task<IActionResult> Index()
        {
            string email = "ssadmin@gmail.com";//User.Identity.Name;
            var hospAdm = await hospitalService.GetHospitalAdminProfileInfoAsync(email);
            var result = mapper.Map<HospitalAdminProfileInfoModel>(hospAdm);
            return View(result);
        }

        public async Task<IActionResult> Requests()
        {
            string email = "ssadmin@gmail.com";//User.Identity.Name;
            var hospId = hospitalService.GetHospitalIdByHospAdmin(email);
            var requests = await patientRegistrationRequestsService.GetAllRequestsAsync(hospId);
            var result = mapper.Map<IEnumerable<RequestInfoToCreatePatientModel>>(requests);
            return View(result);
        }

        public IActionResult HospitalAdmins()
        {
            string email = "ssadmin@gmail.com";//User.Identity.Name;
            var hospAdms = hospitalService.GetHospitalAdminsByHospAdmin(email);
            var result = mapper.Map<IEnumerable<HospitalAdminModel>>(hospAdms);
            return View(result);
        }

        public IActionResult Doctors()
        {
            string email = "ssadmin@gmail.com";//User.Identity.Name;
            var doctors = hospitalService.GetDoctorsByHospitalAdmin(email);
            var result = mapper.Map<IEnumerable<DoctorModel>>(doctors);
            return View(result);
        }

        public IActionResult Patients()
        {
            string email = "ssadmin@gmail.com";//User.Identity.Name;
            var patients = hospitalService.GetPatientsByHospitalAdmin(email);
            var result = mapper.Map<IEnumerable<PatientModel>>(patients);
            return View(result);
        }

        public async Task<IActionResult> MakeAppointment(string doctorEmail, string patientEmail)
        {
            string email = "ssadmin@gmail.com";//User.Identity.Name;
            var hospId = hospitalService.GetHospitalIdByHospAdmin(email);
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
            appointment.DoctorsEmails = docEmails;
            appointment.PatientsEmails = patEmails;

            IEnumerable<FreeDateTimesDTO> freeDateTime = null;

            if (doctorEmail != null)
            {
                freeDateTime = await doctorService.GetFreeDateTimesByDoctorEmailAsync(doctorEmail);
            }
            else
            {
                freeDateTime = await doctorService.GetFreeDateTimesByDoctorEmailAsync(docEmails.First());
            }
            appointment.FreeDatesTime = mapper.Map<IEnumerable<FreeDateTimeModel>>(freeDateTime);

            return View(appointment);
        }

        public async Task<IActionResult> DoctorProfile(string email)
        {
            //string adminEmail = "ssadmin@gmail.com";//User.Identity.Name;
            var docInfo = await doctorService.GetDoctorInfoByEmailAsync(email);
            var schedules = scheduleService.GetSchedules(docInfo.HospitalId);

            var result = mapper.Map<DoctorProfileInfoHospAdminModel>(docInfo);
            result.Schedules = mapper.Map<IEnumerable<ScheduleInfoModel>>(schedules);
            

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
            string email = "ssadmin@gmail.com";//User.Identity.Name;
            var hospId = hospitalService.GetHospitalIdByHospAdmin(email);
            var schedules = scheduleService.GetSchedules(hospId);
            var doctor = new DoctorRegistrationModel();
            doctor.Schedules = mapper.Map<IEnumerable<ScheduleInfoModel>>(schedules);
            return View(doctor);
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
                string email = "ssadmin@gmail.com";//User.Identity.Name;
                var hospId = hospitalService.GetHospitalIdByHospAdmin(email);
                var hospAdm = mapper.Map<HospitalAdminRegistrationDTO>(model);
                hospAdm.HospitalId = hospId;
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
                string email = "ssadmin@gmail.com";//User.Identity.Name;
                var hospId = hospitalService.GetHospitalIdByHospAdmin(email);
                var doc = mapper.Map<DoctorRegistrationDTO>(model);
                doc.HospitalId = hospId;
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
                string email = "ssadmin@gmail.com";//User.Identity.Name;
                var hospId = hospitalService.GetHospitalIdByHospAdmin(email);
                var patient = mapper.Map<PatientRegistrationDTO>(model);
                patient.HospitalId = hospId;
                await authService.RegisterPatientAsync(patient);
                return RedirectToAction("AddPatient");
            }
            return RedirectToAction("AddPatient", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctorInfo(DoctorProfileInfoHospAdminModel model)
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

        public async Task<IActionResult> ApproveRequest(int? id)
        {
            await patientRegistrationRequestsService.ApproveRequestAsync((int)id);
            return RedirectToAction("Requests");
        }

        public async Task<IActionResult> RejectRequest(int? id)
        {
            await patientRegistrationRequestsService.RejectRequestAsync((int)id);
            return RedirectToAction("Requests");
        }

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

        [HttpPost]
        public async Task<IActionResult> UpdateHospitalAdminInfo(HospitalAdminProfileInfoModel model)
        {
            var hAdmin = mapper.Map<HospitalAdminInfoDTO>(model);
            await hospitalService.UpdateHospitalAdminInfoAsync(hAdmin);
            return View("Index", model);
        }
    }
}
