using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityPractice.Models
{
    public class ListItem
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
