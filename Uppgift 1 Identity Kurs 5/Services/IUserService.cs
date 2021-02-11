using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgift_1_Identity_Kurs_5.Data;

namespace Uppgift_1_Identity_Kurs_5.Services
{
   public interface IUserService
    {
        Task CreateAdminAsync();

        IEnumerable<ApplicationUser> GetAllUsers();

        IEnumerable<IdentityRole> GetAllRoles();

    }
}
