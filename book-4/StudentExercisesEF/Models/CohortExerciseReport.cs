using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesEF.Models
{
    public class CohortExerciseReport
    {
        public Exercise exercise { get; set; }
        public int StudentCount { get; set; }
    }
}
