using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.DTOs.HospitalCreate;
using TreatLines.BLL.DTOs.PatientCreate;
using TreatLines.BLL.Interfaces;
using TreatLines.Models;
using TreatLines.Models.Requests;
using TreatLines.Models.Response;
using TreatLines.Models.Tables;

namespace TreatLines.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService authService;

        private readonly IHospitalRegistrationRequestsService hospitalRegistrationRequestsService;

        private readonly IHospitalService hospitalService;

        private readonly IMapper mapper;

        private readonly ILogger<UserController> _logger;

        public UserController(
            ILogger<UserController> logger,
            IAuthService authService,
            IHospitalRegistrationRequestsService hospitalRegistrationRequestsService,
            IHospitalService hospitalService,
            IMapper mapper
            )
        {
            this.authService = authService;
            this.hospitalRegistrationRequestsService = hospitalRegistrationRequestsService;
            this.mapper = mapper;
            this.hospitalService = hospitalService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Hospitals()
        {
            var hospitals = await hospitalService.GetHospitals();
            IEnumerable<HospitalModel_UserControler> hospitalsModels = mapper.Map<IEnumerable<HospitalModel_UserControler>>(hospitals);
            return View(hospitalsModels);
        }



        public IActionResult RegisterPatient(int id, string hospName)
        {
            ViewData["HospitalName"] = hospName;
            ViewData["HospitalId"] = id;
            return View();
        }

        public IActionResult RegisterHospital()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var dto = mapper.Map<LoginRequestDTO>(request);
            var response = await authService.LoginAsync(dto);
            var result = mapper.Map<LoginResponse>(response);
            return RedirectToAction("ProfilePage");//will change to redirecting depending on user role
        }

        [AllowAnonymous]
        [HttpPost("SendHospitalRequest")]
        public async Task<IActionResult> SendHospitalRequestAsync(RequestToCreateHospitalModel request)
        {
            var dto = mapper.Map<RequestToCreateHospitalDTO>(request);
            await hospitalRegistrationRequestsService.AddRequestAsync(dto);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("SendPatientRequest")]
        public async Task<IActionResult> SendPatientRequestAsync(RequestToCreatePatientModel request)
        {
            var dto = mapper.Map<RequestToCreatePatientDTO>(request);
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}