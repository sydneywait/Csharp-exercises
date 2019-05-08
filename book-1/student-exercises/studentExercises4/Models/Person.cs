using System;
using System.Collections.Generic;

namespace StudentExercises.Models
{
    class Person



    {
        public Person(string firstNameParam, string lastNameParam, string slackParam)
        {
            firstName = firstNameParam;
            lastName = lastNameParam;
            slackHandle = slackParam;
        }
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string slackHandle { get; set; }
        public Cohort CurrentCohort { get; set; }


    }
}
