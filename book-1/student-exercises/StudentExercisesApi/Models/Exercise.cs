using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentExercisesApi.Models
{
    public class Exercise
        {
                
        public int Id { get; set; }
        [Required]  
        public string name { get; set; }
        [Required]
        public string programLang { get; set; }

        public List<Student> assignedStudents = new List<Student>();


    }
}
