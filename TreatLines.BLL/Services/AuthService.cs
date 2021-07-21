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

namespace TreatLines.BLL.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserRepository usersRepository;

        private readonly IRepository<Hospital> hospitalRepository;

        private readonly IRepository<HospitalAdmin> hospitalAdminRepository;

        private readonly IDoctorRepository doctorRepository;

        private readonly IRepository<Patient> patientRepository;

        private readonly IRepository<DoctorPatient> doctorPatientRepository;

        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public AuthService(
            UserRepository usersRepository,
            IRepository<Hospital> hospitalRepository,
            IRepository<HospitalAdmin> hospitalAdminRepository,
            IDoctorRepository doctorRepository,
            IRepository<Patient> patientRepository,
            IRepository<DoctorPatient> doctorPatientRepository,
            IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.usersRepository = usersRepository;
            this.hospitalRepository = hospitalRepository;
            this.hospitalAdminRepository = hospitalAdminRepository;
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;
            this.doctorPatientRepository = doctorPatientRepository;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request)
        {
            User user = await usersRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new BadRequestException("User does not exist!");
            }

            bool passwordIsCorrect = await usersRepository.CheckPasswordAsync(user, request.Password);
            if (!passwordIsCorrect)
            {
                throw new ForbiddenException("Password is incorrect!");
            }
            Claim[] userClaims = await GetAuthTokenClaimsForUserAsync(user);

            var accessToken = jwtAuthenticationManager.GenerateTokenForClaims(userClaims);

            return new LoginResponseDTO
            {
                UserId = user.Id,
                Email = user.Email,
                Token = accessToken,
                Role = userClaims[1].Value
            };
        }

        public async Task RegisterHospitalAdminAsync(HospitalAdminRegistrationDTO request)
        {
            Hospital hospital = await hospitalRepository.GetByIdAsync(request.HospitalId);
            if (hospital == null)
            {
                throw new BadRequestException("Hospital doesn't exist!");
            }

            User hospitalAdminUser = await RegisterAsync(request);
            await usersRepository.AddUserToRoleAsync(hospitalAdminUser, Rolename.HOSPITAL_ADMIN);
            await hospitalAdminRepository.AddAsync(new HospitalAdmin
            {
                UserId = hospitalAdminUser.Id,
                HospitalId = request.HospitalId
            });
            await hospitalAdminRepository.SaveChangesAsync();
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

        public async Task RegisterDoctorAsync(DoctorRegistrationDTO request)
        {
            Hospital hospital = await hospitalRepository.GetByIdAsync(request.HospitalId);
            if (hospital == null)
            {
                throw new BadRequestException("Hospital doesn't exist!");
            }

            User doctor = await RegisterAsync(request);
            await usersRepository.AddUserToRoleAsync(doctor, Rolename.DOCTOR);
            await doctorRepository.AddAsync(new Doctor
            {
                UserId = doctor.Id,
                Position = request.Position,
                OnHoliday = request.OnHoliday,
                HospitalId = request.HospitalId,
                ScheduleId = request.ScheduleId
            });
            await doctorRepository.SaveChangesAsync();
        }

        public async Task RegisterPatientAsync(PatientRegistrationDTO request)
        {
            User patient = await RegisterAsync(request);
            await usersRepository.AddUserToRoleAsync(patient, Rolename.PATIENT);
            await patientRepository.AddAsync(new Patient
            {
                UserId = patient.Id,
                BloodType = request.BloodType,
                Sex = request.Sex
            });
            await patientRepository.SaveChangesAsync();

            Doctor doctor = await doctorRepository.GetByIdAsync(request.DoctorId);
            if (doctor != null)
            {
                await doctorPatientRepository.AddAsync(new DoctorPatient
                {
                    DoctorId = request.DoctorId,
                    PatientId = doctor.User.Id
                });
                await doctorPatientRepository.SaveChangesAsync();
            }
        }
    }
}
