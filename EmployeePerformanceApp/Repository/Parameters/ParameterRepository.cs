using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository
{
    public class ParameterRepository : IParameterRepository
    {
        private ApplicationContext _context;
        public ParameterRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Parameter>> GetAllDataParameter()
        {
            return await _context.Parameters.ToListAsync();
        }

        public async Task<Parameter> GetParameterById(int ID)
        {
            return await _context.Parameters.Where(x => x.ID == ID).FirstOrDefaultAsync();
        }

        public async Task AddParameterForDB(Parameter parameter)
        {
            _context.Parameters.Add(parameter);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteParameterForDB(int ID)
        {
            Parameter parameter = await GetParameterById(ID);
            _context.Remove(parameter);
            await _context.SaveChangesAsync();
        }
        public async Task <List<Parameter>> GetParametersByAllId(int[] ids)
        {
            return await _context.Parameters.Where(x => ids.Contains(x.ID)).ToListAsync();
        }     
    }
}
