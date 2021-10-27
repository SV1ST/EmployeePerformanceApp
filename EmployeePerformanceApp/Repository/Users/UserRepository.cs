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
        public async Task<List<User>> GetAllDataUser()
        {
            return  await _context.Users.Include(u => u.Role).Include(u => u.Status).Include(u => u.Department).ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            User user = await _context.Users.Where(x => x.ID == id).FirstOrDefaultAsync();
            return (user != null) ? user : null;
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

        public async Task<User> CheckByLoginForCreateNewUser(string login)
        {
            return await _context.Users.Where(x => x.Login == login).FirstOrDefaultAsync();
          
        }
        public async Task AddUserForDB(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserForDB(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllSubordinatesUser(int IDDep, int IDRole)
        {
            return await _context.Users.Where(x => x.DepartmentId == IDDep && x.RoleId == IDRole).Include(u => u.Role).Include(u => u.Status).Include(u => u.Department).ToListAsync();
        }
    }
}
    

