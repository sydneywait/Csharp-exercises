﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentExercisesEF.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SlackHandle { get; set; }
        [Required]
        public int CohortId { get; set; }
        public Cohort Cohort { get; set; }
        [Display(Name = "Assigned Exercises")]
        public List<StudentExercise> StudentExercises { get; set; } = new List<StudentExercise>();
    }
}