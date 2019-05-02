using System;

namespace interface_animals{
    public class Bat : IFlying
    {
        public string name {get; set;}
        public int maxHeight { get; set; }
        public int speed { get; set; }
        public bool hasFeathers { get; set; }
        public bool isVampire {get; set;}

        public void fly()
        {
            Console.WriteLine($"{name} the Bat is flying");

        }
    }
}