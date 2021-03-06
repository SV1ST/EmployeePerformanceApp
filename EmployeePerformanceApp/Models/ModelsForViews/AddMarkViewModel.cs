using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Models
{
    public class AddMarkViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string StatusName { get; set; }
        public string RoleName { get; set; }
        public int CurrentUserDepartmentId { get; set; }
        public int UserId { get; set; }
        public int CurrentUserRoleId { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
        public IEnumerable <Mark> Marks { get; set; }
    }
}
