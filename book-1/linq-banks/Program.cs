using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_banks
{
    public class Program
    {


        public static void Main()
        {
            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

          // Create some banks and store in a List
        List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

    // Given the same customer set, display how many millionaires per bank.

    // Example Output:
    // WF 2
    // BOA 1
    // FTB 1
    // CITI 1
    // Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq



    var results = customers.Where(c => c.Balance>=1000000).GroupBy(item => item.Bank)
     .Select(g => new { Bank = g.Key, Items = g.Count() })
     .ToList();

     /*
    TASK:
    As in the previous exercise, you're going to output the millionaires,
    but you will also display the full name of the bank. You also need
    to sort the millionaires' names, ascending by their LAST name.

    Example output:
        Tina Fey at Citibank
        Joe Landy at Wells Fargo
        Sarah Ng at First Tennessee
        Les Paul at Wells Fargo
        Peg Vale at Bank of America
*/


var q =
        from c in customers where c.Balance >= 1000000 orderby c.Name.Split(" ")[1]
        join b in banks on c.Bank equals b.Symbol into ps
        select new { Customer = c, Banks = ps };


foreach (var v in q)
    {
        Console.Write(v.Customer.Name);
        foreach (var p in v.Banks)
        {
            Console.WriteLine($" at {p.Name}");
        }
    }

 /*
            You will need to use the `Where()`
            and `Select()` methods to generate
            instances of the following class.


        */


        // List<ReportItem> millionaireReport = ...

        // foreach (var item in millionaireReport)
        // {
        //     Console.WriteLine($"{item.CustomerName} at {item.BankName}");
        // }











        // End Main
        }
    }

}