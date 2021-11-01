﻿using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> GetAllDataDepartment()
        {
            return await _context.Departments.Include(x => x.Parameters).ToListAsync();
        }
    }
}
