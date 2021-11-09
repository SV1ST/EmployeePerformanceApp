using EmployeePerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
{
    public interface IParameterService
    {
        Task CreateParameterService(string name, int departmentId, double coefficient);
        Task<AddParameterViewModel> CreateParameterShowSevice();
        Task<List<Parameter>> DeleteParameterShowService();
        Task<Parameter> DeleteParameterWithParameter(int ID);
        Task DeleteParameterForDBServise(int ID);
    }
}
