using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private ApplicationContext _context;
        public StatusRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Status>> GetAllDataStatus()
        {
            return await _context.Statuses.ToListAsync();
        }

    }
}
