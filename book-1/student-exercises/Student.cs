using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Student:Person
    {
        public Student(string firstNameParam, string lastNameParam, string slackParam):base(firstNameParam, lastNameParam, slackParam){

            exercises = new List<Exercise>();
        }
        public List<Exercise> exercises {get; set;}


    }
}
