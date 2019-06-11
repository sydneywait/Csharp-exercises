using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesEF.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        public SelectList Cohorts { get; set; }
        public Student student { get; set; }
    }
}
