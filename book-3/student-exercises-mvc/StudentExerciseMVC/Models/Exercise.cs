using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentExerciseMVC.Models
{
    public class Exercise
        {
                
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        [Required]
        public string ProgramLang { get; set; }

        public List<Student> assignedStudents = new List<Student>();


    }
}
