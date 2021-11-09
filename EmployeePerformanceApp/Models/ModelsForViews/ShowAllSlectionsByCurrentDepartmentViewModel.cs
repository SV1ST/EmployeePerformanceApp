using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Models
{
    public class ShowAllSlectionsByCurrentDepartmentViewModel
    {
        public IEnumerable<Selection> Selections { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
        public int currentDepartmentId { get; set; }
        public string currentDepartmentName { get; set; }
    }
}
