using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Appointment;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.Interfaces;
using TreatLines.Models;
using TreatLines.Models.Appointment;
using TreatLines.Models.ProfileInfo;
using TreatLines.Models.Response;
using TreatLines.Models.Tables;

namespace TreatLines.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IDoctorService doctorService;

        private readonly IAppointmentService appointmentService;

        private readonly IScheduleService scheduleService;

        private readonly IPatientService patientService;

        private readonly IHospitalService hospitalService;

        private readonly IMapper mapper;

        public PatientController(
            IScheduleService scheduleService,
            IAppointmentService appointmentService,
            IPatientService patientService,
            IDoctorService doctorService,
            IHospitalService hospitalService,
            IMapper mapper)
        {
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.appointmentService = appointmentService;
            this.scheduleService = scheduleService;
            this.hospitalService = hospitalService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            string email = User.Identity.Name;
            //string email = "de.tox@gmail.com";//User.Identity.Name;
            var patientInfo = await patientService.GetPatientInfoByEmailAsync(email);
            var appointment = appointmentService.GetNearestAppointmentForPatient(email);
            var result = mapper.Map<PatientProfileInfoModel>(patientInfo);
            result.Appointment = mapper.Map<AppointmentNearestInfoModel>(appointment);
            return View(result);
        }

        public async Task<IActionResult> Doctors()
        {
            string email = User.Identity.Name;
            //string email = "de.tox@gmail.com";//User.Identity.Name;
            var doctors = await hospitalService.GetDoctorsByPatientEmailAsync(email);
            var result = mapper.Map<IEnumerable<DoctorModel>>(doctors);
            return View(result);
        }

        public async Task<IActionResult> DoctorProfile(string email)
        {
            var docInfo = await doctorService.GetDoctorInfoByEmailAsync(email);
            var schedInfo = await scheduleService.GetScheduleInfoByIdAsync(docInfo.ScheduleId);

            var result = mapper.Map<DoctorProfileInfoModel>(docInfo);
            result.Schedule = mapper.Map<ScheduleInfoModel>(schedInfo);

            return View(result);
        }

        public IActionResult Prescriptions()
        {
            string email = "de.tox@gmail.com";//User.Identity.Name;
            //public IEnumerable<PrescriptionModel> Prescriptions { get; set; }
            return View();
        }

        public IActionResult HospitalProfile()
        {
            return View();
        }

        public async Task<IActionResult> MakeAppointment(string doctorEmail)
        {
            string patEmail = User.Identity.Name;
            //string patEmail = "de.tox@gmail.com";//User.Identity.Name;
            var docEmails = hospitalService.GetDoctorsEmailsByPatientEmail(patEmail);
            if (doctorEmail == null)
                doctorEmail = docEmails.First();
            AppointmentCreationModel appointment = new AppointmentCreationModel
            {
                DoctorEmail = doctorEmail,
                PatientEmail = patEmail
            };
            var freeDateTime = await doctorService.GetFreeDateTimesByDoctorEmailAsync(doctorEmail);

            appointment.DoctorsEmails = docEmails;
            appointment.FreeDatesTime = mapper.Map<IEnumerable<FreeDateTimeModel>>(freeDateTime);

            return View(appointment);
        }

        public IActionResult GetUpcomingAppointments()
        {
            string email = User.Identity.Name;
            //string email = "de.tox@gmail.com";//User.Identity.Name;
            var appoints = appointmentService.GetFutureAppointmentsByPatientEmail(email);
            var result = mapper.Map<IEnumerable<AppointmentFutureInfoModel>>(appoints);
            return View(result);
        }

        public async Task<IActionResult> CancelAppointment(int? id, int? profile)
        {
            await appointmentService.CancelAppointmentAsync((int)id);
            if (profile == 0)
                return RedirectToAction("GetUpcomingAppointments");
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientInfo(PatientProfileInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = mapper.Map<PatientInfoDTO>(model);
                await patientService.UpdatePatientAsync(patient);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment(AppointmentCreationModel model)
        {
            if (ModelState.IsValid)
            {
                string patEmail = "de.tox@gmail.com";//User.Identity.Name;
                model.PatientEmail = patEmail;
                var appointment = mapper.Map<AppointmentCreationDTO>(model);
                await appointmentService.AddAppointment(appointment);
                return RedirectToAction("MakeAppointment", new { doctorEmail = model.DoctorEmail });
            }
            return RedirectToAction("MakeAppointment", new { doctorEmail = model.DoctorEmail });
        }
    }
}
