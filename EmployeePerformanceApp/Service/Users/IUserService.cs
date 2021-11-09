using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Models.ModelsForViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
{
    public interface IUserService
    {
        Task CreateUserService(string _firstName, string _lastName, string _login, string _password, int _roleID, int _statusID, int _departmentID);
        Task<CreateUserViewModel> CreateUserShowService();
        Task<DeleteUserViewModel> DeleteUserShowService();
        Task<DeleteUserViewModel> DeleteUserShowServiceWithSomeParameters(string _lastName, string _firstName, string _department, string _status, string _role);
        Task<CheckHierarhyViewModel> CheckHierarhyForLeadClient();
        Task<CheckHierarhyViewModel> CheckHierarhyForLeadClientWithSomeParameters(string _lastName, string _firstName, string _status, string _role);
        Task<CheckHierarhyViewModel> CheckHierarchyForChiefClient();
        Task<CheckHierarhyViewModel> CheckHierarhyForChiefClientWithSomeParameters(string _lastName, string _firstName, string _status, string _role);
        Task<User> CheckByLoginForCreateNewUser(string _login);
        Task<User> GetUserByIdService(int ID);
        Task DeleteUserService(int ID);
        Task<EditUserByGetUserViewModel> EditUserByIdShowService(int ID);
        Task<EditUserByGetUserViewModel> EditUserByIdShowService(int ID, string _lastName, string _firstName, int _roleID, int _statusID);

    }
}
