using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Selection> Selections { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            

            Role adminRole = new Role { ID = 1, RoleName = "Admin" };
            Role chiefRole = new Role { ID = 2, RoleName = "Chief" };
            Role leadRole = new Role { ID = 3, RoleName = "Lead" };
            Role employeeRole = new Role { ID = 4, RoleName = "Employee" };

            Status workingStatus = new Status { ID = 1, StatusName = "Working" };
            Status firedStatus = new Status { ID = 2, StatusName = "Fired" };

            Department programmersDepartment = new Department { ID = 1, DepartmentName = "Programmers", ShowPreviousMarks = true };

            User adminUser = new User { ID = 1, FirstName = "Admin", LastName = "Adminov", Login = "admin", Password = "123", RoleId = adminRole.ID, StatusId = workingStatus.ID };
            User user1User = new User { ID = 2, FirstName = "User1", LastName = "Userov", Login = "user1", Password = "123", RoleId = employeeRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };
            User user2User = new User { ID = 3, FirstName = "User2", LastName = "Userov", Login = "user2", Password = "123", RoleId = employeeRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };
            User user3User = new User { ID = 4, FirstName = "User3", LastName = "Userov", Login = "user3", Password = "123", RoleId = employeeRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };
            User leadUser = new User { ID = 5, FirstName = "Lead", LastName = "Leadov", Login = "lead", Password = "123", RoleId = leadRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };
            User chiefUser = new User { ID = 6, FirstName = "Chief", LastName = "Chiefov", Login = "chief", Password = "123", RoleId = chiefRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };

           

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, chiefRole, leadRole, employeeRole });
            modelBuilder.Entity<Status>().HasData(new Status[] { workingStatus, firedStatus });
            modelBuilder.Entity<Department>().HasData(new Department[] { programmersDepartment });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, user1User, user2User, user3User, leadUser, chiefUser });

            base.OnModelCreating(modelBuilder);
        }
    }
}
