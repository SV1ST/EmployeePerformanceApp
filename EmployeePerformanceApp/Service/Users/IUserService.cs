using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service.Users
{
    public interface IUserService
    {
        Task CreateUserService(string _firstName, string _lastName, string _login, string _password, int _roleID, int _statusID, int _departmentID);
        Task DeleteUserService(int ID);
    }
}
