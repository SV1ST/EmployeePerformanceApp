using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private ApplicationContext _context;
        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetAllDataRole()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
