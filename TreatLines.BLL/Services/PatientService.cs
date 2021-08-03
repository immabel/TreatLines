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

        private readonly IDoctorRepository doctorRepository;

        private readonly IDoctorPatientRepository doctorPatientRepository;

        private readonly IHospitalAdminRepository hospitalAdminRepository;

        private readonly IPatientRepository patientRepository;

        private readonly IHospitalRepository hospitalRepository;

        private readonly IRepository<Prescription> prescriptionRepository;

        private readonly IMapper mapper;

        public PatientService(
            UserRepository userRepository,
            IDoctorRepository doctorRepository,
            IDoctorPatientRepository doctorPatientRepository,
            IHospitalAdminRepository hospitalAdminRepository,
            IPatientRepository patientRepository,
            IHospitalRepository hospitalRepository,
            IRepository<Prescription> prescriptionRepository,
            IMapper mapper
            )
        {
            this.userRepository = userRepository;
            this.doctorRepository = doctorRepository;
            this.doctorPatientRepository = doctorPatientRepository;
            this.hospitalAdminRepository = hospitalAdminRepository;
            this.patientRepository = patientRepository;
            this.hospitalRepository = hospitalRepository;
            this.prescriptionRepository = prescriptionRepository;
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
                    SkinType = apInfo.Appointment.SkinType,
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

        public IEnumerable<DoctorInfoDTO> GetPatientDoctorsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<PatientInfoDTO> GetPatientInfoAsync(string id)
        {
            TimeSpan ts = new TimeSpan(0, -30, 0);
            var patient = await patientRepository.GetByIdAsync(id);
            PatientInfoDTO patientInfo = mapper.Map<PatientInfoDTO>(patient);
            patientInfo.HospitalName = hospitalRepository.GetByIdAsync(patient.HospitalId).Result.Name;
            var appoints = doctorPatientRepository.GetAppointmentsByPatientId(id)
                .OrderByDescending(dp => dp.Appointment.DateTimeAppointment);
            if (appoints.First().Appointment.PrescriptionId == null)
                appoints = appoints.SkipWhile(dp => dp.Appointment.DateTimeAppointment.Subtract(DateTimeOffset.Now).CompareTo(ts) > 0)
                    .OrderBy(dp => dp.Appointment.DateTimeAppointment);//SkipLast(1).OrderBy(dp => dp.Appointment.DateTimeAppointment);
            if (appoints.Count() != 0 && appoints.Last().Appointment.PrescriptionId != null)
            {
                var prescriptionId = appoints.Last().Appointment.PrescriptionId;
                patientInfo.Prescription = prescriptionRepository.GetByIdAsync((int)prescriptionId).Result.Description;
            }
            return patientInfo;
        }

        public Task<PatientInfoDTO> GetPatientInfoByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientsInfoDTO> GetPatientsByHospitalAdminId(string id)
        {
            var hospitalId = hospitalAdminRepository.GetHospitalByHospitalAdminId(id).Id;
            var patients = patientRepository.GetAllWithUserAsync()
                .Result
                .Where(p => p.HospitalId == hospitalId)
                .Select(p => new PatientsInfoDTO
                {
                    Id = p.UserId,
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName,
                    Email = p.User.Email,
                    BloodType = p.BloodType,
                    Sex = p.Sex,
                    Blocked = p.User.Blocked ? 1 : 0
                });
            return patients;
        }

        public IEnumerable<PrescriptionInfoDTO> GetPrescriptionByPatientEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrescriptionInfoDTO> GetPrescriptionByPatientId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePatient(PatientInfoDTO patient)
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
    }
}
