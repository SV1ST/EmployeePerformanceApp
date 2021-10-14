using EmployeePerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository.Users
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
       // Task<User> GetUserByLoginPassword(LoginModel model);
        Task<User> CheckUserByLoginPassword(string userLogin, string userPassword);
    }
}
