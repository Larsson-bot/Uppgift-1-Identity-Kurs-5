using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgift_1_Identity_Kurs_5.Data;

namespace Uppgift_1_Identity_Kurs_5.Models
{
    public class AddTeacher
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
