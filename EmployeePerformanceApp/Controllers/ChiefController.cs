using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Controllers
{
    public class ChiefController : Controller
    {
        [Authorize(Roles = "Chief")]
        [HttpGet]
        public async Task<IActionResult> CheckHierarchyByChief()
        {
            return View();
        }
    }
}
