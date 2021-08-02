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

namespace TreatLines.BLL.Services
{
    public sealed class HospitalService : IHospitalService
    {
        private readonly UserRepository userRepository;

        private readonly IRepository<Hospital> hospitalRepository;

        private readonly IDoctorRepository doctorRepository;

        private readonly IHospitalAdminRepository hospitalAdminRepository;

        private readonly IMapper mapper;

        public HospitalService(
            UserRepository userRepository,
            IRepository<Hospital> hospitalRepository,
            IDoctorRepository doctorRepository,
            IHospitalAdminRepository hospitalAdminRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.hospitalRepository = hospitalRepository;
            this.doctorRepository = doctorRepository;
            this.hospitalAdminRepository = hospitalAdminRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<HospitalInfoDTO>> GetHospitalsAsync()
        {
            var hospitals = await hospitalRepository.GetAllAsync();
            return mapper.Map<IEnumerable<HospitalInfoDTO>>(hospitals);
        }

        public async Task<bool> DeleteHospitalByIdAsync(int hospitalId)
        {
            var hospital = await hospitalRepository.GetByIdAsync(hospitalId);
            if (hospital == null)
            {
                return false;
            }
            hospitalRepository.Remove(hospital);
            await hospitalRepository.SaveChangesAsync();
            return true;
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
            var hospitalId = GetHospitalIdByHospitalAdminId(id);
            var hAdmins = GetHospitalAdminsById(hospitalId);
            return hAdmins;
        }

        public int GetHospitalIdByHospitalAdminId(string id)
        {
            return hospitalAdminRepository.GetHospitalByHospitalAdminId(id).Id;
        }

        public async Task BlockUserAsync(string email)
        {
            var user = await userRepository.FindByEmailAsync(email);
            user.Blocked = user.Blocked ? false : true;
            await userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(string email)
        {
            var user = await userRepository.FindByEmailAsync(email);
            await userRepository.DeleteAsync(user);
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
    }
}
