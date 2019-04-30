using System;
using System.Collections.Generic;

namespace student_exercises
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

        // Enroll student by individual or by list (polymorphism)
         public void enrollStudent(Student newStudent)
        {
            newStudent.CurrentCohort = this;
            students.Add(newStudent);
        }
        public void enrollStudent(List<Student> newStudents)
        {
            foreach (Student currentStudent in newStudents)
            {
                enrollStudent(currentStudent);
            }
        }

         public void addInstructor(Instructor newInstructor)
        {
            newInstructor.CurrentCohort = this;
            instructors.Add(newInstructor);
        }
        public void addInstructor(List<Instructor> newInstructors)
        {
            foreach (Instructor currentInstructor in newInstructors)
            {
                addInstructor(currentInstructor);
            }
        }


    }
}
