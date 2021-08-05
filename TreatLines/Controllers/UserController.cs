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
using TreatLines.Models.ProfileInfo;
using TreatLines.Models.Requests;
using TreatLines.Models.Response;
using TreatLines.Models.Tables;

namespace TreatLines.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService authService;

        private readonly IHospitalRegistrationRequestsService hospitalRegistrationRequestsService;

        private readonly IPatientRegistrationRequestsService patientRegistrationRequestsService;

        private readonly IHospitalService hospitalService;

        private readonly IMapper mapper;

        private readonly ILogger<UserController> _logger;

        public UserController(
            ILogger<UserController> logger,
            IAuthService authService,
            IHospitalRegistrationRequestsService hospitalRegistrationRequestsService,
            IPatientRegistrationRequestsService patientRegistrationRequestsService,
            IHospitalService hospitalService,
            IMapper mapper
            )
        {
            this.authService = authService;
            this.hospitalRegistrationRequestsService = hospitalRegistrationRequestsService;
            this.patientRegistrationRequestsService = patientRegistrationRequestsService;
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
            var hospitals = await hospitalService.GetHospitalsAsync();
            IEnumerable<HospitalModel> result = mapper.Map<IEnumerable<HospitalModel>>(hospitals.Where(h => h.Blocked == 0));
            return View(result);
        }

        public IActionResult RegisterPatient(int? id, string hospName)
        {
            ViewData["HospitalName"] = hospName;
            RequestToCreatePatientModel req = new RequestToCreatePatientModel { HospitalId = (int)id };
            return View(req);
        }

        public IActionResult RegisterHospital()
        {
            return View();
        }

        public async Task<IActionResult> HospitalProfileInfo(int? id)
        {
            int tempId = (int)id;
            var hospitalInfo = await hospitalService.GetHospitalInfoByIdAsync(tempId);
            var doctorsCount = hospitalService.GetDoctorsCountById(tempId);
            var hospitalAdmins = hospitalService.GetHospitalAdminsById(tempId);
            //var tempHInfo = mapper.Map<HospitalProfileInfoModel>(hospitalInfo);
            var viewModel = new HospitalProfileInfoViewModel();
            //{
            viewModel.HospitalProfileInfo = hospitalInfo;
            viewModel.DoctorsCount = doctorsCount;
            viewModel.HospitalAdmins = mapper.Map<IEnumerable<HospitalAdminContactInfoModel>>(hospitalAdmins);
            //};
            return View(viewModel);
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
            await patientRegistrationRequestsService.AddRequestAsync(dto);
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