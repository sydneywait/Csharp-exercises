using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesApi.Models
{
    public class Student : Person
    {
        public List<Exercise> exercises = new List<Exercise>();
    }
}
