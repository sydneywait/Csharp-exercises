using System;
using System.Collections.Generic;

namespace sets
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create an empty HashSet named Showroom that will contain strings.

            HashSet<string> Showroom = new HashSet<string>();
            // Add four of your favorite car model names to the set.

            Showroom.Add("Mazda Miata");
            Showroom.Add("Toyota Prius");
            Showroom.Add("Subaru Outback");
            Showroom.Add("Dodge Ram");


            // Print to the console how many cars are in your show room.

            Console.WriteLine($"The total number of cars is {Showroom.Count}");
            // Pick one of the items in your show room and add it to the set again.

            Showroom.Add("Subaru Outback");
            // Print your showroom again, and notice how there's still only one representation of that model in there.
            Console.WriteLine($"The total number of cars is {Showroom.Count}");
            // Create another set named UsedLot and add two more car model strings to it.

            HashSet<string> UsedLot = new HashSet<string>();
            UsedLot.Add("Honda Civic");
            UsedLot.Add("Kia Sorrento");

            // Use the UnionWith() method on Showroom to add in the two models you added to UsedLot.

            Showroom.UnionWith(UsedLot);
            Console.WriteLine($"You now have {Showroom.Count} cars");
            foreach (string car in Showroom)
            {
                Console.WriteLine($"  -{car}");
            }
            // You've sold one of your cars. Remove it from the set with the Remove() method.

            Showroom.Remove("Dodge Ram");
            Console.WriteLine($"You sold a car. You now have {Showroom.Count} cars");
            foreach (string car in Showroom)
            {
                Console.WriteLine($"  -{car}");
            }

            // Now create another HashSet of cars in a variable Junkyard. Someone who owns a junkyard full of old cars has approached you about buying the entire inventory. In the new set, add some different cars, but also add a few that are the same as in the Showroom set.
            HashSet<string> Junkyard = new HashSet<string>(){

                "Dodge Ram", "Nissan Sentra", "Volkswagon Golf", "Honda Pilot", "Mazda Miata", "Toyota Prius"
            };


            // Create a new HashSet of your show room with HashSet<string> clone = new HashSet<string>(Showroom);
            // Use the IntersectWith() method on the clone to see which cars exist in both the show room and the junkyard.

            HashSet<string> clone = new HashSet<string>(Showroom);
            clone.IntersectWith(Junkyard);
            Console.WriteLine($"These cars are duplicates in the junkyard");
            foreach (string car in clone)
            {
                Console.WriteLine($"  -{car}");
            }


            // Now you're ready to buy the cars in the junkyard. Use the UnionWith() method to combine the junkyard into your showroom.

            Showroom.UnionWith(Junkyard);

            Console.WriteLine($"You acquired new vehicles from the junkyard!  You now have {Showroom.Count} cars");
            foreach (string car in Showroom)
            {
                Console.WriteLine($"  -{car}");
            }
            // Use the Remove() method to remove any cars that you acquired from the junkyard that you don't want in your showroom.

            Showroom.Remove("Nissan Sentra");

            Console.WriteLine($"You sold a car!  You now have {Showroom.Count} cars");
            foreach (string car in Showroom)
            {
                Console.WriteLine($"  -{car}");
            }





        }
    }
}
