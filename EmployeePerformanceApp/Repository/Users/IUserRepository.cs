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
        Task<List<User>> GetAllDataUser();
        Task<User> CheckUserByLoginPassword(string userLogin, string userPassword);
        Task<User> CheckByLoginForCreateNewUser(string login);
        Task AddUserForDB(User user);
        Task DeleteUserForDB(User user);
        Task<List<User>> GetAllSubordinatesUser(int IDDep, int IDRole);
    }
}
