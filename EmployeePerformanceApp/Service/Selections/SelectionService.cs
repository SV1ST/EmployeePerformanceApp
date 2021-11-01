using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
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

        public async Task CreateSelectionForDB(int departmentId, string selectionName)
        {
            

            Selection selection = new Selection { DepartmentId = departmentId, SelectionName = selectionName/*, Parameters = parametersArray*/ };
            await _selectionRepository.AddSelectionForDB(selection);
        }
        public async Task AddParameterToSelection(int []arr,int idSelection)
        {
            Selection selection = await _selectionRepository.GetSelectionById(idSelection);
            List<Parameter> parametersArray = new List<Parameter>(await _parameterRepository.GetParametersByAllId(arr));
            selection.Parameters = parametersArray;
            await _selectionRepository.Save();
        }
    }
}

