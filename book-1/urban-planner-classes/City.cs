using System;
using System.Collections.Generic;

namespace Planner
{

    class City
    {

        public City(string cityNameParam)
        {
            nameOfCity = cityNameParam;
        }

        // Now you need to create a type to represent your city. Here are the requirements for the class. You determine if/when to use fields, properties, a constructor, and methods.

        // Name of the city.
        // The mayor of the city.
        // Year the city was established.
        // A collection of all of the buildings in the city.
        // A method to add a building to the city.
        public string nameOfCity { get;  }
        public string mayor { get; set; }
        public int yearEst { get; set; }
        public List<Building> cityBuildingList = new List<Building>
        {

        };
        public void addBuilding(Building buildingName)
        {
            cityBuildingList.Add(buildingName);
        }
    }

}

