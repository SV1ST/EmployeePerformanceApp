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
        //Repositories
        private readonly IParameterRepository _parameterRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public ParameterService(IParameterRepository parameterRepository,
                                IDepartmentRepository departmentRepository)
        {
            _parameterRepository = parameterRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task CreateParameterService(string name, int departmentId, double coefficient)
        {
            Parameter parameter = new Parameter { ParameterName = name, DepartmentId = departmentId, Coefficient = coefficient };
            await _parameterRepository.AddParameterForDB(parameter);
        }
        public async Task<AddParameterViewModel> CreateParameterShowSevice()
        {
            AddParameterViewModel addParameterViewModel = new AddParameterViewModel();
            addParameterViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            addParameterViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            return (addParameterViewModel);
        }

        public async Task DeleteParameterForDBServise(int ID)
        {
            await _parameterRepository.DeleteParameterForDB(ID);
        }

        public async Task<List<Parameter>> DeleteParameterShowService()
        {
           return (await _parameterRepository.GetAllDataParameter());
        }

        public async Task<Parameter> DeleteParameterWithParameter(int ID)
        {
            return (await _parameterRepository.GetParameterById(ID));
        }
    }
}
