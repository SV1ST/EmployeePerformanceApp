using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Repository;
using EmployeePerformanceApp.Repository.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service.Selections
{
    public class SelectionService : ISelectionService
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly IParameterRepository _parameterRepository;
        public SelectionService(ISelectionRepository selectionRepository, IParameterRepository parameterRepository)
        {
            _selectionRepository = selectionRepository;
            _parameterRepository = parameterRepository;
        }

        public async Task CreateSelectionForDB(int departmentId, string selectionName, int[] arr)
        {
            List<Parameter> parametersArray = new List<Parameter>(await _parameterRepository.GetParametersByAllId(arr));

            Selection selection = new Selection { DepartmentId = departmentId, SelectionName = selectionName, Parameters = parametersArray };
            await _selectionRepository.AddSelectionForDB(selection);
        }
    }
}

