using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
{
    public interface ISelectionService
    {
        Task CreateSelectionForDB(int departmentID, string selectionName);
        Task AddParameterToSelection(int[] arr, int idSelection);
    }
}
