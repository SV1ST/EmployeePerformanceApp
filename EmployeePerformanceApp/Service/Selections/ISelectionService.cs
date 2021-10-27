using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service.Selections
{
    public interface ISelectionService
    {
        Task CreateSelectionForDB(int departmentID, string selectionName, int[] arr);
    }
}
