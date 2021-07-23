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
using TreatLines.BLL.Interfaces;
using TreatLines.Models;
using TreatLines.Models.Requests;

namespace TreatLines.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService authService;

        private readonly IHospitalRegistrationRequestsService hospitalRegistrationRequestsService;

        private readonly IMapper mapper;

        private readonly ILogger<UserController> _logger;

        public UserController(
            ILogger<UserController> logger,
            IAuthService authService,
            IHospitalRegistrationRequestsService hospitalRegistrationRequestsService,
            IMapper mapper
            )
        {
            this.authService = authService;
            this.hospitalRegistrationRequestsService = hospitalRegistrationRequestsService;
            this.mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task LoginAsync(LoginRequest request)
        {
            var response = await authService.LoginAsync(new LoginRequestDTO { Email = request.Email, Password = request.Password });
                //var result = mapper.Map<LoginResponse>(response);
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