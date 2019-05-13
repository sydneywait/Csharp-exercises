using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesApi.Models
{
    public class Exercise
        {
                
        public int Id { get; set; }
        public string name { get; set; }
        public string programLang { get; set; }

        public List<Student> assignedStudents = new List<Student>();


    }
}
