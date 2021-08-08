using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;

        private readonly IScheduleService scheduleService;

        private readonly IPatientService patientService;

        private readonly IMapper mapper;

        public DoctorController(
            IScheduleService scheduleService,
         IPatientService patientService,
        IDoctorService doctorService,
            IMapper mapper)
        {
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.scheduleService = scheduleService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            string docId = "E8D13331-62AB-463E-A283-6493B68A3622";
            var docInfo = await doctorService.GetDoctorInfoAsync(docId);
            var schedInfo = scheduleService.GetScheduleInfoByIdAsync(docInfo.ScheduleId);

            var result = mapper.Map<DoctorProfileInfoModel>(docInfo);
            result.Schedule = mapper.Map<ScheduleInfoModel>(schedInfo);

            return View(result);
        }

        public IActionResult GetUpcomingAppointments()
        {
            string docEmail = "alaska.thunderfuck@gmail.com";
            var appoints = doctorService.GetFutureAppointmentsByDoctorEmail(docEmail);
            var result = mapper.Map<IEnumerable<AppointmentFutureInfoDoctorModel>>(appoints);
            return View(result);
        }

        public IActionResult Patients()
        {
            string docEmail = "alaska.thunderfuck@gmail.com";
            var patients = doctorService.GetDoctorPatientsByEmail(docEmail);
            var result = mapper.Map<IEnumerable<PatientModel>>(patients);
            return View(result);
        }

        public async Task<IActionResult> PatientProfile(string email)
        {
            string docId = "E8D13331-62AB-463E-A283-6493B68A3622";
            var appointment = doctorService.GetNearestAppointment(docId, email);
            var patInfo = await patientService.GetPatientInfoByEmailAsync(email);
            var result = mapper.Map<PatientProfileInfoModel>(patInfo);
            result.Appointment = mapper.Map<AppointmentNearestInfoModel>(appointment);
            result.Appointment.PatientEmail = patInfo.Email;
            return View(result);
        }

        public async Task<IActionResult> MakeAppointment(string patientEmail)
        {
            int hospId = 1;
            string docEmail = "alaska.thunderfuck@gmail.com";
            patientEmail = "de.tox@gmail.com";
            AppointmentCreationModel appointment = new AppointmentCreationModel
            {
                DoctorEmail = docEmail,
                PatientEmail = patientEmail
            };
            var patEmails = patientService.GetPatientsEmailsByHospitalId(hospId);
            var freeDateTime = await doctorService.GetFreeDateTimesByDoctorEmailAsync(docEmail);

            appointment.PatientsEmails = patEmails;
            appointment.FreeDatesTime = mapper.Map<IEnumerable<FreeDateTimeModel>>(freeDateTime);

            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctorInfo(DoctorProfileInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var doctor = mapper.Map<DoctorProfileInfoDTO>(model);
                await doctorService.UpdateDoctorAsync(doctor);
                return View("DoctorProfile");
            }
            return View("DoctorProfile", model);
        }

        [HttpPost]
        public async Task<IActionResult> CancelAppointment(int? id)
        {
            await doctorService.CancelAppointmentAsync((int)id);
            return RedirectToAction("GetUpcomingAppointments");
        }

        [HttpPost]
        public async Task<IActionResult> UpsertPrescription(AppointmentNearestInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var prescDTO = mapper.Map<PrescriptionDTO>(model);
                await patientService.UpsertPrescriptionByAppointmentIdAsync(prescDTO);
                return RedirectToAction("PatientProfile", new { email = model.PatientEmail });
            }
            return RedirectToAction("PatientProfile", new { email = model.PatientEmail });
        }
    }
}
