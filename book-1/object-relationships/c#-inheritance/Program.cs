using System;

namespace c__inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // INHERITANCE
            // Employee and Customer both inherit from the Person class

            Customer Joey = new Customer();
            Joey.sayHi();

            Joey.SubmitMaintenanceRequest("The sink is broken");

            Employee David = new Employee("Master of the Universe");
            David.SubmitMaintenanceRequest("The door is also broken");


            // ASSOCIATION

            // Composition- buildings and rooms
            Building ChaseBuilding = new Building();
            Room Hackery = new Room(50, 300);
            ChaseBuilding.addRoomToBuilding(Hackery);
            ApartmentBuilding heritage = new ApartmentBuilding()
            {
                numberOfUnits = 6
            };
            Office theOffice = new Office()
            {
                nameOfCompany = "Dunder Mifflin"
            };
            House myHouse = new House()
            {
                numberOfBedrooms = 7
            };

            David.constructBuilding(heritage);
            David.constructBuilding(theOffice);
            David.constructBuilding(myHouse);

            Room basicRoom = new Room(200, 400);


            // Aggregation- companies and employees || companies and customers
            Company AwesomeDoorCompany = new Company();
            AwesomeDoorCompany.EmployeeList.Add(David);
            David.Company = AwesomeDoorCompany;


            // add rooms to a building
            heritage.addRoomToBuilding(basicRoom);
            theOffice.addRoomToBuilding(basicRoom);
            theOffice.addRoomToBuilding(Hackery);

            Console.WriteLine($"This is the area of The Office {theOffice.totalArea}");
            Console.WriteLine($"This is the average room size of The Office {theOffice.getAverageRoomSize}");
            theOffice.estimateCost(1.50, "The Office");

        }
    }
}
