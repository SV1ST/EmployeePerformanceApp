using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository _parameterRepository;
        public ParameterService(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task CreateParameterService(string name, int departmentId, double coefficient)
        {
            Parameter parameter = new Parameter { ParameterName = name, DepartmentId = departmentId, Coefficient = coefficient };
            await _parameterRepository.AddParameterForDB(parameter);
        }
    }
}
