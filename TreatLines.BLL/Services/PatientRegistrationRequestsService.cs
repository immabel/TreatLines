using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.DTOs.PatientCreate;
using TreatLines.BLL.Exceptions;
using TreatLines.BLL.Interfaces;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;

namespace TreatLines.BLL.Services
{
    public class PatientRegistrationRequestsService : IPatientRegistrationRequestsService
    {
        private readonly IAuthService authService;

        private readonly IRepository<RequestToCreatePatient> requestsPatientRepository;

        private readonly IRepository<Hospital> hospitalRepository;

        private readonly IMailService mailService;

        private readonly IMapper mapper;

        public PatientRegistrationRequestsService(
            IMailService emailService,
            IMapper mapper,
            IRepository<RequestToCreatePatient> requestsPatientRepository,
            IRepository<Hospital> hospitalRepository,
            IAuthService authService)
        {
            this.authService = authService;
            this.requestsPatientRepository = requestsPatientRepository;
            this.hospitalRepository = hospitalRepository;
            this.mailService = emailService;
            this.mapper = mapper;
        }

        public async Task AddRequestAsync(RequestToCreatePatientDTO creationInfo)
        {
            RequestToCreatePatient createRequest = mapper.Map<RequestToCreatePatient>(creationInfo);
            createRequest.DateOfRequestCreation = DateTime.Now;
            await requestsPatientRepository.AddAsync(createRequest);
            await requestsPatientRepository.SaveChangesAsync();
        }

        public async Task ApproveRequestAsync(int id)
        {
            RequestToCreatePatient request = await requestsPatientRepository.GetByIdAsync(id);
            if (request == null)
            {
                throw new BadRequestException("Creation request doesn't exist!");
            }

            var result = await authService.RegisterPatientAsync(new PatientRegistrationDTO
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = "Qwerty12345",
                BloodType = request.BloodType,
                Email = request.Email,
                Sex = request.Sex,
                PhoneNumber = request.PhoneNumber
            });

            var hospName = hospitalRepository.GetByIdAsync(request.Id).Result.Name;

            // TODO: load html letter template and fill it in
            await mailService.SendAsync(
                receiver: result.Email,
                subject: $"{hospName} registration",
                bodyHtml: $"You are registered in hospital {hospName}! Use these credentials to sign in to the system:" +
                          $"<br>Email: {result.Email}<br>Password: {result.Password}");

            requestsPatientRepository.Remove(request);
            await requestsPatientRepository.SaveChangesAsync();
        }

        public async Task RejectRequestAsync(int id)
        {
            RequestToCreatePatient request = await requestsPatientRepository.GetByIdAsync(id);
            if (request == null)
            {
                throw new BadRequestException("Creation request doesn't exist!");
            }

            var hospName = hospitalRepository.GetByIdAsync(request.Id).Result.Name;

            // TODO: Load email HTML template from file and fill it in
            await mailService.SendAsync(
                receiver: request.Email,
                subject: $"{hospName} registration",
                bodyHtml: $"{hospName} denied Your request for registration");

            requestsPatientRepository.Remove(request);
            await requestsPatientRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<RequestToCreatePatientViewDTO>> GetAllRequestsAsync(int id)
        {
            IEnumerable<RequestToCreatePatient> requests = await requestsPatientRepository.Find(r => r.HospitalId == id);
            return mapper.Map<IEnumerable<RequestToCreatePatientViewDTO>>(requests);
        }
    }
}
