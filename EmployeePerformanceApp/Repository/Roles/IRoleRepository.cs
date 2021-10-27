﻿using EmployeePerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository.Roles
{
     public interface IRoleRepository
    {
        Task<List<Role>> GetAllDataRole();
    }
}