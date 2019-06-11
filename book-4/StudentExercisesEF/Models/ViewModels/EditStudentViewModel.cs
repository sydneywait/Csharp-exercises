using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesEF.Models.ViewModels
{
 
    public class EditStudentViewModel
    {

        public SelectList Cohorts { get; set; }
        public SelectList Exercises { get; set; }
        public List<StudentExercise> AssignedExercises { get; set; }
        public List<int> ExerciseIds { get; set; } = new List<int>();
        //need to make a list of the assigned integers as come back from the form

        public Student student { get; set; }

       
    }
}

