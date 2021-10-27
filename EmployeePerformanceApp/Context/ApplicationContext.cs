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
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

            Role adminRole = new Role { ID = 1, RoleName = "Admin" };
            Role chiefRole = new Role { ID = 2, RoleName = "Chief" };
            Role leadRole = new Role { ID = 3, RoleName = "Lead" };
            Role employeeRole = new Role { ID = 4, RoleName = "Employee" };

            Status workingStatus = new Status { ID = 1, StatusName = "Working" };
            Status firedStatus = new Status { ID = 2, StatusName = "Fired" };

            Department adminsDepartment = new Department { ID = 1, DepartmentName = "Admins", ShowPreviousMarks = true };
            Department programmersDepartment = new Department { ID = 2, DepartmentName = "Programmers", ShowPreviousMarks = true };
            Department testersDepartment = new Department { ID = 3, DepartmentName = "Testers", ShowPreviousMarks = true };

            User adminUser = new User { ID = 1, FirstName = "Head", LastName = "Administrator", Login = "admin", Password = "123", RoleId = adminRole.ID, StatusId = workingStatus.ID, DepartmentId = adminsDepartment.ID };
            User user1User = new User { ID = 2, FirstName = "Ivan", LastName = "Karpov", Login = "user1", Password = "123", RoleId = employeeRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };
            User user2User = new User { ID = 3, FirstName = "Anastasia", LastName = "Mironova", Login = "user2", Password = "123", RoleId = employeeRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };
            User user3User = new User { ID = 4, FirstName = "Vladimir", LastName = "Kruglov", Login = "user3", Password = "123", RoleId = employeeRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };
            User leadUser = new User { ID = 5, FirstName = "Ivan", LastName = "Bachurin", Login = "lead443", Password = "123", RoleId = leadRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };
            User chiefUser = new User { ID = 6, FirstName = "James", LastName = "Bright", Login = "chief234", Password = "123", RoleId = chiefRole.ID, StatusId = workingStatus.ID, DepartmentId = programmersDepartment.ID };
            User user4User = new User { ID = 7, FirstName = "Konstantin", LastName = "Voronin", Login = "kostya123", Password = "123", RoleId = employeeRole.ID, StatusId = workingStatus.ID, DepartmentId = testersDepartment.ID };
            User user5User = new User { ID = 8, FirstName = "Vladislav", LastName = "Erovoy", Login = "vlad123", Password = "123", RoleId = employeeRole.ID, StatusId = workingStatus.ID, DepartmentId = testersDepartment.ID };
            User user6User = new User { ID = 9, FirstName = "Borat", LastName = "Boratovich", Login = "borat123", Password = "123", RoleId = employeeRole.ID, StatusId = workingStatus.ID, DepartmentId = testersDepartment.ID };
            User lead2User = new User { ID = 10, FirstName = "Ilias", LastName = "Vasiliev", Login = "IL44312", Password = "123", RoleId = leadRole.ID, StatusId = workingStatus.ID, DepartmentId = testersDepartment.ID };
            User chief2User = new User { ID = 11, FirstName = "James", LastName = "Kyk", Login = "kyk239", Password = "123", RoleId = chiefRole.ID, StatusId = workingStatus.ID, DepartmentId = testersDepartment.ID };

            Parameter parameter1 = new Parameter { ID = 1, ParameterName = "Productive skills", Coefficient = 0 };
            Parameter parameter2 = new Parameter { ID = 2, ParameterName = "Communication skills", Coefficient = 0 };
            Parameter prameter3 = new Parameter { ID = 3, ParameterName = "Linguistic skills", Coefficient = 0 };
            Parameter parameter4 = new Parameter { ID = 4, ParameterName = "Leadership skills", Coefficient = 0 };


            modelBuilder.Entity<Selection>(x => {
                x.Navigation(s => s.Parameters).AutoInclude();
            });
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, chiefRole, leadRole, employeeRole });
            modelBuilder.Entity<Status>().HasData(new Status[] { workingStatus, firedStatus });
            modelBuilder.Entity<Department>().HasData(new Department[] { adminsDepartment, programmersDepartment, testersDepartment });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, user1User, user2User, user3User, leadUser, chiefUser, user4User, user5User, user6User, lead2User, chief2User });
            modelBuilder.Entity<Parameter>().HasData(new Parameter[] { parameter1, parameter2, prameter3, parameter4 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
