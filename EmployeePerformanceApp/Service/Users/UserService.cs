using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Models.ModelsForViews;
using EmployeePerformanceApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IStatusRepository statusRepository, IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _statusRepository = statusRepository;
            _departmentRepository = departmentRepository;
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
        public async Task DeleteUserService(int ID)
        {
            User user = await _userRepository.GetUserById(ID);
            await _userRepository.DeleteUserForDB(user);
        }

    }
}
    

