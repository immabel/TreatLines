using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Admin;
using TreatLines.BLL.Interfaces;
using TreatLines.Models.ProfileInfo;
using TreatLines.Models.Tables;

namespace TreatLines.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHospitalRegistrationRequestsService hospitalRegistrationRequestsService;

        private readonly IHospitalService hospitalService;

        private readonly IAdminService adminService;

        private readonly IMapper mapper;

        private readonly ILogger<AdminController> _logger;

        public AdminController(
            ILogger<AdminController> logger,
            IHospitalRegistrationRequestsService hospitalRegistrationRequestsService,
            IHospitalService hospitalService,
            IAdminService adminService,
            IMapper mapper
            )
        {
            this.hospitalRegistrationRequestsService = hospitalRegistrationRequestsService;
            this.mapper = mapper;
            this.adminService = adminService;
            this.hospitalService = hospitalService;
            _logger = logger;
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            string adminId = "00CA41A9-C962-4230-937E-D5F54772C062";
            var profileInfo = await adminService.GetAdminProfileInfoAsync(adminId);
            var result = mapper.Map<AdminProfileInfoModel>(profileInfo);
            return View(result);
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult BackUp()
        {
            adminService.CreateDbBackup();
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Requests()
        {
            var requests = await hospitalRegistrationRequestsService.GetAllRequestsAsync();
            var result = mapper.Map<IEnumerable<RequestInfoToCreateHospitalModel>>(requests);
            return View(result);
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Hospitals()
        {
            var hospitals = await hospitalService.GetHospitalsAsync();
            var result = mapper.Map<IEnumerable<HospitalModel>>(hospitals);
            return View(result);
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult HospitalAdmins(int? id, string hospName)
        {
            ViewData["HospitalName"] = hospName;
            var hospAdmins = hospitalService.GetHospitalAdminsById((int)id);
            var result = mapper.Map<IEnumerable<HospitalAdminModel>>(hospAdmins);
            return View(result);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ApproveRequest(int id)
        {
            await hospitalRegistrationRequestsService.ApproveRequestAsync(id);
            return RedirectToAction("Requests");
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RejectRequest(int? id)
        {
            await hospitalRegistrationRequestsService.RejectRequestAsync((int)id);
            return RedirectToAction("Requests");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdminInfo(AdminProfileInfoModel model)
        {
            var admin = mapper.Map<AdminProfileInfoDTO>(model);
            await adminService.UpdateUserInfoAsync(admin);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> BlockUnblockUser(string id, int? hospId, string hospitalName)
        {
            await hospitalService.BlockUserAsync(id);
            return RedirectToAction("HospitalAdmins", new { id = hospId, hospName = hospitalName });
        }

        [HttpPost]
        public async Task<IActionResult> BlockUnblockHospital(int id)
        {
            await hospitalService.BlockHospitalByIdAsync(id);
            return RedirectToAction("Hospitals");
        }
    }
}
