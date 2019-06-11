using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesEF.Models.ViewModels
{
    public class CohortReportViewModel
    {
        public int selectedCohortId { get; set; } = 0;

        public SelectList Cohorts { get; set; }
        public List<CohortStudentReport> BusyStudents { get; set; } 
        public List<CohortStudentReport> LazyStudents { get; set; } = new List<CohortStudentReport>();
        public List<CohortExerciseReport> TopThreeExercise { get; set; } = new List<CohortExerciseReport>();




    }
}
