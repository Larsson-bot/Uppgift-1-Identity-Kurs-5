using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgift_1_Identity_Kurs_5.Data;
using Uppgift_1_Identity_Kurs_5.Models;
using Uppgift_1_Identity_Kurs_5.Services;

namespace Uppgift_1_Identity_Kurs_5.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminsController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.Roles = _userService.GetAllRoles();
            ViewBag.Users = await _userService.GetAllUsers();
            return View();
        }


        public IActionResult Register()
        {
            var roles = _userService.GetAllRoles().ToList().Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();
            ViewBag.Roles = roles;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(CreateUserViewModel model)
        {
            if (ModelState.IsValid) {

                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
            };

            await _userService.CreateNewUserAsync(user, model.Password);
                var users = await _userManager.GetUsersInRoleAsync("Admin");
                
            if(model.UserRole == null || model.UserRole == "Admin")
            {
                if(users.Count < 1)
                    {
                        await _userService.AddUserToRole(user, model.UserRole);
                    }
                    else
                    {
                        await _userService.AddUserToRole(user, "Student");
                    }
       
            }
            else
                await _userService.AddUserToRole(user, model.UserRole);
            }
            return RedirectToAction("Index");

          
        }

        public async Task<IActionResult> Teacher()
        {
            ViewBag.Teachers = await _userService.GetAllTeachersAsync();
            return View();
        }
    }
}
