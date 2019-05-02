using System;

namespace interface_animals
{


    public class Snake : ISlither
    {
        public bool isPoisonous { get; set; }
        public string name { get; set; }

        public void slither()
        {
            Console.WriteLine($"{name} the snake is slithering");
        }
    }
}