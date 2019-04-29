using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Person



    {
        public Person(string firstNameParam, string lastNameParam, string slackParam)
        {
            firstName = firstNameParam;
            lastName = lastNameParam;
            slackHandle = slackParam;
        }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string slackHandle { get; set; }


    }
}
