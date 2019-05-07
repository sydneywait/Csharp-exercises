// Maintenance Requests
// Create a new class to represent a maintenance request. Maintenance requests should have:
// A description of the problem to be fixed (string)
// A property to tell us who filed the report
// An assignedEmployee property of type Employee
// A property that tells us which building the report was filed for
// A property called Completed that holds a boolean


using System;

namespace c__inheritance
{

    class MaintenanceRequest
    {

        public string descriptionOfProblem { get; set; }
        public Person whoFiledReport { get; set; }
        public Employee assignedEmployee { get; set; }
        public Building whichBuilding { get; set; }
        public bool Completed { get; set; }





    }


}