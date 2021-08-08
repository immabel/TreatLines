using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Appointment;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.DTOs.Prescription;
using TreatLines.BLL.Interfaces;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;
using TreatLines.DAL.Repositories;

namespace TreatLines.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly UserRepository userRepository;

        private readonly IDoctorPatientRepository doctorPatientRepository;

        private readonly IPatientRepository patientRepository;

        private readonly IRepository<Prescription> prescriptionRepository;

        private readonly IRepository<Appointment> appointmentRepository;

        private readonly IMapper mapper;

        public PatientService(
            UserRepository userRepository,
            IDoctorPatientRepository doctorPatientRepository,
            IPatientRepository patientRepository,
            IRepository<Prescription> prescriptionRepository,
            IRepository<Appointment> appointmentRepository,
            IMapper mapper
            )
        {
            this.userRepository = userRepository;
            this.doctorPatientRepository = doctorPatientRepository;
            this.patientRepository = patientRepository;
            this.prescriptionRepository = prescriptionRepository;
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
        }

        public IEnumerable<PastAppointmentsPatientInfoDTO> GetPastAppointmentsByPatientId(string id)
        {
            TimeSpan ts = new TimeSpan(-1, 0, 0);
            var appointInfo = doctorPatientRepository.GetAppointmentsByPatientId(id);
            if (appointInfo == null)
                return null;
            var appointmentsInfo = appointInfo.Where(ap => ap.Appointment.DateTimeAppointment.Subtract(DateTimeOffset.Now).CompareTo(ts) < 0)
                .Select(apInfo => new PastAppointmentsPatientInfoDTO
                {
                    Id = (int)apInfo.AppointmentId,
                    DateTimeAppointment = apInfo.Appointment.DateTimeAppointment.ToString("g"),
                    DoctorEmail = apInfo.Doctor.User.Email,
                    FirstName = apInfo.Doctor.User.FirstName,
                    LastName = apInfo.Doctor.User.LastName,
                    DoctorPosition = apInfo.Doctor.Position,
                    Canceled = apInfo.Appointment.Canceled ? 1 : 0,
                    Prescription = (apInfo.Appointment.Prescription == null) ? "-" : apInfo.Appointment.Prescription.Description
                });
            return appointmentsInfo;
        }

        public IEnumerable<AppointmentsPatientFutureInfoDTO> GetFutureAppointmentsByPatientId(string id)
        {
            TimeSpan ts = new TimeSpan(-1, 0, 0);
            var appointInfo = doctorPatientRepository.GetAppointmentsByPatientId(id);
            if (appointInfo == null)
                return null;
            var appointmentsInfo = appointInfo.Where(ap => ap.Appointment.DateTimeAppointment.Subtract(DateTimeOffset.Now).CompareTo(ts) > 0)
                .Select(apInfo => new AppointmentsPatientFutureInfoDTO
                {
                    Id = (int)apInfo.AppointmentId,
                    DateTimeAppointment = apInfo.Appointment.DateTimeAppointment.ToString("g"),
                    DoctorEmail = apInfo.Doctor.User.Email,
                    FirstName = apInfo.Doctor.User.FirstName,
                    LastName = apInfo.Doctor.User.LastName,
                    Position = apInfo.Doctor.Position,
                    Canceled = apInfo.Appointment.Canceled ? 1 : 0
                });
            return appointmentsInfo;
        }

        public async Task<PatientInfoDTO> GetPatientInfoAsync(string id)
        {
            var patient = await patientRepository.GetByIdAsync(id);
            PatientInfoDTO patientInfo = mapper.Map<PatientInfoDTO>(patient);
            //patientInfo.HospitalName = hospitalRepository.GetByIdAsync(patient.HospitalId).Result.Name;            
            return patientInfo;
        }

        public async Task UpdatePatientAsync(PatientInfoDTO patient)
        {
            User user = await userRepository.FindByEmailAsync(patient.Email);
            user.FirstName = patient.FirstName;
            user.LastName = patient.LastName;
            await userRepository.UpdateAsync(user);

            Patient patientTemp = await patientRepository.GetByEmailAsync(patient.Email);
            patientTemp.BloodType = patient.BloodType;
            patientTemp.Sex = patient.Sex;
            patientRepository.Update(patientTemp);
            await patientRepository.SaveChangesAsync();
        }

        public async Task UpsertPrescriptionByAppointmentIdAsync(PrescriptionDTO prescriptionDTO)
        {
            var appointment = await appointmentRepository.GetByIdAsync((int)prescriptionDTO.AppointmentId);
            if (appointment.PrescriptionId != null)
            {
                Prescription prescription = await prescriptionRepository.GetByIdAsync((int)appointment.PrescriptionId);
                prescription.Description = prescriptionDTO.Description;
                prescriptionRepository.Update(prescription);
                await prescriptionRepository.SaveChangesAsync();
            }
            else
            {
                Prescription prescription = new Prescription { Description = prescriptionDTO.Description };
                await prescriptionRepository.AddAsync(prescription);
                await prescriptionRepository.SaveChangesAsync();
                appointment.PrescriptionId = prescription.Id;
                appointmentRepository.Update(appointment);
                await appointmentRepository.SaveChangesAsync();
            }
        }

        public async Task<PatientInfoDTO> GetPatientInfoByEmailAsync(string email)
        {
            var patient = await patientRepository.GetByEmailAsync(email);
            var result = await GetPatientInfoAsync(patient.UserId);
            return result;
        }

        public IEnumerable<string> GetPatientsEmailsByHospitalId(int id)
        {
            IEnumerable<string> patEms = patientRepository.GetAllWithUserAsync()
                .Result
                .Where(p => p.HospitalId == id)
                .Select(dp => dp.User.Email);
            return patEms;
        }

        public PrescriptionInfoDTO GetLatestPrescriptionByPatientEmail(string email)
        {
            TimeSpan ts = new TimeSpan(0, -30, 0);
            var patId = patientRepository.GetByEmailAsync(email).Result.UserId;
            var appoints = doctorPatientRepository.GetAppointmentsByPatientId(patId);
            if (appoints.Count() != 0 && appoints.First().Appointment.PrescriptionId == null)
                appoints = appoints
                    .OrderByDescending(dp => dp.Appointment.DateTimeAppointment)
                    .SkipWhile(dp => dp.Appointment.DateTimeAppointment
                    .Subtract(DateTimeOffset.Now).CompareTo(ts) > 0)
                    .OrderBy(dp => dp.Appointment.DateTimeAppointment);//SkipLast(1).OrderBy(dp => dp.Appointment.DateTimeAppointment);
            if (appoints.Count() != 0 && appoints.Last().Appointment.PrescriptionId != null)
            {
                var prescriptionId = (int)appoints.Last().Appointment.PrescriptionId;
                var description = prescriptionRepository.GetByIdAsync((int)prescriptionId).Result.Description;
                return new PrescriptionInfoDTO
                {
                    Id = prescriptionId,
                    Description = description
                };
            };
            return null;
        }
    }
}
