using System;
using System.Collections.Generic;

namespace c__inheritance{
    class Employee: Person{

        public Employee(string jobTitleParam){
            StartDate = DateTime.Now;
            JobTitle = jobTitleParam;
        }

        public DateTime StartDate {get; set;}

        public string JobTitle {get; set;}
        public List<MaintenanceRequest> assignedRequests {get; set;}



        public override void SubmitMaintenanceRequest(string problemToBeFixed)
        {
            Console.WriteLine($"An employee submitted a maintenance request: {problemToBeFixed}");
        }

//Give your Employee class the ability to construct different buildings.
// This method should write to the console a confirmation that the building is under construction. This method should have different behavior based on what type of building it recieves as an argument. For example, if you pass it an instance of the ApartmentBuilding class, it should write something to the console like "Now building {x} number of units in the apartment building!" (Hint: method overloading!)

public void constructBuilding(ApartmentBuilding buildingParam){
Console.WriteLine($"Now building {buildingParam.numberOfUnits} units in the apartment building.");
}
public void constructBuilding(House buildingParam){
Console.WriteLine($"Now building a {buildingParam.numberOfBedrooms}-bedroom house.");
}
public void constructBuilding(Office buildingParam){
Console.WriteLine($"Now building an office building for {buildingParam.nameOfCompany}.");
}


    }
}