using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository.Selections
{
    public class SelectionRepository : ISelectionRepository
    {
        private ApplicationContext _context;
        public SelectionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddSelectionForDB(Selection selection)
        {
            _context.Selections.Add(selection);
            await _context.SaveChangesAsync();
        }

        public Task DeleteSelectionForDB(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Selection>> GetAllDataSelection()
        {
            return await _context.Selections.Include(x => x.Department).Include(x => x.Parameters).ToListAsync();
        }

        public async Task<Selection> GetSelectionById(int ID)
        {
            return await _context.Selections.Where(x => x.ID == ID).FirstOrDefaultAsync();
        }
    }
}
