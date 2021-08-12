using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;
using TreatLines.DAL.Repositories;
using TreatLines.BLL.DTOs.Appointment;
using TreatLines.BLL.DTOs.Prescription;

namespace TreatLines.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly UserRepository userRepository;

        private readonly IRepository<Appointment> appointmentRepository;

        private readonly IDoctorPatientRepository doctorPatientRepository;

        private readonly IDoctorRepository doctorRepository;
        
        private readonly IPatientRepository patientRepository;

        private readonly IRepository<Prescription> prescriptionRepository;

        private readonly IMapper mapper;

        public AppointmentService(
            UserRepository userRepository,
            IRepository<Appointment> appointmentRepository,
            IDoctorPatientRepository doctorPatientRepository,
            IRepository<Prescription> prescriptionRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.appointmentRepository = appointmentRepository;
            this.doctorPatientRepository = doctorPatientRepository;
            this.prescriptionRepository = prescriptionRepository;
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;
            this.mapper = mapper;
        }

        public IEnumerable<PastAppointmentsPatientInfoDTO> GetPastAppointmentsByPatientEmail(string email)
        {
            TimeSpan ts = new TimeSpan(-1, 0, 0);
            var appointInfo = doctorPatientRepository.GetAppointmentsByPatientEmail(email);
            if (appointInfo == null || appointInfo.Count() == 0)
                return null;
            var appointmentsInfo = appointInfo.Where(ap => ap.Appointment.DateTimeAppointment.Subtract(DateTimeOffset.Now).CompareTo(ts) < 0)
                .Select(apInfo => new PastAppointmentsPatientInfoDTO
                {
                    Id = apInfo.AppointmentId,
                    DateTimeAppointment = apInfo.Appointment.DateTimeAppointment.ToString("g"),
                    DoctorEmail = apInfo.Doctor.User.Email,
                    FirstName = apInfo.Doctor.User.FirstName,
                    LastName = apInfo.Doctor.User.LastName,
                    Position = apInfo.Doctor.Position,
                    Canceled = apInfo.Appointment.Canceled,
                    Price = apInfo.Appointment.Price,
                    PriceWithDiscount = apInfo.Appointment.PriceWithDiscount,
                    Prescription = (apInfo.Appointment.Prescription == null) ? null : apInfo.Appointment.Prescription.Description
                });
            return appointmentsInfo;
        }

        public IEnumerable<AppointmentPatientFutureInfoDTO> GetFutureAppointmentsByPatientEmail(string email)
        {
            TimeSpan ts = new TimeSpan(-1, 0, 0);
            var appointInfo = doctorPatientRepository.GetAppointmentsByPatientEmail(email);
            if (appointInfo == null || appointInfo.Count() == 0)
                return null;
            var appointments = appointInfo
                .Where(dp => dp.Appointment.DateTimeAppointment.Subtract(DateTimeOffset.Now).CompareTo(ts) > 0 && !dp.Appointment.Canceled)
                .OrderBy(ap => ap.Appointment.DateTimeAppointment)
                .Select(dp => new AppointmentPatientFutureInfoDTO
                {
                    Id = dp.AppointmentId,
                    DateTimeAppointment = dp.Appointment.DateTimeAppointment.ToString("g"),
                    DoctorEmail = dp.Doctor.User.Email,
                    Price = dp.Appointment.Price,
                    PriceWithDiscount = dp.Appointment.PriceWithDiscount,
                    FirstName = dp.Doctor.User.FirstName,
                    LastName = dp.Doctor.User.LastName,
                    Position = dp.Doctor.Position,
                    Canceled = dp.Appointment.Canceled
                });
            return appointments;
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

        public async Task AddAppointment(AppointmentCreationDTO appointmentDto)
        {
            var patient = await patientRepository.GetByEmailAsync(appointmentDto.PatientEmail);
            var doctor = await doctorRepository.GetByEmailAsync(appointmentDto.DoctorEmail);

            var priceWithDiscount = doctor.Price - (doctor.Price * (decimal)patient.Discount / 100.0M);

            Appointment appointment = new Appointment
            {
                DateTimeAppointment = appointmentDto.DateTimeAppointment,
                Price = doctor.Price,
                PriceWithDiscount = priceWithDiscount
            };
            await appointmentRepository.AddAsync(appointment);
            await appointmentRepository.SaveChangesAsync();

            await doctorPatientRepository.AddAsync(new DoctorPatient
            {
                DoctorId = doctor.UserId,
                PatientId = patient.UserId,
                AppointmentId = appointment.Id
            });
            await doctorPatientRepository.SaveChangesAsync();
        }

        public IEnumerable<AppointmentFutureInfoDTO> GetFutureAppointmentsByDoctorEmail(string email)
        {
            var appointInfo = doctorPatientRepository
                .GetAppointmentsByDoctorEmail(email);
            var tempAppoints = appointInfo
                .Where(ap => ap.Appointment.DateTimeAppointment.CompareTo(DateTimeOffset.Now) > 0)
                .OrderBy(ap => ap.Appointment.DateTimeAppointment)
                .Select(apInfo => new AppointmentFutureInfoDTO
                {
                    Id = (int)apInfo.AppointmentId,
                    DateTimeAppointment = apInfo.Appointment.DateTimeAppointment.ToString("g"),
                    PatientEmail = apInfo.Patient.User.Email,
                    FirstName = apInfo.Patient.User.FirstName,
                    LastName = apInfo.Patient.User.LastName,
                    Canceled = apInfo.Appointment.Canceled,
                    Price = apInfo.Appointment.Price,
                    PriceWithDiscount = apInfo.Appointment.PriceWithDiscount
                });
            return tempAppoints;
        }

        public PrescriptionInfoDTO GetLatestPrescriptionByPatientEmail(string email)
        {
            TimeSpan ts = new TimeSpan(0, -30, 0);
            //var patId = doctorPatientRepository.GetPatientByEmailAsync(email).Result.UserId;
            var appoints = doctorPatientRepository.GetAppointmentsByPatientEmail(email);
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

        public async Task CancelAppointmentAsync(int id)
        {
            var appoint = await appointmentRepository.GetByIdAsync(id);
            appoint.Canceled = true;
            appointmentRepository.Update(appoint);
            await appointmentRepository.SaveChangesAsync();
        }

        public IEnumerable<AppointmentInfoDTO> GetLastAppointmentsByPatientId(string id)
        {
            TimeSpan ts = new TimeSpan(-1, 30, 0);
            var appointInfo = doctorPatientRepository.GetAppointmentsInfoForDoctorByPatientId(id);
            if ((appointInfo.Count() == 1 || appointInfo.Count() == 0) && appointInfo.First().Appointment == null)
                return null;
            var appointmentsInfo = appointInfo.Where(ap => ap.Appointment.DateTimeAppointment.Subtract(DateTimeOffset.Now).CompareTo(ts) < 0)
                .Select(apInfo => new AppointmentInfoDTO
                {
                    Id = (int)apInfo.AppointmentId,
                    DateTimeAppointment = apInfo.Appointment.DateTimeAppointment.ToString("g"),
                    PrescriptionId = apInfo.Appointment.PrescriptionId == null ? 0 : (int)apInfo.Appointment.PrescriptionId,
                    Description = apInfo.Appointment.Prescription == null ? "-" : apInfo.Appointment.Prescription.Description
                });                
            return appointmentsInfo;
        }

        public AppointmentInfoDTO GetNearestAppointment(string doctorEmail, string patientEmail)
        {
            TimeSpan ts = new TimeSpan(-1, 30, 0);
            var doctorId = userRepository.FindByEmailAsync(doctorEmail).Result.Id;
            var patientId = userRepository.FindByEmailAsync(patientEmail).Result.Id;
            Appointment appointment = doctorPatientRepository.GetAppointments(doctorId, patientId)
                .Where(ap => ap.DateTimeAppointment.Subtract(DateTimeOffset.Now).CompareTo(ts) > 0)
                .FirstOrDefault();
            var result = mapper.Map<AppointmentInfoDTO>(appointment);
            if (result.PrescriptionId != null)
                result.Description = appointment.Prescription.Description;
            return result;
        }

        public AppointmentPatientFutureInfoDTO GetNearestAppointmentForPatient(string patientEmail)
        {
            var appointments = GetFutureAppointmentsByPatientEmail(patientEmail);
            if (appointments == null || appointments.Count() == 0)
                return null;
            var appointment = appointments.First();
            return appointment;
        }
    }
}
