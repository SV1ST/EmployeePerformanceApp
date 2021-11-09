using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Repository;
using EmployeePerformanceApp.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Services
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IParameterRepository _parameterRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public MarkService(IMarkRepository markRepository,
                           IUserRepository userRepository,
                           IDepartmentRepository departmentRepository,
                           IRoleRepository roleRepository,
                           IStatusRepository statusRepository,
                           IParameterRepository parameterRepository,
                           IHttpContextAccessor httpContextAccessor)
        {
            _markRepository = markRepository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _roleRepository = roleRepository;
            _statusRepository = statusRepository;
            _parameterRepository = parameterRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddMark(int userId, int parameterId, int markValue, string markDescription)
        {
            int currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value);
            User currentUser = await _userRepository.GetUserById(currentUserId);
            DateTime assessmentDate = DateTime.Now;

            Mark mark = new Mark { ParameterId = parameterId, MarkValue = markValue, MarkDescription = markDescription, UserId = userId, AssessorId = currentUser.ID, AssesmentDate = assessmentDate, IsActual = true, AssessorFirstName = currentUser.FirstName, AssessorLastName = currentUser.LastName };
            await _markRepository.AddMark(mark);
        }

        public async Task<AddMarkViewModel> AddMarkActionViewForChief(int userID)
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
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
            return (addMarkViewModel);
        }

        public async Task<AddMarkViewModel> AddMarkActionViewForLead(int userID)
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
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
            return (addMarkViewModel);
        }

        public async Task<AddMarkViewModel> AddMarkViewForChief()
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            List<Role> roles = await _roleRepository.GetAllDataRole();
            Role role = roles.Where(x => x.RoleName == "Lead").FirstOrDefault();
            List<User> users = await _userRepository.GetAllSubordinatesUser(user.DepartmentId, role.ID);

            AddMarkViewModel addMarkViewModel = new AddMarkViewModel();
            addMarkViewModel.Users = await _userRepository.GetAllDataUser();
            addMarkViewModel.Roles = await _roleRepository.GetAllDataRole();
            addMarkViewModel.Statuses = await _statusRepository.GetAllDataStatus();
            addMarkViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            addMarkViewModel.CurrentUserDepartmentId = user.DepartmentId;
            addMarkViewModel.CurrentUserRoleId = role.ID;
            return (addMarkViewModel);
        }

        public async Task<AddMarkViewModel> AddMarkViewForChiefWithSomeParameter(string _lastName, string _firstName, string _status, string _role)
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            List<Role> roles = await _roleRepository.GetAllDataRole();
            Role role = roles.Where(x => x.RoleName == "Lead").FirstOrDefault();
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
            return (addMarkViewModel);
        }

        public async Task<AddMarkViewModel> AddMarkViewForLead()
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
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
            return (addMarkViewModel);
        }

        public async Task<AddMarkViewModel> AddMarkViewForLeadWithSomeParameter(string _lastName, string _firstName, string _status, string _role)
        {
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
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
            return (addMarkViewModel);
        }

        public async Task<ShowAllMarksViewModel> ShowAllActualMarksForChief()
        {
            List<Mark> marks = await _markRepository.GetAllDataMark();
            List<Mark> actualMarks = new List<Mark>();
            TimeSpan diff;
            foreach (Mark item in marks)
            {
                diff = DateTime.Now.Subtract(item.AssesmentDate);
                if (diff.TotalDays < 90)
                {
                    actualMarks.Add(item);
                }
            }
            ShowAllMarksViewModel showAllMarksViewModel = new ShowAllMarksViewModel();
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            showAllMarksViewModel.getCurrentUserIdDepartment = user.DepartmentId;
            showAllMarksViewModel.Marks = actualMarks;
            showAllMarksViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            showAllMarksViewModel.Users = await _userRepository.GetAllDataUser();
            return (showAllMarksViewModel);
        }

        public async Task<ShowAllMarksViewModel> ShowAllMarksForChief()
        {
            ShowAllMarksViewModel showAllMarksViewModel = new ShowAllMarksViewModel();
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            showAllMarksViewModel.getCurrentUserIdDepartment = user.DepartmentId;
            showAllMarksViewModel.Marks = await _markRepository.GetAllDataMark();
            showAllMarksViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            showAllMarksViewModel.Users = await _userRepository.GetAllDataUser();
            return (showAllMarksViewModel);
        }
    }
}