using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Models
{
    public class GetTopBySelectSelectionViewModel
    {
        public int getCurrentSelectionId { get; set; }
        public string getCurrentSelectionName { get; set; }
        public IEnumerable<Selection> Selections { get; set; }
        public IEnumerable<User> UserTop { get; set; }
        public IEnumerable<User> UserBottom { get; set; }
    }
}
