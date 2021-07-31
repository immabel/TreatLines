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
        private readonly UserRepository usersRepository;

        private readonly IHospitalAdminRepository hospitalAdminRepository;

        private readonly IDoctorRepository doctorRepository;

        private readonly IPatientRepository patientRepository;

        private readonly IRepository<Schedule> scheduleRepository;

        private readonly IRepository<Hospital> hospitalRepository;

        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public AuthService(
            UserRepository usersRepository,
            IHospitalAdminRepository hospitalAdminRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IRepository<Schedule> scheduleRepository,
            IRepository<Hospital> hospitalRepository,
            IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.usersRepository = usersRepository;
            this.hospitalRepository = hospitalRepository;
            this.hospitalAdminRepository = hospitalAdminRepository;
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;
            this.scheduleRepository = scheduleRepository;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request)
        {
            User user = await usersRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new BadRequestException("User does not exist!");
            }
            if (user.Blocked)
                return null;

            bool passwordIsCorrect = await usersRepository.CheckPasswordAsync(user, request.Password);
            if (!passwordIsCorrect)
            {
                throw new ForbiddenException("Password is incorrect!");
            }
            Claim[] userClaims = await GetAuthTokenClaimsForUserAsync(user);

            var accessToken = jwtAuthenticationManager.GenerateTokenForClaims(userClaims);

            string role = userClaims[1].Value;
            int hospitalId = 0;

            if (role.Equals("HospitalAdmin"))
                hospitalId = hospitalAdminRepository.GetHospitalByHospitalAdminId(user.Id).Id;
            else if (role.Equals("Doctor"))
                hospitalId = doctorRepository.GetByIdAsync(user.Id).Result.HospitalId;
            else if (role.Equals("Patient"))
                hospitalId = patientRepository.GetByIdAsync(user.Id).Result.HospitalId;

            return new LoginResponseDTO
            {
                UserId = user.Id,
                Email = user.Email,
                Token = accessToken,
                Role = role,
                HospitalId = hospitalId
            };
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
            await usersRepository.AddUserToRoleAsync(hospitalAdminUser, Rolename.HOSPITAL_ADMIN);
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
            };
            var registerResult = await usersRepository.TryCreateAsync(
                user: user,
                password: request.Password);

            if (!registerResult.Succeeded)
            {
                throw new BadRequestException(registerResult.Errors.First().Description);
            }

            return user;
        }

        private async Task<Claim[]> GetAuthTokenClaimsForUserAsync(User user)
        {
            IList<string> userRoles = await usersRepository.GetRolesAsync(user);
            var userClaims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRoles.FirstOrDefault())
            };
            return userClaims;
        }

        public string MySort(string str)
        {
            int[] arr = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
                arr[i] = str[i];
            Array.Sort(arr);
            str = arr.ToString();
            return str;
        }

        public async Task<RegistrationResponseDTO> RegisterDoctorAsync(DoctorRegistrationDTO request)
        {
            Hospital hospital = await hospitalRepository.GetByIdAsync(request.HospitalId);
            if (hospital == null)
            {
                throw new BadRequestException("Hospital doesn't exist!");
            }

            Schedule schedule = new Schedule
            {
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                WorkDays = request.WorkDays
            };
            await scheduleRepository.AddAsync(schedule);
            await scheduleRepository.SaveChangesAsync();

            request.Password = "Qwerty12345";

            User doctor = await RegisterAsync(request);
            await usersRepository.AddUserToRoleAsync(doctor, Rolename.DOCTOR);
            await doctorRepository.AddAsync(new Doctor
            {
                UserId = doctor.Id,
                Position = request.Position,
                OnHoliday = request.OnHoliday,
                HospitalId = request.HospitalId,
                ScheduleId = schedule.Id
            });
            await doctorRepository.SaveChangesAsync();

            return new RegistrationResponseDTO { Email = doctor.Email, Password = request.Password };
        }

        public async Task<RegistrationResponseDTO> RegisterPatientAsync(PatientRegistrationDTO request)
        {
            request.Password = "Qwerty12345";

            User patient = await RegisterAsync(request);
            await usersRepository.AddUserToRoleAsync(patient, Rolename.PATIENT);
            await patientRepository.AddAsync(new Patient
            {
                UserId = patient.Id,
                BloodType = request.BloodType,
                Sex = request.Sex,
                HospitalId = request.HospitalId
            });
            await patientRepository.SaveChangesAsync();

            return new RegistrationResponseDTO { Email = patient.Email, Password = request.Password };
        }
    }
}

