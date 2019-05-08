using System;
using System.Collections.Generic;

namespace StudentExercises.Models
{
    class Student:Person
    {
        public Student(string firstNameParam, string lastNameParam, string slackParam):base(firstNameParam, lastNameParam, slackParam){

            exercises = new List<Exercise>();
        }
        public List<Exercise> exercises {get; set;}


    }
}
