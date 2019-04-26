using System;
using System.Collections.Generic;

namespace classes
{

    class Program
    {
        static void Main(string[] args)
        {
            // # Lightning Exercise One

            // 1.  Create a new dictionary of items to represent a sandwich. The dictionary should store the following data:
            //     - Bread type
            //     - Price
            //     - Number of calories
            //     - A comma-separated, stringified list of ingredients

            Dictionary<string, string> sandwich = new Dictionary<string, string>(){
                {"breadType", "wheat"},
                {"price", "1.99"},
                {"calories", "300"},
                {"ingredients", "bread, meat, cheese, lettuce, tomatoes"}
            };

            Sandwich tuna = new Sandwich("tuna", 2.59, 300)
            {

                breadType = "white",
                ingredients = new List<string>() { "bread", "tuna", "pickles", "onions" }

            };

            Sandwich turkey = new Sandwich("turkey", 2.99, 250)
            {

                breadType = "white",
                ingredients = new List<string>() { "bread", "turkey", "pickles", "onions" }


            };

            Sandwich ham = new Sandwich("ham", 2.99, 250)
            {

                breadType = "wheat",
                ingredients = new List<string>() { "bread", "ham", "pickles", "onions", "cheese" }

            };

            // # Lightning Exercise Two
            // 1. Create a new class that represents a customer at the sandwich shop
            // 2. Give the customer the following public properties:
            //     - FirstName (string)
            //     - LastName (string)
            //     - RewardPoints (int)
            //     - Email (string)
            // 3. In the `Main()` method of your `Program` class, create a list of customers.

            Customer Sydney = new Customer("Sydney", "Wait", "sydney@email.com")
            {

                RewardPoints = 555,
                favoriteSandwich = turkey

            };

            Customer George = new Customer("George", "Wait", "george@email.com")
            {

                RewardPoints = 559,
                favoriteSandwich = ham

            };

            Customer Thomas = new Customer("Thomas", "Wait", "thomas@email.com")
            {
                RewardPoints = 555,
                favoriteSandwich = tuna

            };
            Customer Isaac = new Customer("Isaac", "Wait", "isaac@email.com")
            {
                RewardPoints = 555,
                favoriteSandwich = turkey

            };

            List<Customer> CustomerList = new List<Customer>(){

Sydney,
Isaac,
Thomas,
George

};
            // 4. Print each customer's first name and last name to the console.

Console.WriteLine("This is the customer list:");
            foreach (Customer cust in CustomerList)
            {

                Console.WriteLine($"  -{cust.FirstName} {cust.LastName}");


            };

            string sandwichReview = Sydney.eatSandwich(tuna);
            Console.WriteLine(sandwichReview);


            // # Lightning Exercise Three
            // 1. Add a method to your customer class called `AddRewardPoints`. This method should accept a parameter of the number of reward points the customer earned (an `int`) and add it to the customers `RewardPoints` property. Then it should write to the console the new value of the customer's `RewardPoints`.

            Sydney.addRewardPoints(100);
            Thomas.addRewardPoints(25);


        tuna.getTotalCalories(2);

            // end main
        }


    }
}
