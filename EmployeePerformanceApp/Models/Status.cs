using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Models
{
    public class Status
    {
        public int ID { get; set; }
        public string StatusName { get; set; }

        public List<User> Users { get; set; }
        public Status()
        {
            Users = new List<User>();
        }
    }
}
