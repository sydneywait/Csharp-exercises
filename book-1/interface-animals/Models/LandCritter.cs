using System;

namespace interface_animals
{
    public class LandCritter : IWalking
    {
        public LandCritter(string nameParam, string typeParam){
            name = nameParam;
            type = typeParam;
        }

        public string name { get; set; }
        public string type {get; set;}
        public int numberOfLegs { get; set; }

        public void walk()
        {
            Console.WriteLine($"{name} the {type} is walking");
        }
    }
}