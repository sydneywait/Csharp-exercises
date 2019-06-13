using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models 
{
    public class Trip : IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((DateTime.Compare(EndDate, StartDate) < 0))
            {
                yield return new ValidationResult(
                    $"End date must be later than the start date.",
                    new[] { "EndDate" });
            }
        }
    }
}
