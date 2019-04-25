using System;
using System.Collections.Generic;

namespace Planner
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create several buildings in the Main() method of Program.cs.
            // Building FiveOneTwoEigth = new Building("512 8th Avenue");
            // Give each building a width, height, and number of stories.


            Building EastSt = new Building("123 East st")
            {
                stories = 4,
                width = 500,
                depth = 200

            };

            Building ChaseBank = new Building("10th Street and 5th Ave")
            {

                stories = 3,
                width = 250,
                depth = 600
            };

            Building RecCenter = new Building("Hal Greer and 3rd Ave")
            {

                stories = 5,
                width = 300,
                depth = 955
            };


            // Construct each building.
            // Have business people in your city purchase each of your buildings.

            EastSt.Construct();
            EastSt.Purchase("Tonald Drump");
            ChaseBank.Construct();
            ChaseBank.Purchase("Bill Gates");
            RecCenter.Construct();
            RecCenter.Purchase("Jeff Bezos");

            // After all of the buildings have been purchased, display the following information to the console for each building.

            // 100 Main Street
            // ---------------
            // Designed by Steve Brownlee
            // Constructed on 2/1/18 7:19:08 AM
            // Owned by Bob Ross
            // 16128 cubic meters of space

            List <Building> buildingList = new List<Building>(){
                EastSt,
                ChaseBank,
                RecCenter

            };

            foreach(Building building in buildingList){
            building.DisplayInfo();
            }











            // end main
        }
    }
}
