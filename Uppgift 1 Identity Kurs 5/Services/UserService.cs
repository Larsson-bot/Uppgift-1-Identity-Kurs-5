using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgift_1_Identity_Kurs_5.Data;

namespace Uppgift_1_Identity_Kurs_5.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateAdminAsync()
        {
            if (!_userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    UserName = "Admin@domain.com",
                    Email = "Admin@domain.com",
                    FirstName = "Admin",
                    LastName = "Account"
                };
                var result = await _userManager.CreateAsync(user, "BytMig123!");
                if (result.Succeeded)
                {
                    if (!_roleManager.Roles.Any())
                    {
                       await _roleManager.CreateAsync(new IdentityRole("Admin"));
                       await _roleManager.CreateAsync(new IdentityRole("Teacher"));
                       await _roleManager.CreateAsync(new IdentityRole("Student"));
                    }
                }
                await _userManager.AddToRoleAsync(user, "Admin");

            }
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {

            return _roleManager.Roles;    
        }
        
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _userManager.Users;
        }
    }
}
