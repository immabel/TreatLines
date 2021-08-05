using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;
using TreatLines.Models.ProfileInfo;
using TreatLines.Models.Tables;

namespace TreatLines.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHospitalRegistrationRequestsService hospitalRegistrationRequestsService;

        private readonly IHospitalService hospitalService;

        private readonly IBackUpService backUpService;

        private readonly IMapper mapper;

        private readonly ILogger<AdminController> _logger;

        public AdminController(
            ILogger<AdminController> logger,
            IHospitalRegistrationRequestsService hospitalRegistrationRequestsService,
            IHospitalService hospitalService,
            IBackUpService backUpService,
            IMapper mapper
            )
        {
            this.hospitalRegistrationRequestsService = hospitalRegistrationRequestsService;
            this.mapper = mapper;
            this.backUpService = backUpService;
            this.hospitalService = hospitalService;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var profileInfo = new AdminProfileInfoModel();
            return View(profileInfo);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult BackUp()
        {
            backUpService.CreateDbBackup();
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Requests()
        {
            var requests = await hospitalRegistrationRequestsService.GetAllRequestsAsync();
            var result = mapper.Map<IEnumerable<RequestInfoToCreateHospitalModel>>(requests);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Hospitals()
        {
            var hospitals = await hospitalService.GetHospitalsAsync();
            var result = mapper.Map<IEnumerable<HospitalModel>>(hospitals);
            return View(result);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult HospitalAdmins(int? id, string hospName)
        {
            ViewData["HospitalName"] = hospName;
            var hospAdmins = hospitalService.GetHospitalAdminsById((int)id);
            var result = mapper.Map<IEnumerable<HospitalAdminModel>>(hospAdmins);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveRequestAsync(int id)
        {
            await hospitalRegistrationRequestsService.ApproveRequestAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectRequestAsync(int id)
        {
            await hospitalRegistrationRequestsService.RejectRequestAsync(id);
            return Ok();
        }
    }
}
