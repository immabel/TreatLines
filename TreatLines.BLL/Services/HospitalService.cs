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

        private readonly IHospitalAdminRepository hospitalAdminRepository;

        private readonly IMapper mapper;

        public HospitalService(
            UserRepository userRepository,
            IRepository<Hospital> hospitalRepository,
            IHospitalAdminRepository hospitalAdminRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.hospitalRepository = hospitalRepository;
            this.hospitalAdminRepository = hospitalAdminRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<HospitalViewDTO>> GetHospitals()
        {
            var hospitals = await hospitalRepository.GetAllAsync();
            return mapper.Map<IEnumerable<HospitalViewDTO>>(hospitals);
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

        public IEnumerable<HospitalAdminInfoDTO> GetHospitalAdmins()
        {
            var admins = hospitalAdminRepository.GetAllHospitalAdminsAsync()
                .Result
                .Select(ha => new HospitalAdminInfoDTO
                {
                    Id = ha.UserId,
                    Email = ha.User.Email,
                    FirstName = ha.User.FirstName,
                    LastName = ha.User.LastName,
                    HospitalName = ha.Hospital.Name,
                    HospitalId = ha.HospitalId,
                    Blocked = ha.User.Blocked ? 1 : 0
                });
            return admins;
        }

        public IEnumerable<HospitalAdminInfoDTO> GetHospitalAdminsById(string id)
        {
            var hospitalId = GetHospitalIdByHospitalAdminId(id);
            var hAdmins = GetHospitalAdmins().Where(hadm => hadm.HospitalId == hospitalId);
            return hAdmins;
        }

        public int GetHospitalIdByHospitalAdminId(string id)
        {
            return hospitalAdminRepository.GetHospitalByHospitalAdminId(id).Id;
        }

        public async Task BlockUser(string email)
        {
            var user = await userRepository.FindByEmailAsync(email);
            user.Blocked = user.Blocked ? false : true;
            await userRepository.UpdateAsync(user);
        }

        public async Task DeleteUser(string email)
        {
            var user = await userRepository.FindByEmailAsync(email);
            await userRepository.DeleteAsync(user);
        }
    }
}
