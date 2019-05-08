using System;
using System.Collections.Generic;

namespace StudentExercises.Models
{
    class Cohort

    {
        public Cohort(int idParam, string nameParam)
        {
            Id = idParam;
            name = nameParam;
            students = new List<Student>();
            instructors = new List<Instructor>();
        }

        public string name { get; set; }
        public int Id { get; set; }
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
