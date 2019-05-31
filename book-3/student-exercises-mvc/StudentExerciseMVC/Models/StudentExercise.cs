using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExerciseMVC.Models
{
    public class StudentExercise
    {

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExerciseId { get; set; }
        [Display(Name ="Completed?")]
        public bool isComplete { get; set; }
        public Exercise exercise { get; set; } 
        public Student student { get; set; }
    }
}
