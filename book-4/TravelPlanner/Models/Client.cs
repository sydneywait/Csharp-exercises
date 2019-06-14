using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class Client
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Enter a valid phone number (xxx-xxx-xxxx)")]
        public string PhoneNumber { get; set; }

        public bool isArchived { get; set; }

        public string AgentId { get; set; }
        public ApplicationUser Agent { get; set; }

        public List<Trip> Trips { get; set; } = new List<Trip>();
        public List<Location> Locations { get; set; } = new List<Location>();
        
    }
}
