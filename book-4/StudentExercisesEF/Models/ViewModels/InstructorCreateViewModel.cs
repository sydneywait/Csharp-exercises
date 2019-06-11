using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesEF.Models.ViewModels
{
    public class InstructorCreateViewModel
    {
        public SelectList Cohorts { get; set; }
        public Instructor instructor { get; set; }
    }
}
