using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Repository;
using EmployeePerformanceApp.Repository.Roles;
using EmployeePerformanceApp.Repository.Selections;
using EmployeePerformanceApp.Repository.Statuses;
using EmployeePerformanceApp.Repository.Users;
using EmployeePerformanceApp.Service;
using EmployeePerformanceApp.Service.Parameters;
using EmployeePerformanceApp.Service.Selections;
using EmployeePerformanceApp.Service.Users;
using EmployeePerformanceApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DESKTOP-2QMD2OE
            //(localdb)\\mssqllocaldb
            string connection = "Server=DESKTOP-2QMD2OE;Database=EmployeeDiaryAppDB;Trusted_Connection=True;";
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
            });

            services.AddHttpContextAccessor();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IParameterRepository, ParameterRepository>();
            services.AddScoped<ISelectionRepository, SelectionRepository>();
            services.AddScoped<IMarkRepository, MarkRepository>();



            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IParameterService, ParameterService>();
            services.AddScoped<ISelectionService, SelectionService>();
            services.AddScoped<IMarkService, MarkService>();
           
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
