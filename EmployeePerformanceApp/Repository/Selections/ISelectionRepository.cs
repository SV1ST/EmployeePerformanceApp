using EmployeePerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository.Selections
{
    public interface ISelectionRepository
    {
        Task<List<Selection>> GetAllDataSelection();
        Task<Selection> GetSelectionById(int id);
        Task AddSelectionForDB(Selection selection);
        Task DeleteSelectionForDB(int id);
    }
}
