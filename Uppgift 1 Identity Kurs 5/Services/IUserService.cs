using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgift_1_Identity_Kurs_5.Data;
using Uppgift_1_Identity_Kurs_5.Models;

namespace Uppgift_1_Identity_Kurs_5.Services
{
   public interface IUserService
    {
        Task CreateAdminAsync();

        Task<IdentityResult> CreateNewUserAsync(ApplicationUser user, string password);

        Task AddUserToRole(ApplicationUser user, string roleName);
        Task<IEnumerable<TeacherToClass>> GetSpecificUser(string id);

        Task<IEnumerable<UserViewModel>> GetAllUsers();

        IEnumerable<IdentityRole> GetAllRoles();

       Task<IEnumerable<UserViewModel>> GetAllTeachersAsync();

    }
}
