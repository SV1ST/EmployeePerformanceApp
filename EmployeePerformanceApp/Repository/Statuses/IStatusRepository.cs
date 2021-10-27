using EmployeePerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository.Statuses
{
     public interface IStatusRepository
    {
        Task<List<Status>> GetAllDataStatus();
    }
}
