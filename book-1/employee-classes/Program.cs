using System;
using System.Collections.Generic;


namespace employee_classes
{
    class Program
    {
        static void Main(string[] args)
        {

            // Using C# classes, you need to create custom types to represent an Employee and a Company. Then you will create some employees, hire them into the company and then display a simple report showing the employee names and their titles.

            // In the Main method of your console application, create a new instance of Company, and three instances of Employee. Then assign the employees to the company.




            Company BoggleCorp = new Company()
            {

                dateFounded = DateTime.Now,
                companyName = "BoggleCorp",
                employees = new List<Employee>()


            };

             Employee Sydney = new Employee(){
                firstName="Sydney",
                lastName="Wait",
                title="Manager",
                startDate = DateTime.Now

            };

            Employee Isaac = new Employee(){
                firstName="Isaac",
                lastName="Wait",
                title="Assistant to the Manager",
                startDate = DateTime.Now

            };

            Employee George = new Employee(){
                firstName="George",
                lastName="Wait",
                title="Intern",
                startDate = DateTime.Now

            };


            BoggleCorp.employees.Add(Sydney);
            BoggleCorp.employees.Add(Isaac);
            BoggleCorp.employees.Add(George);

            BoggleCorp.listEmployees();



        }
    }
}
