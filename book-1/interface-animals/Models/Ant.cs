using System;

namespace interface_animals
{
    public class Ant : LandCritter, IDigging, IWalking

    {
        public Ant(string nameParam, string typeParam) : base(nameParam, typeParam)
        {
        }

        public void dig()
        {
            Console.WriteLine($"{name} the ant is digging");
        }
        public bool hasLegs { get; set; }

    }
}