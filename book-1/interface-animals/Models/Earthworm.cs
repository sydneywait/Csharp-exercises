using System;

namespace interface_animals
{
    public class Earthworm : IDigging, ISlither
    {

        public Earthworm(string nameParam)
        {
            name = nameParam;
        }

        public void dig()
        {
            Console.WriteLine($"{name} the earthworm is digging");

        }

        public void slither()
        {
            Console.WriteLine($"{name} the earthworm is slithering");
        }

        string name { get; set; }
        public bool hasLegs { get; set; }
        public bool isPoisonous { get; set; }
    }
}