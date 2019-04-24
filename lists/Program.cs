using System;
using System.Collections.Generic;

namespace lists
{
    class Program
    {
        static void Main(string[] args)
        {


            List<string> planetList = new List<string>() { "Mercury", "Mars" };

            // Add() Jupiter and Saturn at the end of the list.
            planetList.Add("Jupiter");
            planetList.Add("Saturn");


            // Create another List that contains that last two planet of our solar system.

            List<string> otherPlanetList = new List<string>(){
                "Uranus",
                "Neptune"
            };
            // Combine the two lists by using AddRange().

            planetList.AddRange(otherPlanetList);
            // Use Insert() to add Earth, and Venus in the correct order.
            planetList.Insert(3, "Earth");
            planetList.Insert(2, "Venus");
            // Use Add() again to add Pluto to the end of the list.
            planetList.Add("Pluto");

            // Now that all the planets are in the list, slice the list using GetRange() in order to extract the rocky planets into a new list called rockyPlanets. The rocky planets will remain in the original planets list.

            List<string> rockyPlanets = new List<string>() { };
            rockyPlanets.AddRange(planetList.GetRange(0, 4));
            Console.WriteLine("List of the Rocky Planets:");
            rockyPlanets.ForEach(planet => Console.WriteLine($" -{planet}"));

            Console.WriteLine("List of all the Planets:");
            planetList.ForEach(planet => Console.WriteLine($" -{planet}"));

            // Being good amateur astronomers, we know that Pluto is now a dwarf planet, so use the Remove() method to eliminate it from the end of planetList.
            planetList.Remove("Pluto");
            Console.WriteLine("Planet List without Pluto:");
            planetList.ForEach(planet => Console.WriteLine($" -{planet}"));


            Random random = new Random();
            List<int> numbers = new List<int> {
                random.Next(6),
                random.Next(6),
                random.Next(6),
                random.Next(6),
                random.Next(6),
                random.Next(6),
            };

            Console.WriteLine($"length of numberList {numbers.Count}");

            for (int i = 0; i < numbers.Count; i++)

            {
                // Determine if the current loop index is contained inside of the `numbers` list. Print a message to the console indicating whether the index is in the list.
                if(numbers.Contains(i))
                {
                Console.WriteLine($"the number list contains {i}");
                }
                else{
                    Console.WriteLine($"The number list does not contain {i}");
                }

            }

            // End Main
        }
    }
}
