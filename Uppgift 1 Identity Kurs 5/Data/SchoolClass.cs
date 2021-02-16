using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgift_1_Identity_Kurs_5.Data
{
    public class SchoolClass
    {

        public SchoolClass(string id)
        {
            Id = id;
        }

        public SchoolClass()
        {

        }

        [Required]
        [Key]
        public string Id { get; set; }

        public ApplicationUser Teacher { get; set; }

        public virtual ICollection<ApplicationUser> Students { get; set; }
    }
}
