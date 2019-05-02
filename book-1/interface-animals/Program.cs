using System;

namespace interface_animals
{
    class Program
    {
        static void Main(string[] args)
        {

Bat henry = new Bat(){
    name ="Henry",
    maxHeight = 100,
    speed = 50,
    hasFeathers = false,
    isVampire = true,

};

henry.fly();

Penguin perry = new Penguin(){
    name = "Perry",
    isMammal = false,
    isSaltWater = true,
    maxDepth = 10
};

perry.walk();
perry.slide();
perry.swim();


// This is the list of animals you want to own and care for.

// Parakeets
// Earthworms
// Terrapins
// Timber Rattlesnake
// Mice
// Ants
// Finches
// Betta Fish
// Copperhead snake
// Gerbils

Parakeet polly = new Parakeet("Polly"){};
Ant alvin = new Ant("Alvin", "Ant");
Betta betty = new Betta("Betty");
Copperhead cooper = new Copperhead("Cooper");
Earthworm earl = new Earthworm("Earl");
Finch fred = new Finch("Fred");
Gerbil gary = new Gerbil("Gary", "gerbil");
Mouse minnie = new Mouse ("Minnie", "mouse");
Terrapin terry = new Terrapin("Terry", "terrapin");
TimberRattlesnake timmy = new TimberRattlesnake("Timmy");

FlyerContainer Flyers = new FlyerContainer(){
    flyers = {henry, fred, polly}
};

SwimmerContainer Swimmers = new SwimmerContainer(){
    swimmers = {betty, terry}
};

SnakeContainer Snakes = new SnakeContainer(){
    snakes={cooper, timmy, earl}
};

SmallMoverContainer SmallMovers = new SmallMoverContainer(){
    smallMovers={gary, minnie, alvin}
};






        }
    }
}
