using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Appointment;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Prescription;
using TreatLines.BLL.Interfaces;
using TreatLines.Models;
using TreatLines.Models.Appointment;
using TreatLines.Models.ProfileInfo;
using TreatLines.Models.Response;
using TreatLines.Models.Tables;

namespace TreatLines.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;

        private readonly IScheduleService scheduleService;

        private readonly IPatientService patientService;

        private readonly IAppointmentService appointmentService;

        private readonly IMapper mapper;

        public DoctorController(
            IScheduleService scheduleService,
            IPatientService patientService,
            IAppointmentService appointmentService,
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
            string email = User.Identity.Name;
            //string email = "alaska.thunderfuck@gmail.com";//User.Identity.Name;
            var docInfo = await doctorService.GetDoctorInfoByEmailAsync(email);
            var schedInfo = await scheduleService.GetScheduleInfoByIdAsync(docInfo.ScheduleId);

            var result = mapper.Map<DoctorProfileInfoModel>(docInfo);
            result.Schedule = mapper.Map<ScheduleInfoModel>(schedInfo);

            return View(result);
        }

        public IActionResult GetUpcomingAppointments()
        {
            string email = User.Identity.Name;
            //string email = "alaska.thunderfuck@gmail.com";//User.Identity.Name;
            var appoints = appointmentService.GetFutureAppointmentsByDoctorEmail(email);
            var result = mapper.Map<IEnumerable<AppointmentFutureInfoModel>>(appoints);
            return View(result);
        }

        public IActionResult Patients()
        {
            string email = User.Identity.Name;
            //string email = "alaska.thunderfuck@gmail.com";//User.Identity.Name;
            var patients = doctorService.GetDoctorPatientsByEmail(email);
            var result = mapper.Map<IEnumerable<PatientModel>>(patients);
            return View(result);
        }

        public async Task<IActionResult> PatientProfile(string email)
        {
            string docEmail = User.Identity.Name;
            //string docEmail = "alaska.thunderfuck@gmail.com";//User.Identity.Name;
            var appointment = appointmentService.GetNearestAppointment(docEmail, email);
            var patInfo = await patientService.GetPatientInfoByEmailAsync(email);
            var result = mapper.Map<PatientProfileInfoModel>(patInfo);
            result.Appointment = mapper.Map<AppointmentNearestInfoModel>(appointment);
            result.Appointment.Email = patInfo.Email;
            return View(result);
        }

        public async Task<IActionResult> MakeAppointment(string patientEmail)
        {
            string docEmail = User.Identity.Name;
            //string docEmail = "alaska.thunderfuck@gmail.com";//User.Identity.Name;
            if (patientEmail == null)
                patientEmail = "de.tox@gmail.com";
            AppointmentCreationModel appointment = new AppointmentCreationModel
            {
                DoctorEmail = docEmail,
                PatientEmail = patientEmail
            };
            var patEmails = doctorService.GetPatientsEmailsByDoctorEmail(docEmail);
            var freeDateTime = await doctorService.GetFreeDateTimesByDoctorEmailAsync(docEmail);

            appointment.PatientsEmails = patEmails;
            appointment.FreeDatesTime = mapper.Map<IEnumerable<FreeDateTimeModel>>(freeDateTime);

            return View(appointment);
        }

        public async Task<IActionResult> CancelAppointment(int? id)
        {
            await appointmentService.CancelAppointmentAsync((int)id);
            return RedirectToAction("GetUpcomingAppointments");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctorInfo(DoctorProfileInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var doctor = mapper.Map<DoctorProfileInfoDTO>(model);
                await doctorService.UpdateDoctorAsync(doctor);
                return RedirectToAction("Index");
            }
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpsertPrescription(PatientProfileInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var prescDTO = mapper.Map<PrescriptionDTO>(model.Appointment);
                await appointmentService.UpsertPrescriptionByAppointmentIdAsync(prescDTO);
                return RedirectToAction("PatientProfile", new { email = model.Appointment.Email });
            }
            return RedirectToAction("PatientProfile", new { email = model.Appointment.Email });
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment(AppointmentCreationModel model)
        {
            if (ModelState.IsValid)
            {
                string docEmail = User.Identity.Name;
                //string docEmail = "alaska.thunderfuck@gmail.com";//User.Identity.Name;
                model.DoctorEmail = docEmail;
                var appointment = mapper.Map<AppointmentCreationDTO>(model);
                await appointmentService.AddAppointment(appointment);
                return RedirectToAction("MakeAppointment", new { patientEmail = model.PatientEmail });
            }
            return RedirectToAction("MakeAppointment", new { patientEmail = model.PatientEmail });
        }
    }
}
