using System;
using System.Collections.Generic;

namespace employee_classes
{
    class Company
    {

//Create a custom type for Company. A company has the following properties.
// Date founded (DateTime)
// Company name (string)
// Employees (List<Employee>)

public DateTime dateFounded {get;set;}

public string companyName {get;set;}
public List<Employee> employees {get;set;}

public void listEmployees(){

    Console.WriteLine("These are the employees:");

foreach (Employee employee in employees){
Console.WriteLine($"  -{employee.firstName} {employee.lastName}");

}

}


    }
}
