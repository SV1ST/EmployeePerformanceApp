using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Models
{
    public class AddParameterViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
    }
}
