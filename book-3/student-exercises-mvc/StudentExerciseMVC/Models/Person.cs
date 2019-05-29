using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExerciseMVC.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "Slack Handle")]
        public string SlackHandle { get; set; }
        [Display(Name = "Cohort Id")]
        public int CohortId { get; set; }
        [Display(Name = "Current Cohort")]
        public Cohort CurrentCohort { get; set; }
    }
}
