﻿using EmployeePerformanceApp.Context;
using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Repository.Users;
using EmployeePerformanceApp.Service.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public AccountController(IUserRepository userRepository , IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }
      
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string pass = model.Password;
                string log = model.Login;

                User user = await _userRepository.CheckUserByLoginPassword(log, pass);    
                
 
                if (user != null && user.RoleId == 2)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Chief");                  
                }
                else if (user != null && user.RoleId == 1)
                {
                    await Authenticate(user);
                    return RedirectToAction("Index", "Admin");
                }
                else if (user != null && user.RoleId == 3)
                {
                    await Authenticate(user);
                    return RedirectToAction("Index", "Lead");
                }
                else if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "Please, Enter Values.");
                }
                else
                ModelState.AddModelError(string.Empty, "Invalid login or password attempt.");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        private async Task Authenticate(User employee)
        {

            // создаем один claim
            var claims = new List<Claim>
            {

                new Claim(ClaimsIdentity.DefaultNameClaimType, employee.Login),
                new Claim("Id", employee.ID.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, employee.Role?.RoleName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
    
