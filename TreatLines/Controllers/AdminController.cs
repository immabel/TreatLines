using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BackUp()
        {
            backUpService.CreateDbBackup();
            return View();
        }

        public async Task<IActionResult> Requests()
        {
            var requests = await hospitalRegistrationRequestsService.GetAllRequestsAsync();
            var result = mapper.Map<IEnumerable<RequestToCreateHospitalModelView>>(requests);
            return View(result);
        }

        public async Task<IActionResult> Hospitals()
        {
            var hospitals = await hospitalService.GetHospitalsAsync();
            var result = mapper.Map<IEnumerable<HospitalModel>>(hospitals);
            return View(result);
        }

        public IActionResult HospitalAdmins(int? id)
        {
            var hospAdmins = hospitalService.GetHospitalAdminsById((int)id);
            var result = mapper.Map<IEnumerable<HospitalAdminModel>>(hospAdmins);
            return View();
        }
    }
}
