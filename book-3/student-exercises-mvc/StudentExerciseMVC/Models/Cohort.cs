using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExerciseMVC.Models
{
    public class Cohort
    {

        public int Id { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 5)]
        public string Name { get; set; }

        public List<Student> students = new List<Student>();
        public List<Instructor> instructors = new List<Instructor>();

        // Enroll student by individual or by list (polymorphism)
        public void EnrollStudent(Student newStudent)
        {
            newStudent.CurrentCohort = this;
            students.Add(newStudent);
        }
        public void EnrollStudent(List<Student> newStudents)
        {
            foreach (Student currentStudent in newStudents)
            {
                EnrollStudent(currentStudent);
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
