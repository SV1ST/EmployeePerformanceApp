using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service.Parameters
{
    public interface IParameterService
    {
        Task CreateParameterService(string name);
    }
}
