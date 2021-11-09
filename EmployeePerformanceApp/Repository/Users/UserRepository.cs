using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(ApplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<List<User>> GetUsersByDepartmentId(int id)
        {
            return await _context.Users.Where(x => x.DepartmentId == id).ToListAsync();
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
        public async Task<List<User>> GetUsersByDepartmentIdNotChief(int id)
        {
            int currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value);
            User currentUser = await GetUserById(currentUserId);

            return await _context.Users
                .Include(x => x.Marks)
                .Include(u => u.Role)
                .Include(u => u.Status)
                .Include(u => u.Department)
                .Where(x => x.DepartmentId == id && x.RoleId != currentUser.RoleId)
                .ToListAsync();
        }

        public async Task UpdateUserForDB()
        {
            await _context.SaveChangesAsync();
        }
    }
}
    

