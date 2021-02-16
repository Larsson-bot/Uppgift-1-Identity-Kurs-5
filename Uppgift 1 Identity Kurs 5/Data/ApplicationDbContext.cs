using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Uppgift_1_Identity_Kurs_5.Data;

namespace Uppgift_1_Identity_Kurs_5.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        
        public DbSet<SchoolClass> Classes { get; set; }
        //public DbSet<Uppgift_1_Identity_Kurs_5.Data.UserViewModel> UserViewModel { get; set; }


    }
}
