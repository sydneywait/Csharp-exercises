using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Exercise

    {

        public Exercise(string nameParam, string langParam)
        {
            name = nameParam;
            programLang = langParam;

        }
        public string name { get; set; }
        public string programLang { get; set; }


    }
}
