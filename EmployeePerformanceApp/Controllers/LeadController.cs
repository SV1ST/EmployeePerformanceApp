using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Models.ModelsForViews;
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
        //Repositories
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly ISelectionRepository _selectionRepository;
        private readonly IMarkRepository _markRepository;

        //Services
        private readonly IMarkService _markService;

        public LeadController(IUserRepository userRepository, IRoleRepository roleRepository, IDepartmentRepository departmentRepository,
            IStatusRepository statusRepository, IParameterRepository parameterRepository, IMarkRepository markRepository,
            ISelectionRepository selectionRepository, IMarkService markService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _departmentRepository = departmentRepository;
            _statusRepository = statusRepository;
            _parameterRepository = parameterRepository;
            _selectionRepository = selectionRepository;
            _markRepository = markRepository;

            _markService = markService;
        }
        
        [HttpGet]
        public async Task<IActionResult> CheckHierarchy()
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value));
            List<Role> roles = await _roleRepository.GetAllDataRole();
            Role role = roles.Where(x => x.RoleName == "Employee").FirstOrDefault();
            List<User> users = await _userRepository.GetAllSubordinatesUser(user.DepartmentId, role.ID);

            CheckHierarhyViewModel hierarhyViewModel = new CheckHierarhyViewModel();
            hierarhyViewModel.Users = await _userRepository.GetAllDataUser();
            hierarhyViewModel.Roles = await _roleRepository.GetAllDataRole();
            hierarhyViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            hierarhyViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            hierarhyViewModel.CurrentUserDepartmentId = user.DepartmentId;
            hierarhyViewModel.CurrentUserId = user.ID;
            return View(hierarhyViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CheckHierarchy(string _lastName, string _firstName,  string _status, string _role)
        {
            User user  = await _userRepository.GetUserById(Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value));           
            List<Role> roles = await _roleRepository.GetAllDataRole();
            Role role = roles.Where(x => x.RoleName == "Employee").FirstOrDefault();
            List<User> users = await _userRepository.GetAllSubordinatesUser(user.DepartmentId, role.ID );
            CheckHierarhyViewModel hierarhyViewModel = new CheckHierarhyViewModel();
            hierarhyViewModel.LastName = _lastName;
            hierarhyViewModel.FirstName = _firstName;
            hierarhyViewModel.StatusName = _status;
            hierarhyViewModel.RoleName = _role;
            hierarhyViewModel.Users = await _userRepository.GetAllDataUser();
            hierarhyViewModel.Roles = await _roleRepository.GetAllDataRole();
            hierarhyViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            hierarhyViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            hierarhyViewModel.CurrentUserDepartmentId = user.DepartmentId;
            hierarhyViewModel.CurrentUserId = user.ID;
            return View(hierarhyViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AddMark()
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value));
            List<Role> roles = await _roleRepository.GetAllDataRole();
            Role role = roles.Where(x => x.RoleName == "Employee").FirstOrDefault();
            List<User> users = await _userRepository.GetAllSubordinatesUser(user.DepartmentId, role.ID);

            AddMarkViewModel addMarkViewModel = new AddMarkViewModel();
            addMarkViewModel.Users = await _userRepository.GetAllDataUser();
            addMarkViewModel.Roles = await _roleRepository.GetAllDataRole();
            addMarkViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            addMarkViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            addMarkViewModel.CurrentUserDepartmentId = user.DepartmentId;
            addMarkViewModel.CurrentUserRoleId = role.ID;
            return View(addMarkViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddMark(string _lastName, string _firstName, string _status, string _role)
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value));
            List<Role> roles = await _roleRepository.GetAllDataRole();
            Role role = roles.Where(x => x.RoleName == "Employee").FirstOrDefault();
            List<User> users = await _userRepository.GetAllSubordinatesUser(user.DepartmentId, role.ID);

            AddMarkViewModel addMarkViewModel = new AddMarkViewModel();
            addMarkViewModel.LastName = _lastName;
            addMarkViewModel.FirstName = _firstName;
            addMarkViewModel.StatusName = _status;
            addMarkViewModel.RoleName = _role;
            addMarkViewModel.Users = await _userRepository.GetAllDataUser();
            addMarkViewModel.Roles = await _roleRepository.GetAllDataRole();
            addMarkViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            addMarkViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            addMarkViewModel.Marks = await _markRepository.GetAllDataMark();
            addMarkViewModel.CurrentUserDepartmentId = user.DepartmentId;
            addMarkViewModel.CurrentUserRoleId = role.ID;
            return View(addMarkViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AddMarkAction(int userID)
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value));
            User userEmployee = await _userRepository.GetUserById(userID);
            List<Role> roles = await _roleRepository.GetAllDataRole();
            Role role = roles.Where(x => x.RoleName == "Employee").FirstOrDefault();
            AddMarkViewModel addMarkViewModel = new AddMarkViewModel();
            addMarkViewModel.FirstName = userEmployee.FirstName;
            addMarkViewModel.LastName = userEmployee.LastName;
            addMarkViewModel.Users = await _userRepository.GetAllDataUser();
            addMarkViewModel.Roles = await _roleRepository.GetAllDataRole();
            addMarkViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            addMarkViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            addMarkViewModel.CurrentUserDepartmentId = user.DepartmentId;
            addMarkViewModel.CurrentUserRoleId = role.ID;
            addMarkViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            addMarkViewModel.UserId = userID;
            return View(addMarkViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddMarkAction(int userID, int parameterId, int markValue, string markDescription)
        {

            await _markService.AddMark(userID, parameterId, markValue, markDescription);
            return RedirectToAction("AddMark", "Lead");
        }
    }
}
