using EmployeePerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllDataUser();
        Task<User> CheckUserByLoginPassword(string userLogin, string userPassword);
        Task<User> CheckByLoginForCreateNewUser(string login);
        Task AddUserForDB(User user);
        Task DeleteUserForDB(User user);
        Task UpdateUserForDB();
        Task<List<User>> GetAllSubordinatesUser(int IDDep, int IDRole);
        Task<List<User>> GetUsersByDepartmentId(int id);
        Task<List<User>> GetUsersByDepartmentIdNotChief(int id);
    }
}
