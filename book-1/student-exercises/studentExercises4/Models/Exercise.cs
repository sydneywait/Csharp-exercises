using System;
using System.Collections.Generic;

namespace StudentExercises.Models
{
    class Exercise

    {

        public Exercise(int idParam, string nameParam, string langParam)
        {
            Id = idParam;
            name = nameParam;
            programLang = langParam;

        }
        public int Id { get; set; }
        public string name { get; set; }
        public string programLang { get; set; }


    }
}
