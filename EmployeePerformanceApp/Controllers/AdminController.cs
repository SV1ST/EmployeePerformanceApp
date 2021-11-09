using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Controllers
{
    [Authorize(Roles = "Admin")]    
    public class AdminController : Controller
    {
        //Services
        private readonly IUserService _userService;
        private readonly IParameterService _parameterService;
        private readonly ISelectionService _selectionService;

        public AdminController( IUserService userService,
                                ISelectionService selectionService,
                                IParameterService  parameterService)
            
        {
            _userService = userService;
            _parameterService = parameterService;
            _selectionService = selectionService;
        }    
        
        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {            
            return View(await _userService.CreateUserShowService());
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(string _firstName, string _lastName, string _login, string _password, int _roleID, int _statusID, int _departmentID)
        {
             if(await _userService.CheckByLoginForCreateNewUser(_login) != null)
             {
                ModelState.AddModelError("Error", "User Already Exist!");
             }
             else
             {
                await _userService.CreateUserService(_firstName, _lastName, _login, _password, _roleID, _statusID, _departmentID);
             }
            return View(await _userService.CreateUserShowService());
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser()
        {          
            return View(await _userService.DeleteUserShowService());
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string _lastName, string _firstName, string _department, string _status, string _role)
        {            
            return  View(await _userService.DeleteUserShowServiceWithSomeParameters(_lastName, _firstName, _department, _status, _role));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUserByID(int ID)
        {
            User user = await _userService.GetUserByIdService(ID);
           if (user != null && user.RoleId != 1 )
            {
                await _userService.DeleteUserService(ID);
            }                                                                     
            return RedirectToAction("DeleteUser", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> EditUserById(int ID)
        {
            return View(await _userService.EditUserByIdShowService(ID));
        }
        [HttpPost]
        public async Task<IActionResult> EditUserById(int ID, string _lastName, string _firstName, int _roleID, int _statusID)
        {
            await _userService.EditUserByIdShowService(ID, _lastName, _firstName, _roleID, _statusID);
            return RedirectToAction("DeleteUser", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> CreateParameter()
        {
            return View(await _parameterService.CreateParameterShowSevice());
        }
        [HttpPost]
        public async Task<IActionResult> CreateParameter(string name, int departmentId , double coefficient)
        {           
            await _parameterService.CreateParameterService(name, departmentId, coefficient);
            return View(await _parameterService.CreateParameterShowSevice());
        }
        [HttpGet]
        public async Task<IActionResult> DeleteParameter()
        {
            return View(await _parameterService.DeleteParameterShowService());
        }
        [HttpPost]
        public async Task<IActionResult> DeleteParameter(int ID)
        {           
            if(await _parameterService.DeleteParameterWithParameter(ID) != null)
            {
                await _parameterService.DeleteParameterForDBServise(ID);
            }                 
            return RedirectToAction("DeleteParameter", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> CreateSelection(int chosenDepartmentId)
        {            
            return View(await _selectionService.CreateSelectionShowSevice(chosenDepartmentId));
        }
        [HttpPost]
        public async Task<IActionResult> CreateSelection(int departmentId, string selectionName, int chosenDepartmentId)
        {
            await _selectionService.CreateSelectionForDB(departmentId, selectionName);           
            return View(await _selectionService.CreateSelectionShowSevice(chosenDepartmentId));
        }
        [HttpGet]
        public async Task<IActionResult> CreateSelectionAction(int selectionID, string selectionName, int chosenDepartmentId)
        {            
            return View(await _selectionService.CreateSelectionAction(selectionID, selectionName, chosenDepartmentId));
        }
        [HttpPost]
        public async Task<IActionResult> CreateSelectionAction(int selectionID, string selectionName, int chosenDepartmentId, int[] myarray)
        {
            await _selectionService.CreateSelectionAction(selectionID, selectionName, chosenDepartmentId);
            await _selectionService.AddParameterToSelection(myarray, selectionID);
            return RedirectToAction("CreateSelection", "Admin");
        }
    }   
}
