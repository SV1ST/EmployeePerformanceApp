using ClosedXML.Excel;
using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Repository;
using EmployeePerformanceApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Controllers
{
    [Authorize(Roles = "Chief")]
    public class ChiefController : Controller
    {
        //Repositories to work with records in Excel, because I don't know yet
        private readonly IUserRepository _userRepository;
        private readonly ISelectionRepository _selectionRepository;


        //Services
        private readonly IMarkService _markService;
        private readonly IUserService _userService;
        private readonly ISelectionService _selectionService;

        public ChiefController(IUserRepository userRepository,            
                               ISelectionRepository selectionRepository,
                               IMarkService markService, IUserService userService,
                               ISelectionService selectionService)
        {
            _userRepository = userRepository;
            _selectionRepository = selectionRepository;

            _markService = markService;
            _userService = userService;
            _selectionService = selectionService;
        }

        [HttpGet]
        public async Task<IActionResult> CheckHierarchyByChief()
        {            
            return View(await _userService.CheckHierarchyForChiefClient());
        }
        [HttpPost]
        public async Task<IActionResult> CheckHierarchyByChief(string _lastName, string _firstName, string _status, string _role)
        {         
            return View(await _userService.CheckHierarhyForChiefClientWithSomeParameters(_lastName, _firstName, _status, _role));
        }
        [HttpGet]
        public async Task<IActionResult> AddMarkToLead()
        {
            return View(await _markService.AddMarkViewForChief());
        }
        [HttpPost]
        public async Task<IActionResult> AddMarkToLead(string _lastName, string _firstName, string _status, string _role)
        {
            return View(await _markService.AddMarkViewForChiefWithSomeParameter(_lastName, _firstName, _status, _role));
        }
        [HttpGet]
        public async Task<IActionResult> AddMarkToLeadAction(int userID)
        {
            return View(await _markService.AddMarkActionViewForChief(userID));
        }
        [HttpPost]
        public async Task<IActionResult> AddMarkToLeadAction(int userID, int parameterId, int markValue, string markDescription)
        {
            await _markService.AddMark(userID, parameterId, markValue, markDescription);
            return RedirectToAction("AddMarkToLead", "Chief");
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllMarks()
        {
            return View(await _markService.ShowAllMarksForChief());
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllActualMarks()
        {
            return View(await _markService.ShowAllActualMarksForChief());
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllSelections()
        {
            return View(await _selectionService.ShowAllSelections());

        }
        [HttpPost]
        public async Task<IActionResult> ShowAllSelections(int ID)
        {       
            return View(await _selectionService.ShowAllSelections(ID));
        }
        [HttpGet]
        public async Task<IActionResult>GetTopBySelectSelection(int selectionID)
        {
            return View(await _selectionService.GetTopBySelectSelection(selectionID));
        }
        [HttpPost]
        public async Task<IActionResult> GetTopBySelectSelection(int selectionID, string saveName)
        {
            User chief = await _userRepository.GetUserById(Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value));
            List<User> users = await _userRepository.GetUsersByDepartmentIdNotChief(chief.DepartmentId);

            Selection selection = await _selectionRepository.GetSelectionById(selectionID);


            var parameters = selection.Parameters.ToDictionary(p => p.ID, p => p);

            var markedUsers = new List<(User user, double mark)>(users.Count);

            foreach (var user in users)
            {
                var total = 0.0;
                var marks = new Dictionary<int, List<double>>();

                foreach (var mark in user.Marks)
                {
                    if (selection.Parameters.Contains(mark.Parameter))
                    {
                        if (!marks.ContainsKey(mark.ParameterId))
                            marks[mark.ParameterId] = new List<double>();

                        marks[mark.ParameterId].Add(mark.MarkValue);
                    }
                }

                foreach (var kv in marks)
                {
                    var average = kv.Value.Average();
                    total += average * parameters[kv.Key].Coefficient;
                }

                markedUsers.Add((user, total));
            }

            var bottomUsers = markedUsers.OrderBy(u => u.mark).Take(3).Select(t => t.user);
            var topUsers = markedUsers.OrderByDescending(u => u.mark).Take(3).Select(t => t.user);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Top");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Surname";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow, 3).Value = "Role";
                foreach (var user in topUsers)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = user.LastName;
                    worksheet.Cell(currentRow, 2).Value = user.FirstName;
                    worksheet.Cell(currentRow, 3).Value = user.Role.RoleName;
                }
                var worksheet1 = workbook.Worksheets.Add("Bottom");
                var currentRow1 = 1;
                worksheet1.Cell(currentRow1, 1).Value = "Surname";
                worksheet1.Cell(currentRow1, 2).Value = "Name";
                worksheet1.Cell(currentRow1, 3).Value = "Role";
                foreach (var user in bottomUsers)
                {
                    currentRow1++;
                    worksheet1.Cell(currentRow1, 1).Value = user.LastName;
                    worksheet1.Cell(currentRow1, 2).Value = user.FirstName;
                    worksheet1.Cell(currentRow1, 3).Value = user.Role.RoleName;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"Selection_{saveName}/{DateTime.Now.Day}.{DateTime.Now.Month}.xlsx");
                }
            }
        }
    }
}


