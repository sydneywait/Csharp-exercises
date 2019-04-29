
using System;
using System.Collections.Generic;

namespace classes
{

    class Sandwich
    {
        public Sandwich (string nameParam, double priceParam, int calorieParam){
            name = nameParam;
            price = priceParam;
            _caloriesPerServing=calorieParam;

        }
        public string name {get; set;}
        public string breadType { get; set; }
        public double price { get; set; }
        private int _caloriesPerServing { get; set; }

        public void getTotalCalories(int numberOfServings){

            int totalCalories = _caloriesPerServing * numberOfServings;

            Console.WriteLine($"{numberOfServings} servings of {name} is {totalCalories} total calories");
        }
        public List<string> ingredients { get; set; }
    }
}