using System;
using System.Collections.Generic;

namespace student_exercises_classes
{
    class Instructor : Person

    {
        public Instructor(string firstNameParam, string lastNameParam, string slackParam) : base(firstNameParam, lastNameParam, slackParam) { }

        public void assignExercise(Student studentName, Exercise exerciseName)
        {
            studentName.exercises.Add(exerciseName);

        }



    }
}
