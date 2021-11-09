using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Repository;
using EmployeePerformanceApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Controllers
{
    [Authorize(Roles = "Lead")]
    public class LeadController : Controller
    {

        //Services
        private readonly IMarkService _markService;
        private readonly IUserService _userSrvice;

        public LeadController( IMarkService markService,
                               IUserService userService)
        {
            _markService = markService;
            _userSrvice = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> CheckHierarchy()
        {
            return View(await _userSrvice.CheckHierarhyForLeadClient());
        }
        [HttpPost]
        public async Task<IActionResult> CheckHierarchy(string _lastName, string _firstName,  string _status, string _role)
        {
            return View(await _userSrvice.CheckHierarhyForLeadClientWithSomeParameters(_lastName, _firstName, _status, _role));
        }
        [HttpGet]
        public async Task<IActionResult> AddMark()
        {
            return View(await _markService.AddMarkViewForLead());
        }
        [HttpPost]
        public async Task<IActionResult> AddMark(string _lastName, string _firstName, string _status, string _role)
        {
            return View(await _markService.AddMarkViewForLeadWithSomeParameter(_lastName, _firstName, _status, _role));
        }
        [HttpGet]
        public async Task<IActionResult> AddMarkAction(int userID)
        {
            return View(await _markService.AddMarkActionViewForLead(userID));
        }
        [HttpPost]
        public async Task<IActionResult> AddMarkAction(int userID, int parameterId, int markValue, string markDescription)
        {
            await _markService.AddMark(userID, parameterId, markValue, markDescription);
            return RedirectToAction("AddMark", "Lead");
        }
    }
}
