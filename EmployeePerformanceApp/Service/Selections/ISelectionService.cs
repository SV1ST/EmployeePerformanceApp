using ClosedXML.Excel;
using EmployeePerformanceApp.Models;
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
        Task<CreateSelectionViewModel> CreateSelectionShowSevice(int chosenDepartmentId);
        Task<CreateSelectionViewModel> CreateSelectionAction(int selectionID, string selectionName, int chosenDepartmentId);
        Task<ShowAllSlectionsByCurrentDepartmentViewModel> ShowAllSelections(int ID);
        Task<ShowAllSlectionsByCurrentDepartmentViewModel> ShowAllSelections();
        Task<GetTopBySelectSelectionViewModel> GetTopBySelectSelection(int selectionID);

    }
}
