using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgift_1_Identity_Kurs_5.Data;
using Uppgift_1_Identity_Kurs_5.Models;

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

        public async Task AddUserToRole(ApplicationUser user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
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

        public async Task<IdentityResult> CreateNewUserAsync(ApplicationUser user, string password)
        {
           return await _userManager.CreateAsync(user, password);
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            
            return _roleManager.Roles;    
        }

        public async Task<IEnumerable<UserViewModel>> GetAllTeachersAsync()
        {
            var users = _userManager.Users;
            var userlist = new List<UserViewModel>();
            foreach (var user in users)
            {
                
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();
                if(role == "Teacher")
                {
                    userlist.Add(new UserViewModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Role = role
                    });
                }
                


            
            }
            return userlist;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            var users = _userManager.Users;
            var userlist = new List<UserViewModel>();
            foreach(var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                userlist.Add(new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = role
                });
            }
            return userlist;
        }

        public async Task<IEnumerable<TeacherToClass>> GetSpecificUser(string id)
        {
            var userlist = new List<TeacherToClass>();
            var list = await  GetAllTeachersAsync();

     
            return userlist;
        }
    }
}
