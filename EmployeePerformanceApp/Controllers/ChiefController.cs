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
        public IActionResult Index()
        {
            ViewBag.Ide = User.Identity.Name;
            return View();
        }
    }
}
