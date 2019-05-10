using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesApi.Models
{
    public class Cohort
    {

        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        public List<Student> students = new List<Student>();
        public List<Instructor> instructors = new List<Instructor>();

        // Enroll student by individual or by list (polymorphism)
        public void enrollStudent(Student newStudent)
        {
            newStudent.currentCohort = this;
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
            newInstructor.currentCohort = this;
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
