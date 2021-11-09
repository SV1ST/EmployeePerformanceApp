using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository
{
    public class MarkRepository : IMarkRepository
    {
        private ApplicationContext _context;
        public MarkRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddMark(Mark mark)
        {
            _context.Marks.Add(mark);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Mark>> GetAllDataMark()
        {
            return await _context.Marks.Include(x => x.User).Include(x => x.Parameter).ToListAsync();
        }

        public async Task<List<Mark>> GetMarkByUserAndDepartmentIds(int userId, int parameterId)
        {
            return await _context.Marks.Where(x => x.UserId == userId && x.ParameterId == parameterId).ToListAsync();
        }
    }
}
