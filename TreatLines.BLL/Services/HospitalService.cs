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

namespace TreatLines.BLL.Services
{
    public sealed class HospitalService : IHospitalService
    {
        private readonly UserRepository userRepository;

        private readonly IRepository<Hospital> hospitalRepository;

        private readonly IDoctorRepository doctorRepository;

        private readonly IHospitalAdminRepository hospitalAdminRepository;

        private readonly IPatientRepository patientRepository;

        private readonly IMapper mapper;

        public HospitalService(
            UserRepository userRepository,
            IRepository<Hospital> hospitalRepository,
            IDoctorRepository doctorRepository,
            IHospitalAdminRepository hospitalAdminRepository,
            IPatientRepository patientRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.hospitalRepository = hospitalRepository;
            this.doctorRepository = doctorRepository;
            this.hospitalAdminRepository = hospitalAdminRepository;
            this.patientRepository = patientRepository;
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
                    PhoneNumber = ha.User.PhoneNumber
                });
            return admins;
        }

        public IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(string id)
        {
            var hospitalId = hospitalAdminRepository.GetHospitalByHospitalAdminId(id).Id;
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

        public async Task<HospitalAdminInfoDTO> GetHospitalAdminProfileInfoAsync(string id)
        {
            var user = await userRepository.FindByIdAsync(id);
            string hospName = hospitalAdminRepository.GetHospitalByHospitalAdminId(id).Name;
            return new HospitalAdminInfoDTO
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                HospitalName = hospName
            };
        }

        public IEnumerable<DoctorInfoDTO> GetDoctorsByHospital(Hospital hospital)
        {
            var doctors = doctorRepository.GetDoctors(hospital.Id)
                .Select(doc => new DoctorInfoDTO
                {
                    Email = doc.User.Email,
                    FirstName = doc.User.FirstName,
                    LastName = doc.User.LastName,
                    //HospitalName = hospital.Name,
                    Position = doc.Position,
                    OnHoliday = doc.OnHoliday,
                    Blocked = doc.User.Blocked ? 1 : 0,
                    Sex = doc.Sex
                });
            return doctors;
        }

        public IEnumerable<DoctorInfoDTO> GetDoctorsByHospitalAdminId(string id)
        {
            var hospital = hospitalAdminRepository.GetHospitalByHospitalAdminId(id);
            var doctors = GetDoctorsByHospital(hospital);
            return doctors;
        }

        public IEnumerable<PatientInfoDTO> GetPatientsByHospitalAdminId(string id)
        {
            var hospitalId = hospitalAdminRepository.GetHospitalByHospitalAdminId(id).Id;
            var patients = patientRepository.GetAllWithUserAsync()
                .Result
                .Where(p => p.HospitalId == hospitalId)
                .Select(p => new PatientInfoDTO
                {
                    Id = p.UserId,
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName,
                    Email = p.User.Email,
                    Blocked = p.User.Blocked ? 1 : 0
                });
            return patients;
        }
    }
}
