using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository
{
    public class SelectionRepository : ISelectionRepository
    {
        private readonly IParameterRepository _parameterRepository;
        private ApplicationContext _context;
        public SelectionRepository(ApplicationContext context,  IParameterRepository parameterRepository)
        {
            _context = context;

            _parameterRepository = parameterRepository;
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
            return await _context.Selections.Include(x => x.Parameters).Where(x => x.ID == ID).FirstOrDefaultAsync();
        } 
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
