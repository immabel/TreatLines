using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.DTOs.HospitalCreate;
using TreatLines.BLL.Exceptions;
using TreatLines.BLL.Interfaces;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;

namespace TreatLines.BLL.Services
{
    public class HospitalRegistrationRequestsService : IHospitalRegistrationRequestsService
    {
        private readonly IRepository<Hospital> hospitalRepository;

        private readonly IAuthService authService;

        private readonly IRepository<RequestToCreateHospital> requestsHospitalRepository;

        private readonly IMailService mailService;

        private readonly IMapper mapper;

        public HospitalRegistrationRequestsService(
            IRepository<RequestToCreateHospital> requestsHospitalRepository,
            IMailService emailService,
            IMapper mapper,
            IRepository<Hospital> hospitalRepository,
            IAuthService authService)
        {
            this.authService = authService;
            this.requestsHospitalRepository = requestsHospitalRepository;
            this.mailService = emailService;
            this.hospitalRepository = hospitalRepository;
            this.mapper = mapper;
        }

        public async Task<HospitalCreationResultDTO> CreateHospitalAsync(RequestToCreateHospitalDTO createRequestDTO)
        {
            var hospital = new Hospital
            {
                Name = createRequestDTO.HospitalName,
                Address = createRequestDTO.Address,
                Country = createRequestDTO.Country,
                City = createRequestDTO.City,
                CreationDate = createRequestDTO.HospitalCreationDate
            };
            await hospitalRepository.AddAsync(hospital);
            await hospitalRepository.SaveChangesAsync();

            HospitalAdminRegistrationDTO adminRegisterRequest = new HospitalAdminRegistrationDTO
            {
                FirstName = createRequestDTO.SubmitterFirstName,
                LastName = createRequestDTO.SubmitterLastName,
                Email = createRequestDTO.Email,
                Password = "Qwerty12345",
                PhoneNumber = createRequestDTO.PhoneNumber,
                HospitalId = hospital.Id
            };
            await authService.RegisterHospitalAdminAsync(adminRegisterRequest);

            return new HospitalCreationResultDTO
            {
                HospitalId = hospital.Id,
                HospitalName = hospital.Name,
                AdminEmail = adminRegisterRequest.Email,
                AdminPassword = adminRegisterRequest.Password
            };
        }

        public async Task AddRequestAsync(RequestToCreateHospitalDTO creationInfo)
        {
            RequestToCreateHospital createRequest = mapper.Map<RequestToCreateHospital>(creationInfo);
            createRequest.DateOfRequestCreation = DateTime.Now;
            await requestsHospitalRepository.AddAsync(createRequest);
            await requestsHospitalRepository.SaveChangesAsync();
        }

        public async Task ApproveRequestAsync(int id)
        {
            RequestToCreateHospital request = await requestsHospitalRepository.GetByIdAsync(id);
            if (request == null)
            {
                throw new BadRequestException("Creation request doesn't exist!");
            }

            RequestToCreateHospitalDTO registerDto = mapper.Map<RequestToCreateHospitalDTO>(request);
            HospitalCreationResultDTO result = await CreateHospitalAsync(registerDto);

            // TODO: load html letter template and fill it in
            await mailService.SendAsync(
                receiver: result.AdminEmail,
                subject: $"{result.HospitalName} registration",
                bodyHtml: "Your hospital is registered! Use these credentials to sign in to the system:" +
                          $"<br>Email: {result.AdminEmail}<br>Password: {result.AdminPassword}");

            requestsHospitalRepository.Remove(request);
            await requestsHospitalRepository.SaveChangesAsync();
        }

        public async Task RejectRequestAsync(int id)
        {
            RequestToCreateHospital request = await requestsHospitalRepository.GetByIdAsync(id);
            if (request == null)
            {
                throw new BadRequestException("Creation request doesn't exist!");
            }

            // TODO: Load email HTML template from file and fill it in
            await mailService.SendAsync(
                request.Email,
                "Your request has been denied",
                $"{request.HospitalName} won't be registered");

            requestsHospitalRepository.Remove(request);
            await requestsHospitalRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<RequestToCreateHospitalViewDTO>> GetAllRequestsAsync()
        {
            IEnumerable<RequestToCreateHospital> requests = await requestsHospitalRepository.Find(_ => true);
            return mapper.Map<IEnumerable<RequestToCreateHospitalViewDTO>>(requests);
        }
    }
}
