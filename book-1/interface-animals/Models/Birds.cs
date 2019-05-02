using System;

namespace interface_animals
{
    public class Bird : IFlying

    {
        public Bird(string nameParam){
            name = nameParam;
            hasFeathers=true;
        }

        public int maxHeight { get; set; }
        public int speed { get; set; }
        public bool hasFeathers { get; set; }
        public string name {get; set;}


        public void fly()
        {
            Console.WriteLine($"{name} the bird is flying");
        }
    }
}