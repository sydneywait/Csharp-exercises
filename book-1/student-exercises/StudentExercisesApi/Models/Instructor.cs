using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesApi.Models
{
    public class Instructor : Person
    {

        [Required]
        public  string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string slackHandle { get; set; }

    }




}

