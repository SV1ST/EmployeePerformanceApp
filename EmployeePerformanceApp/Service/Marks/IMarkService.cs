﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
{
    public interface IMarkService
    {
        Task AddMark(int userId, int parameterId, int markValue, string markDescription);
    }
}
