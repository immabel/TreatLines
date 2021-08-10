using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;
using TreatLines.BLL.Interfaces;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;
using TreatLines.DAL.Repositories;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.DTOs.Schedule;

namespace TreatLines.BLL.Services
{
    public sealed class HospitalService : IHospitalService
    {
        private readonly UserRepository userRepository;

        private readonly IRepository<Hospital> hospitalRepository;

        private readonly IDoctorRepository doctorRepository;

        private readonly IHospitalAdminRepository hospitalAdminRepository;

        private readonly IPatientRepository patientRepository;

        //private readonly IScheduleService scheduleService;

        private readonly IMapper mapper;

        public HospitalService(
            UserRepository userRepository,
            IRepository<Hospital> hospitalRepository,
            IDoctorRepository doctorRepository,
            IHospitalAdminRepository hospitalAdminRepository,
            IPatientRepository patientRepository,
            //IScheduleService scheduleService,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.hospitalRepository = hospitalRepository;
            this.doctorRepository = doctorRepository;
            this.hospitalAdminRepository = hospitalAdminRepository;
            this.patientRepository = patientRepository;
            //this.scheduleService = scheduleService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<HospitalInfoDTO>> GetHospitalsAsync()
        {
            var hospitals = await hospitalRepository.GetAllAsync();
            return mapper.Map<IEnumerable<HospitalInfoDTO>>(hospitals);
        }

        public async Task BlockHospitalByIdAsync(int hospitalId)
        {
            var hospital = await hospitalRepository.GetByIdAsync(hospitalId);
            if (hospital == null)
            {
                return;
            }
            hospital.Blocked = hospital.Blocked ? false : true;
            hospitalRepository.Update(hospital);
            await hospitalRepository.SaveChangesAsync();

            /*if (hospital.Blocked)
            {

            }*/
        }

        public IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(int hospitalId)
        {
            var admins = hospitalAdminRepository.GetAllHospitalAdminsAsync()
                .Result
                .Where(ha => ha.HospitalId == hospitalId)
                .Select(ha => new HospitalAdminInfoDTO
                {
                    Id = ha.UserId,
                    Email = ha.User.Email,
                    FirstName = ha.User.FirstName,
                    LastName = ha.User.LastName,
                    HospitalName = ha.Hospital.Name,
                    HospitalId = ha.HospitalId,
                    Blocked = ha.User.Blocked ? 1 : 0,
                    PhoneNumber = ha.User.PhoneNumber,
                    RegistrationDate = ha.User.RegistrationDate.ToString("d")
                });
            return admins;
        }

        public IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsByHospAdmin(string email)
        {
            var hospitalId = GetHospitalIdByHospAdmin(email);
            var hAdmins = GetHospitalAdminsById(hospitalId);
            return hAdmins;
        }

        public async Task BlockUserAsync(string id)
        {
            var user = await userRepository.FindByIdAsync(id);
            user.Blocked = user.Blocked ? false : true;
            await userRepository.UpdateAsync(user);
        }

        public async Task<HospitalInfoDTO> GetHospitalInfoByIdAsync(int id)
        {
            var hospital = await hospitalRepository.GetByIdAsync(id);
            return mapper.Map<HospitalInfoDTO>(hospital);
        }

        public int GetDoctorsCountById(int hospitalId)
        {
            int docCount = doctorRepository.GetAllAsync().Result.Count();
            return docCount;
        }

        public async Task<HospitalAdminInfoDTO> GetHospitalAdminProfileInfoAsync(string email)
        {
            var user = await userRepository.FindByEmailAsync(email);
            string hospName = hospitalAdminRepository.GetHospitalByHospitalAdminId(user.Id).Name;
            return new HospitalAdminInfoDTO
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                HospitalName = hospName,
                RegistrationDate = user.RegistrationDate.ToString("d")
            };
        }

        public IEnumerable<DoctorInfoDTO> GetDoctorsByHospital(Hospital hospital)
        {
            var doctors = doctorRepository.GetDoctors(hospital.Id)
                .Select(doc => new DoctorInfoDTO
                {
                    Id = doc.UserId,
                    Email = doc.User.Email,
                    FirstName = doc.User.FirstName,
                    LastName = doc.User.LastName,
                    //HospitalName = hospital.Name,
                    Position = doc.Position,
                    OnHoliday = doc.OnHoliday,
                    Blocked = doc.User.Blocked ? 1 : 0,
                    Sex = doc.Sex,
                    RegistrationDate = doc.User.RegistrationDate.ToString("d"),
                    PhoneNumber = doc.User.PhoneNumber
                });
            return doctors;
        }

        public IEnumerable<DoctorInfoDTO> GetDoctorsByHospitalAdmin(string email)
        {
            var id = userRepository.FindByEmailAsync(email).Result.Id;
            var hospital = hospitalAdminRepository.GetHospitalByHospitalAdminId(id);
            var doctors = GetDoctorsByHospital(hospital);
            return doctors;
        }

        public IEnumerable<PatientInfoDTO> GetPatientsByHospitalAdmin(string email)
        {
            var hospitalId = GetHospitalIdByHospAdmin(email);
            var patients = patientRepository.GetAllWithUserAsync()
                .Result
                .Where(p => p.HospitalId == hospitalId)
                .Select(p => new PatientInfoDTO
                {
                    Id = p.UserId,
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName,
                    Email = p.User.Email,
                    Blocked = p.User.Blocked ? 1 : 0,
                    PhoneNumber = p.User.PhoneNumber,
                    RegistrationDate = p.User.RegistrationDate.ToString("d")
                });
            return patients;
        }

        public async Task UpdateHospitalAdminInfoAsync(HospitalAdminInfoDTO adminDTO)
        {
            User user = await userRepository.FindByEmailAsync(adminDTO.Email);
            user.FirstName = adminDTO.FirstName;
            user.LastName = adminDTO.LastName;
            user.PhoneNumber = adminDTO.PhoneNumber;
            await userRepository.UpdateAsync(user);
        }

        public int GetHospitalIdByHospAdmin(string email)
        {
            var id = userRepository.FindByEmailAsync(email).Result.Id;
            var hospitalId = hospitalAdminRepository.GetHospitalByHospitalAdminId(id).Id;
            return hospitalId;
        }

        /*public IEnumerable<ScheduleInfoDTO> GetSchedulesByHospAdmin(string email)
        {
            int hospId = GetHospitalIdByHospAdmin(email);
            var result = scheduleService.GetSchedules(hospId);
            return result;
        }*/
    }
}
