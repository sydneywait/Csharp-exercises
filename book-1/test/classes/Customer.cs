
using System;
using System.Collections.Generic;

namespace classes
{

    //     # Lightning Exercise Four
    // 1. Add a constructor to the customer class that sets the customer's first name, last name, and email.
    // 3. Refactor wherever you created your instances of customers to pass data into the constructor method.

    class Customer
    {

        public Customer(string FirstNameParam, string LastNameParam, string emailParam)
        {

            FirstName = FirstNameParam;
            LastName = LastNameParam;
            email = emailParam;

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RewardPoints { get; set; }
        public string email { get; set; }

        public Sandwich favoriteSandwich { get; set; }

        public string eatSandwich(Sandwich sandwichToEat)
        {
            if (sandwichToEat.name == favoriteSandwich.name)
            {

                return $"yummy, yummy {sandwichToEat.name} is {FirstName}'s favorite sandwich";
            }
            else
            {
                return $"{FirstName} does not like {sandwichToEat.name}";

            }

        }
        public void addRewardPoints(int pointsToAdd)
        {
            RewardPoints = RewardPoints + pointsToAdd;

            Console.WriteLine($"{FirstName}, you now have {RewardPoints} points");


        }

    }
}