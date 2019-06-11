using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesEF.Models.ViewModels
{
    public class InstructorEditViewModel

    {
        public Instructor instructor { get; set;}
        public SelectList Cohort { get; set; }


    }
}
