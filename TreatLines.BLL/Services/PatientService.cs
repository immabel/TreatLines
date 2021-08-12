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

        private readonly IPatientRepository patientRepository;

        private readonly IMapper mapper;

        public PatientService(
            UserRepository userRepository,
            IPatientRepository patientRepository,
            IMapper mapper
            )
        {
            this.userRepository = userRepository;
            this.patientRepository = patientRepository;
            this.mapper = mapper;
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
            user.PhoneNumber = patient.PhoneNumber;
            await userRepository.UpdateAsync(user);

            Patient patientTemp = await patientRepository.GetByEmailAsync(patient.Email);
            patientTemp.BloodType = patient.BloodType;
            patientTemp.Sex = patient.Sex;
            patientTemp.Discount = patient.Discount;
            patientRepository.Update(patientTemp);
            await patientRepository.SaveChangesAsync();
        }

        public async Task<PatientInfoDTO> GetPatientInfoByEmailAsync(string email)
        {
            var patient = await patientRepository.GetByEmailAsync(email);
            PatientInfoDTO patientInfo = mapper.Map<PatientInfoDTO>(patient);
            patientInfo.FirstName = patient.User.FirstName;
            patientInfo.LastName = patient.User.LastName;
            patientInfo.PhoneNumber = patient.User.PhoneNumber;
            patientInfo.Email = patient.User.Email;
            patientInfo.RegistrationDate = patient.User.RegistrationDate.ToString("d");
            //patientInfo.HospitalName = hospitalRepository.GetByIdAsync(patient.HospitalId).Result.Name;            
            return patientInfo;
        }

        public IEnumerable<string> GetPatientsEmailsByHospitalId(int id)
        {
            IEnumerable<string> patEms = patientRepository.GetAllWithUserAsync()
                .Result
                .Where(p => p.HospitalId == id)
                .Select(dp => dp.User.Email);
            return patEms;
        }
    }
}
