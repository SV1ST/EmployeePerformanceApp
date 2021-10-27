using EmployeePerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository
{
    public interface IParameterRepository
    {
        Task<List<Parameter>> GetAllDataParameter();
        Task<Parameter> GetParameterById(int ID);
        Task<List<Parameter>> GetParametersByAllId(int[] ids);
        Task AddParameterForDB(Parameter parameter);
        Task DeleteParameterForDB(int ID);
    }
}
