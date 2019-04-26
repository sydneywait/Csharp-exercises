using System;
using System.Collections.Generic;

namespace student_exercises_classes
{
    class Cohort

    {
        public Cohort(string nameParam)
        {
            name = nameParam;
            students = new List<Student>();
            instructors = new List<Instructor>();
        }

        public string name { get; set; }
        public List<Student> students { get; set; }
        public List<Instructor> instructors { get; set; }

    }
}
