using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.DAL.Repositories;
using TreatLines.BLL.DTOs.Schedule;
using TreatLines.BLL.DTOs.Appointment;
using System.Collections;

namespace TreatLines.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly UserRepository userRepository;

        private readonly IDoctorRepository doctorRepository;

        private readonly IScheduleService scheduleService;

        private readonly IAppointmentService appointmentService;

        private readonly IDoctorPatientRepository doctorPatientRepository;

        private readonly IRepository<Hospital> hospitalRepository;

        private readonly IMapper mapper;

        public DoctorService(
            UserRepository userRepository,
            IDoctorRepository doctorRepository,
            IScheduleService scheduleService,
            IAppointmentService appointmentService,
            IDoctorPatientRepository doctorPatientRepository,
            IRepository<Hospital> hospitalRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.doctorRepository = doctorRepository;
            this.scheduleService = scheduleService;
            this.appointmentService = appointmentService;
            this.doctorPatientRepository = doctorPatientRepository;
            this.hospitalRepository = hospitalRepository;
            this.mapper = mapper;
        }

        public async Task<DoctorProfileInfoDTO> GetDoctorInfoAsync(string id)
        {
            var doctor = await doctorRepository.GetByIdAsync(id);
            var hospital = await hospitalRepository.GetByIdAsync(doctor.HospitalId);

            var result = mapper.Map<DoctorProfileInfoDTO>(doctor);
            result.HospitalName = hospital.Name;
            result.FirstName = doctor.User.FirstName;
            result.LastName = doctor.User.LastName;
            result.Email = doctor.User.Email;
            result.PhoneNumber = doctor.User.PhoneNumber;
            return result;
            /*return new DoctorProfileInfoDTO
            {
                Id = doctor.UserId,
                Email = doctor.User.Email,
                FirstName = doctor.User.FirstName,
                LastName = doctor.User.LastName,
                Position = doctor.Position,
                OnHoliday = doctor.OnHoliday,
                Blocked = doctor.User.Blocked ? 1 : 0,
                ScheduleId = doctor.ScheduleId,
                Education = doctor.Education,
                Experience = doctor.Experience,
                PhoneNumber = doctor.User.PhoneNumber,
                RegistrationDate = regDate,
                Price = doctor.Price,
                HospitalName = hospital.Name,
                DateOfBirth = birthDate,
                Sex = doctor.Sex,
                HospitalId = doctor.HospitalId
            };*/
        }

        public async Task<DoctorProfileInfoDTO> GetDoctorInfoByEmailAsync(string email)
        {
            var doctor = await doctorRepository.GetByEmailAsync(email);
            return await GetDoctorInfoAsync(doctor.UserId); 
        }

        public IEnumerable<PatientInfoDTO> GetDoctorPatientsByEmail(string email)
        {
            var patients = doctorPatientRepository.GetDoctorPatientsByEmail(email)
                .Select(p => new PatientInfoDTO
                {
                    Id = p.UserId,
                    Email = p.User.Email,
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName,
                    Blocked = p.User.Blocked ? 1 : 0,
                    PhoneNumber = p.User.PhoneNumber,
                    RegistrationDate = p.User.RegistrationDate.ToString("d")
                });
            var pat1 = patients
                .GroupBy(p => p.Id);
            var pat2 = pat1
                .Select(p => p.First());
            return pat2;
        }

        public IEnumerable<string> GetDoctorsEmailsByHospitalId(int id)
        {
            var doctors = doctorRepository.GetDoctors(id)
                .Select(doc => doc.User.Email);
            return doctors;
        }

        public async Task<ScheduleInfoDTO> GetScheduleByEmailAsync(string email)
        {
            var doctor = await doctorRepository.GetByEmailAsync(email);
            var schedule = await scheduleService.GetByIdAsync((int)doctor.ScheduleId);
            return mapper.Map<ScheduleInfoDTO>(schedule);
        }

        public async Task UpdateDoctorAsync(DoctorProfileInfoDTO doctor)
        {
            User user = await userRepository.FindByEmailAsync(doctor.Email);
            user.FirstName = doctor.FirstName;
            user.LastName = doctor.LastName;
            user.PhoneNumber = doctor.PhoneNumber;
            await userRepository.UpdateAsync(user);

            Doctor doctorTemp = await doctorRepository.GetByEmailAsync(doctor.Email);
            doctorTemp.Position = doctor.Position;
            doctorTemp.OnHoliday = doctor.OnHoliday;
            doctorTemp.Price = doctor.Price;
            doctorTemp.Education = doctor.Education;
            doctorTemp.Experience = doctor.Experience;
            if (doctor.ScheduleId != 0)
                doctorTemp.ScheduleId = doctor.ScheduleId;
            doctorRepository.Update(doctorTemp);
            await doctorRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FreeDateTimesDTO>> GetFreeDateTimesByDoctorEmailAsync(string email)
        {
            var doctor = await doctorRepository.GetByEmailAsync(email);
            if (doctor.OnHoliday || doctor.User.Blocked)
                return null;
            var schedId = doctor.ScheduleId;
            Schedule schedule = await scheduleService.GetByIdAsync((int)schedId);
            TimeSpan startTime = TimeSpan.Parse(schedule.StartTime.ToString("t"));
            TimeSpan endTime = TimeSpan.Parse(schedule.EndTime.ToString("t"));

            var appointments = appointmentService.GetFutureAppointmentsByDoctorEmail(email)
                .Where(ap => ap.Canceled != true)
                .Select(dt => dt.DateTimeAppointment)
                .ToArray();

            IDictionary<string, IList<string>> busyDateTime = new Dictionary<string, IList<string>>();
            foreach (var appoint in appointments)
            {
                string date = appoint.Split(' ')[0];
                string time = appoint.Split(' ')[1];
                if (!busyDateTime.ContainsKey(date))
                    busyDateTime.Add(date, new List<string>());
                busyDateTime[date].Add(time);
            }

            IDictionary<string, IList<string>> allDateTime = new Dictionary<string, IList<string>>();
            DateTimeOffset dateTimeNow = DateTimeOffset.Now;

            for (int i = 0; i < 7; i++)
            {
                string date = dateTimeNow.ToString("d");
                string time = dateTimeNow.ToString("t");
                allDateTime.Add(date, new List<string>());
                TimeSpan tempStart = startTime;
                while (tempStart.CompareTo(endTime) < 0)
                {
                    if (tempStart.CompareTo(TimeSpan.Parse(time)) < 0 && i == 0)
                    {
                        tempStart = tempStart.Add(new TimeSpan(2, 0, 0));
                        continue;
                    }
                    allDateTime[date].Add(DateTimeOffset.Parse(tempStart.ToString()).ToString("t"));
                    tempStart = tempStart.Add(new TimeSpan(2, 0, 0));
                }
                dateTimeNow = dateTimeNow.AddDays(1);
            }

            IDictionary<string, IList<string>> freeDateTime = new Dictionary<string, IList<string>>();

            foreach (var dateTimeAll in allDateTime)
            {
                string key = dateTimeAll.Key;
                freeDateTime.Add(key, new List<string>());
                if (busyDateTime.ContainsKey(key))
                    freeDateTime[key] = dateTimeAll.Value.Except(busyDateTime[key]).ToList();
                else
                    freeDateTime[key] = dateTimeAll.Value.ToList();
            }

            var result = freeDateTime.Select(dt => new FreeDateTimesDTO
            {
                Date = dt.Key,
                Times = dt.Value
            });

            if (result.First().Times.Count() == 0)
                result = result.Skip(1);

            return result;
        }

        public async Task ChangeDoctorScheduleAsync(ScheduleInfoDoctorDTO infoDTO)
        {
            string numDays = scheduleService.FromDaysToNumbers(infoDTO.WorkDays);
            Schedule schedule = await scheduleService.FindByDescription(infoDTO.StartTime, infoDTO.EndTime, numDays);
            Doctor doctorTemp = await doctorRepository.GetByEmailAsync(infoDTO.DoctorEmail);
            if (schedule != null)
                doctorTemp.ScheduleId = schedule.Id;
            else
            {
                int schedId = await scheduleService.AddScheduleAsync(new ScheduleDTO
                {
                    StartTime = infoDTO.StartTime,
                    EndTime = infoDTO.EndTime,
                    WorkDays = numDays
                });
                doctorTemp.ScheduleId = schedId;
            }
            doctorRepository.Update(doctorTemp);
            await doctorRepository.SaveChangesAsync();
        }

        public IEnumerable<string> GetPatientsEmailsByDoctorEmail(string email)
        {
            var patientsEmails = doctorPatientRepository.GetDoctorPatientsByEmail(email)
                .Select(p => p.User.Email)
                .Distinct();
            return patientsEmails;
        }
    }
}
