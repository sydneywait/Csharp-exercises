using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesEF.Models.ViewModels
{
    public class CohortReportViewModel
    {
        public int selectedCohortId { get; set; }

        public SelectList Cohorts { get; set; }
        public List<Student> BusyStudents { get; set; } = new List<Student>();
        public List<Student> LazyStudents { get; set; } = new List<Student>();
        public List<StudentExercise> TopThreeExercise { get; set; } = new List<StudentExercise>();




    }
}
