using EmployeePerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
{
    public interface IMarkService
    {
        Task AddMark(int userId, int parameterId, int markValue, string markDescription);
        Task<AddMarkViewModel> AddMarkViewForLead();
        Task<AddMarkViewModel> AddMarkViewForLeadWithSomeParameter(string _lastName, string _firstName, string _status, string _role);
        Task<AddMarkViewModel> AddMarkActionViewForLead(int userID);
        Task<AddMarkViewModel> AddMarkViewForChief();
        Task<AddMarkViewModel> AddMarkViewForChiefWithSomeParameter(string _lastName, string _firstName, string _status, string _role);
        Task<AddMarkViewModel> AddMarkActionViewForChief(int userID);
        Task<ShowAllMarksViewModel> ShowAllMarksForChief();
        Task<ShowAllMarksViewModel> ShowAllActualMarksForChief();
    }
}
