using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Models.ModelsForViews;
using EmployeePerformanceApp.Repository;
using EmployeePerformanceApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Controllers
{
    [Authorize(Roles = "Admin")]    
    public class AdminController : Controller
    {
        private ApplicationContext db;

        //Repositories
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly ISelectionRepository _selectionRepository;


        //Services
        private readonly IUserService _userService;
        private readonly IParameterService _parameterService;
        private readonly ISelectionService _selectionService;


        public AdminController(IUserRepository userRepository, IRoleRepository roleRepository,IDepartmentRepository departmentRepository,
            IStatusRepository statusRepository, IParameterRepository parameterRepository, IUserService userService, ISelectionService selectionService, IParameterService  parameterService,
            ISelectionRepository selectionRepository ,ApplicationContext context)
        {
            db = context;

            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _departmentRepository = departmentRepository;
            _statusRepository = statusRepository;
            _parameterRepository = parameterRepository;
            _selectionRepository = selectionRepository;




            _userService = userService;
            _parameterService = parameterService;
            _selectionService = selectionService;
        }      
        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {

            CreateUserViewModel createUserModel = new CreateUserViewModel();
            createUserModel.Users = await _userRepository.GetAllDataUser();
            createUserModel.Roles = await _roleRepository.GetAllDataRole();
            createUserModel.Statuses = await _statusRepository.GetAllDataStatus();
            createUserModel.Departments = await _departmentRepository.GetAllDataDepartment();
            return View(createUserModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(string _firstName, string _lastName, string _login, string _password, int _roleID, int _statusID, int _departmentID)
        {
             if(await _userRepository.CheckByLoginForCreateNewUser(_login) != null)
             {
                ModelState.AddModelError("Error", "User Already Exist!");
             }
             else
             {
                await _userService.CreateUserService(_firstName, _lastName, _login, _password, _roleID, _statusID, _departmentID);
             }
                         
            CreateUserViewModel createUserViewModel = new CreateUserViewModel();
            createUserViewModel.Users = await _userRepository.GetAllDataUser();
            createUserViewModel.Roles = await _roleRepository.GetAllDataRole();
            createUserViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            createUserViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            return View(createUserViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser()
        {
            DeleteUserViewModel deleteUserViewModel = new DeleteUserViewModel();
            deleteUserViewModel.Users = await _userRepository.GetAllDataUser();
            deleteUserViewModel.Roles = await _roleRepository.GetAllDataRole();
            deleteUserViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            deleteUserViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            return View(deleteUserViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string _lastName, string _firstName, string _department, string _status, string _role)
        {
            DeleteUserViewModel deleteUserViewModel = new DeleteUserViewModel();
            deleteUserViewModel.LastName =  _lastName;
            deleteUserViewModel.FirstName = _firstName;
            deleteUserViewModel.DepartmentName = _department;
            deleteUserViewModel.StatusName = _status;
            deleteUserViewModel.RoleName = _role;
            deleteUserViewModel.Users = await _userRepository.GetAllDataUser();
            deleteUserViewModel.Roles = await _roleRepository.GetAllDataRole();
            deleteUserViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            deleteUserViewModel.Departments = await _departmentRepository.GetAllDataDepartment();

            return  View(deleteUserViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUserByID(int ID)
        {
           User check = await _userRepository.GetUserById(ID);
           if (check == null)           
                ModelState.AddModelError("Error", "There is no user with this id, check the entered data is correct!");                         
           else          
                await _userService.DeleteUserService(ID);                            
            return RedirectToAction("DeleteUser", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> CreateParameter()
        {
            AddParameterViewModel addParameterViewModel = new AddParameterViewModel();
            addParameterViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            addParameterViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            return View(addParameterViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateParameter(string name, int departmentId , double coefficient)
        {           
            await _parameterService.CreateParameterService(name, departmentId, coefficient);
            AddParameterViewModel addParameterViewModel = new AddParameterViewModel();
            addParameterViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            addParameterViewModel.Parameters = await _parameterRepository.GetAllDataParameter();

            return View(addParameterViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteParameter()
        {
            return View(await _parameterRepository.GetAllDataParameter());
        }
        [HttpPost]
        public async Task<IActionResult> DeleteParameter(int ID)
        {
            Parameter check = await _parameterRepository.GetParameterById(ID);
            if(check == null)
                ModelState.AddModelError("Error", "There is no parameter with this id, check the entered data is correct!");
            else
            await _parameterRepository.DeleteParameterForDB(ID);          
            return RedirectToAction("DeleteParameter", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> CreateSelection()
        {
            CreateSelectionViewModel createSelectionViewModel = new CreateSelectionViewModel();
            createSelectionViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            createSelectionViewModel.Selections = await _selectionRepository.GetAllDataSelection();
            createSelectionViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            return View(createSelectionViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSelection(int departmentId, string selectionName, int chosenDepartmentId)
        {

            await _selectionService.CreateSelectionForDB(departmentId, selectionName);

            CreateSelectionViewModel createSelectionViewModel = new CreateSelectionViewModel();
            createSelectionViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            createSelectionViewModel.Selections = await _selectionRepository.GetAllDataSelection();
            createSelectionViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            createSelectionViewModel.CurrentDepartmentID = chosenDepartmentId;
            return View(createSelectionViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> CreateSelectionAction(int selectionID, string selectionName, int chosenDepartmentId)
        {
            CreateSelectionViewModel createSelectionViewModel = new CreateSelectionViewModel();
            createSelectionViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            createSelectionViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            createSelectionViewModel.Selections = await _selectionRepository.GetAllDataSelection();
            createSelectionViewModel.CurrentSelectionId = selectionID;           
            createSelectionViewModel.CurrentSelectionName = selectionName;
            createSelectionViewModel.CurrentDepartmentID = chosenDepartmentId;
            return View(createSelectionViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSelectionAction(int selectionID, string selectionName, int chosenDepartmentId, int[] myarray)
        {
            CreateSelectionViewModel createSelectionViewModel = new CreateSelectionViewModel();
            createSelectionViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            createSelectionViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            createSelectionViewModel.Selections = await _selectionRepository.GetAllDataSelection();
            createSelectionViewModel.CurrentSelectionId = selectionID;
            createSelectionViewModel.CurrentSelectionName = selectionName;
            createSelectionViewModel.CurrentDepartmentID = chosenDepartmentId;
            await _selectionService.AddParameterToSelection(myarray, selectionID);
            return RedirectToAction("CreateSelection", "Admin");
        }
    }   
}
