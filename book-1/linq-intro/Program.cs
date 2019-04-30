using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_intro
{
    class Program
    {
        static void Main(string[] args)
        {

            // Restriction/Filtering Operations
            Console.WriteLine("*****Restriction/Filtering Operations*****");
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            List<string> LFruits = (from fruit in fruits where fruit.Substring(0, 1) == "L" orderby fruit select fruit).ToList();

            //
            Console.WriteLine("Fruits that start with 'L':");
            LFruits.ForEach(f => Console.Write($" {f}"));
            Console.WriteLine("");
            Console.WriteLine("------------------");
            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

            List<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0).ToList();

            Console.WriteLine($"multiple of 4 or 6:");
            fourSixMultiples.ForEach(n => Console.Write($" {n}"));
            Console.WriteLine("");
            Console.WriteLine("------------------");



            // Ordering Operations
            Console.WriteLine("*****Ordering Operations*****");
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
{
    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
    "Francisco", "Tre"
};

            List<string> descend = names.OrderByDescending(n => n).ToList();

            Console.WriteLine("Descending names");
            descend.ForEach(n => Console.Write($" {n}"));
            Console.WriteLine("");
            Console.WriteLine("------------------");


            // Build a collection of these numbers sorted in ascending order
            List<int> theseNumbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

            List<int> ascending = numbers.OrderBy(n => n).ToList();

            Console.WriteLine("Ascending numbers:");
            ascending.ForEach(n => Console.Write($"  {n}"));
            Console.WriteLine("");
            Console.WriteLine("------------------");

            // Aggregate Operations
            Console.WriteLine("*****Aggregate Operations*****");

            // Output how many numbers are in this list
            List<int> num = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

            Console.WriteLine($"How many numbers in the list: {num.Count}");
            Console.WriteLine("------------------");

            // How much money have we made?
            List<double> purchases = new List<double>()
{
    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
};

            double profit = purchases.Sum();
            Console.WriteLine($"How much money have we made? {profit}");
            Console.WriteLine("------------------");

            // What is our most expensive product?
            List<double> prices = new List<double>()
{
    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
};

            double expensive = prices.Max();

            Console.WriteLine($"What is our most expensive product? {expensive}");
            Console.WriteLine("------------------");

            // Partitioning Operations
            Console.WriteLine("*****Partitioning Operations*****");
            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquared = new List<int>()
{
    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
};

            List<int> noSquare = new List<int>();

            wheresSquared.ForEach(n =>
            {
                double numToTest = Math.Sqrt(n);
                if (Math.Sqrt(n)%1 != 0)
                {
                    noSquare.Add(n);
                }
                else
                {
                    Console.WriteLine($"{n} is a perfect square!");
                }


            });
             Console.WriteLine("The following numbers are not perfect squares!");
                noSquare.ForEach(ns => Console.Write($" {ns}"));
                Console.WriteLine("");
                Console.WriteLine("------------------");





            // End Main
        }
    }
}
