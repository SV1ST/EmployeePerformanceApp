using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(int id)
        {
            User user = await _context.Users.Where(x => x.ID == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> GetUserByLoginPassword(LoginModel model)
        {
            User user = await _context.Users.Include(u => u.Role).Where(u => u.Login == model.Login && u.Password == model.Password).FirstOrDefaultAsync();
            return user;
        }
        public async Task<User> CheckUserByLoginPassword(string userLogin, string userPassword)
        {
            User user = await _context.Users.Include(u => u.Role).Include(u => u.Status).Include(u => u.Department).Where(u => u.Login == userLogin && u.Password == userPassword).FirstOrDefaultAsync();

            
            if (user != null && String.Equals(user.Login, userLogin) && String.Equals(user.Password, userPassword))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
    

