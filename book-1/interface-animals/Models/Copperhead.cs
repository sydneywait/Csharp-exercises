using System;

namespace interface_animals
{
    public class Copperhead : Snake, ISwimming
    {
        public Copperhead(string nameParam)
        {
            name = nameParam;
        }
        public void swim()
        {
            Console.WriteLine($"{name} the Copperhead is swimming toward you");
        }
        public int maxDepth { get; set; }
        public bool isMammal { get; set; }
        public bool isSaltWater { get; set; }
    }
}