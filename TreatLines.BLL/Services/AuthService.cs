using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;
using TreatLines.DAL.Repositories;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.Exceptions;
using TreatLines.DAL.Constants;
using System;

namespace TreatLines.BLL.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserRepository userRepository;

        private readonly IHospitalAdminRepository hospitalAdminRepository;

        private readonly IDoctorRepository doctorRepository;

        private readonly IPatientRepository patientRepository;

        private readonly IRepository<Schedule> scheduleRepository;

        private readonly IRepository<Hospital> hospitalRepository;

        public AuthService(
            UserRepository userRepository,
            IHospitalAdminRepository hospitalAdminRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IRepository<Schedule> scheduleRepository,
            IRepository<Hospital> hospitalRepository)
        {
            this.userRepository = userRepository;
            this.hospitalRepository = hospitalRepository;
            this.hospitalAdminRepository = hospitalAdminRepository;
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;
            this.scheduleRepository = scheduleRepository;
        }

        public async Task<RegistrationResponseDTO> RegisterHospitalAdminAsync(HospitalAdminRegistrationDTO request)
        {
            Hospital hospital = await hospitalRepository.GetByIdAsync(request.HospitalId);
            if (hospital == null)
            {
                throw new BadRequestException("Hospital doesn't exist!");
            }

            request.Password = "Qwerty12345";

            User hospitalAdminUser = await RegisterAsync(request);
            await userRepository.AddUserToRoleAsync(hospitalAdminUser, Rolename.HOSPITAL_ADMIN);
            await hospitalAdminRepository.AddAsync(new HospitalAdmin
            {
                UserId = hospitalAdminUser.Id,
                HospitalId = request.HospitalId
            });
            await hospitalAdminRepository.SaveChangesAsync();

            return new RegistrationResponseDTO { Email = hospitalAdminUser.Email, Password = request.Password };
        }

        private async Task<User> RegisterAsync(RegistrationDTO request)
        {
            var user = new User
            {
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                RegistrationDate = DateTimeOffset.Now
            };
            var registerResult = await userRepository.TryCreateAsync(
                user: user,
                password: request.Password);

            if (!registerResult.Succeeded)
            {
                throw new BadRequestException(registerResult.Errors.First().Description);
            }

            return user;
        }

        public async Task<RegistrationResponseDTO> RegisterDoctorAsync(DoctorRegistrationDTO request)
        {
            Hospital hospital = await hospitalRepository.GetByIdAsync(request.HospitalId);
            if (hospital == null)
            {
                throw new BadRequestException("Hospital doesn't exist!");
            }

            request.Password = "Qwerty12345";

            User doctor = await RegisterAsync(request);
            await userRepository.AddUserToRoleAsync(doctor, Rolename.DOCTOR);
            await doctorRepository.AddAsync(new Doctor
            {
                UserId = doctor.Id,
                Position = request.Position,
                OnHoliday = false,
                HospitalId = request.HospitalId,
                ScheduleId = request.ScheduleId,
                Education = request.Education,
                Experience = request.Experience,
                DateOfBirth = request.DateOfBirth,
                Price = request.Price,
                Sex = request.Sex
            });
            await doctorRepository.SaveChangesAsync();

            return new RegistrationResponseDTO { Email = doctor.Email, Password = request.Password };
        }

        public async Task<RegistrationResponseDTO> RegisterPatientAsync(PatientRegistrationDTO request)
        {
            request.Password = "Qwerty12345";

            User patient = await RegisterAsync(request);
            await userRepository.AddUserToRoleAsync(patient, Rolename.PATIENT);
            await patientRepository.AddAsync(new Patient
            {
                UserId = patient.Id,
                BloodType = request.BloodType,
                Sex = request.Sex,
                DateOfBirth = request.DateOfBirth,
                HospitalId = request.HospitalId
            });
            await patientRepository.SaveChangesAsync();

            return new RegistrationResponseDTO { Email = patient.Email, Password = request.Password };
        }
    }
}

