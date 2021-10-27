using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service.Parameters
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository _parameterRepository;
        public ParameterService(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task CreateParameterService(string name)
        {
            Parameter parameter = new Parameter { ParameterName = name };
            await _parameterRepository.AddParameterForDB(parameter);
        }
    }
}
