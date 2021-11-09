using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Models.ModelsForViews;
using EmployeePerformanceApp.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
{

    public class UserService : IUserService
    {
        //Repositories
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUserRepository userRepository,
                            IRoleRepository roleRepository,
                            IStatusRepository statusRepository,
                            IDepartmentRepository departmentRepository,
                            IHttpContextAccessor httpContextAccessor)
                            
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _statusRepository = statusRepository;
            _departmentRepository = departmentRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> CheckByLoginForCreateNewUser(string _login)
        {
            return (await _userRepository.CheckByLoginForCreateNewUser(_login));
        }

        public async Task<CheckHierarhyViewModel> CheckHierarchyForChiefClient()
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
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
            return(hierarhyViewModel);
        }

        public async Task<CheckHierarhyViewModel> CheckHierarhyForChiefClientWithSomeParameters(string _lastName, string _firstName, string _status, string _role)
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            List<Role> roles = await _roleRepository.GetAllDataRole();
            Role role = roles.Where(x => x.RoleName == "Employee").FirstOrDefault();
            List<User> users = await _userRepository.GetAllSubordinatesUser(user.DepartmentId, role.ID);
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
            return (hierarhyViewModel);
        }

        public async Task<CheckHierarhyViewModel> CheckHierarhyForLeadClient()
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
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
            return (hierarhyViewModel);
        }

        public async Task<CheckHierarhyViewModel> CheckHierarhyForLeadClientWithSomeParameters(string _lastName, string _firstName, string _status, string _role)
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            List<Role> roles = await _roleRepository.GetAllDataRole();
            Role role = roles.Where(x => x.RoleName == "Employee").FirstOrDefault();
            List<User> users = await _userRepository.GetAllSubordinatesUser(user.DepartmentId, role.ID);
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
            return(hierarhyViewModel);
        }

        public async Task CreateUserService(string _firstName, string _lastName, string _login, string _password, int _roleID, int _statusID, int _departmentID)
        {
            User proverka = await _userRepository.CheckByLoginForCreateNewUser(_login);
            if (proverka == null)
            {
                User user = new User
                {
                    FirstName = _firstName,
                    LastName = _lastName,
                    Login = _login,
                    Password = _password,
                    RoleId = _roleID,
                    StatusId = _statusID,
                    DepartmentId = _departmentID
                };
                await _userRepository.AddUserForDB(user);
            }
        }

        public async Task<CreateUserViewModel>CreateUserShowService()
        {
            CreateUserViewModel createUserModel = new CreateUserViewModel();
            createUserModel.Users = await _userRepository.GetAllDataUser();
            createUserModel.Roles = await _roleRepository.GetAllDataRole();
            createUserModel.Statuses = await _statusRepository.GetAllDataStatus();
            createUserModel.Departments = await _departmentRepository.GetAllDataDepartment();
            return (createUserModel);
        }

        public async Task DeleteUserService(int ID)
        {
            await _userRepository.DeleteUserForDB(await _userRepository.GetUserById(ID));
        }

        public async Task<DeleteUserViewModel> DeleteUserShowService()
        {
            DeleteUserViewModel deleteUserViewModel = new DeleteUserViewModel();
            deleteUserViewModel.Users = await _userRepository.GetAllDataUser();
            deleteUserViewModel.Roles = await _roleRepository.GetAllDataRole();
            deleteUserViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            deleteUserViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            return (deleteUserViewModel);

        }

        public async Task<DeleteUserViewModel> DeleteUserShowServiceWithSomeParameters(string _lastName, string _firstName, string _department, string _status, string _role)
        {
            DeleteUserViewModel deleteUserViewModel = new DeleteUserViewModel();
            deleteUserViewModel.LastName = _lastName;
            deleteUserViewModel.FirstName = _firstName;
            deleteUserViewModel.DepartmentName = _department;
            deleteUserViewModel.StatusName = _status;
            deleteUserViewModel.RoleName = _role;
            deleteUserViewModel.Users = await _userRepository.GetAllDataUser();
            deleteUserViewModel.Roles = await _roleRepository.GetAllDataRole();
            deleteUserViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            deleteUserViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            return (deleteUserViewModel);
        }

        public async Task<EditUserByGetUserViewModel> EditUserByIdShowService(int ID)
        {
            User editUser = await _userRepository.GetUserById(ID);
            EditUserByGetUserViewModel editUserByGetUserViewModel = new EditUserByGetUserViewModel();
            editUserByGetUserViewModel.getUser = editUser;
            editUserByGetUserViewModel.Roles = await _roleRepository.GetAllDataRole();
            editUserByGetUserViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            return (editUserByGetUserViewModel);
        }

        public async Task<EditUserByGetUserViewModel> EditUserByIdShowService(int ID, string _lastName, string _firstName, int _roleID, int _statusID)
        {
            EditUserByGetUserViewModel editUserByGetUserViewModel = new EditUserByGetUserViewModel();
            User user = await _userRepository.GetUserById(ID);
            user.LastName = _lastName;
            user.FirstName = _firstName;
            user.RoleId = _roleID;
            user.StatusId = _statusID;
            await _userRepository.UpdateUserForDB();
            return (editUserByGetUserViewModel);
        }

        public async Task<User> GetUserByIdService(int ID)
        {
            return (await _userRepository.GetUserById(ID));
        }
    }
}
    

