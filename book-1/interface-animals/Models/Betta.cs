using System;

namespace interface_animals
{

    class Betta : ISwimming
    {

        public Betta(string nameParam)
        {
            name = nameParam;
        }


        public int maxDepth { get; set; }
        public bool isMammal { get; set; }
        public bool isSaltWater { get; set; }
        public string name { get; set; }

        public void swim()
        {
            Console.WriteLine($"{name} the Betta is swimming");
        }
    }




}