using System;
using System.Collections.Generic;

namespace librarySystem
{
    class Patron : Person
    {
        public Patron(string firstNameParam, string LastNameParam, Library defaultLibraryParam) : base(firstNameParam, LastNameParam)
        {

            defaultLibrary = defaultLibraryParam;
            checkedOutBooks = new List<Book>();
        }
        public Library defaultLibrary { get; set; }
        public double overdueFees { get; set; }
        public List<Book> checkedOutBooks { get; set; }

        public void payOverdueFees(double payment)
        {
            Console.WriteLine($"{firstName}'s overdue fees were ${overdueFees}");
            Console.WriteLine($"{firstName} paid ${payment}");
            overdueFees -= payment;
            Console.WriteLine($"{firstName}'s overdue fees are now ${overdueFees}");
        }

        public void printLoanReport()

        {
            if(checkedOutBooks.Count>0){
            Console.WriteLine($"{firstName} has checked out the following books:");

            foreach (Book book in checkedOutBooks)
            {

                Console.WriteLine($"  -'{book.title}' by {book.author} due {book.dueDate}");
            }
            }
            else{
                Console.WriteLine($"{firstName} does not have any books checked out");
            }
        }
    }
}
