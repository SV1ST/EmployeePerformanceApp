using EmployeePerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository
{
    public interface IMarkRepository
    {
        Task AddMark(Mark mark);
        Task<List<Mark>> GetAllDataMark();
        Task<Mark> GetMarkById(int id);
        
    }
}
