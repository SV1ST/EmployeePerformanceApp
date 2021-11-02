using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Models
{
    public class ShowAllMarksViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
        public int getCurrentUserIdDepartment { get; set; }
    }
}
