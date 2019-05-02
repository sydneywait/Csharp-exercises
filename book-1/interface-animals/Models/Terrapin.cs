using System;

namespace interface_animals
{
    public class Terrapin : LandCritter, IDigging, IWalking, ISwimming

    {
        public Terrapin(string nameParam, string typeParam) : base(nameParam, typeParam)
        {
            name = nameParam;
            type=typeParam;
        }


        public void dig()
        {
            Console.WriteLine($"{name} the {type} is digging");
        }


        public void swim()
        {
            Console.WriteLine($"{name} the {type} is swimming");
        }

        public bool hasLegs { get; set; }
        public int maxDepth { get; set; }
        public bool isMammal { get; set; }
        public bool isSaltWater { get; set; }
    }
}