using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string slackHandle { get; set; }
        public int cohortId { get; set; }
        public Cohort currentCohort { get; set; }
    }
}
