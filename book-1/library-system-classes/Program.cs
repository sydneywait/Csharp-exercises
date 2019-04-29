using System;
using System.Collections.Generic;

namespace librarySystem
{
    class Program
    {
        static Book checkBookParam(Dictionary<string, Book> allBooks)
        {

            Book bookParam = new Book("", "");
            bool bookLoop = false;
            while (bookLoop == false)
            {
                Console.Write($"Enter the name of the book: ");
                string bookName = Console.ReadLine();
                try
                {
                    bookParam = allBooks[bookName];
                    bookLoop = true;
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Book title not found");
                }

            }
            return bookParam;

        }

        static Library checkLibraryParam(Dictionary<string, Library> allLibraries)
        {
            Library libraryParam = new Library(" ", " ");
            bool libraryLoop = false;
            while (libraryLoop == false)
            {
                Console.Write($"Enter the name of the library: ");
                string libraryName = Console.ReadLine();

                try
                {
                    libraryParam = allLibraries[libraryName];
                    libraryLoop = true;

                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Library not found");
                }
            }
            return libraryParam;
        }

        static Patron checkPatronParam(Dictionary<string, Patron> allPatrons)
        {
            Patron patronParam = new Patron("", "", new Library("", ""));
            bool patronLoop = false;
            while (patronLoop == false)
            {
                Console.Write($"Enter the name of the patron: ");
                string patronName = Console.ReadLine();
                try
                {
                    patronParam = allPatrons[patronName];
                    patronLoop = true;
                }
                catch
                {
                    Console.WriteLine("Patron not found");
                }
            }
            return patronParam;
        }

        static void Main(string[] args)
        {



            // Create several Libraries
            Library Huntington = new Library("Huntington", "100 Main st");
            Library Barboursville = new Library("Barboursville", "300 Central Ave");

            // Create Several Librarians (firstName, lastName)
            Librarian Holly = new Librarian("Holly", "Miller");

            // Create Several Patrons (firstName, lastName, defaultLibrary)
            Patron Sydney = new Patron("Sydney", "Wait", Barboursville);
            Patron Isaac = new Patron("Isaac", "Wait", Huntington);

            // Create Several Books (title, author)

            Book Grapes = new Book("The Grapes of Wrath", "John Steinbeck");
            Book Harry = new Book("Harry Potter and the Sorceror's Stone", "JK Rowling");
            Book DQ = new Book("Don Quixote", "Miguel de Cervantes");
            Book RJ = new Book("Romeo and Juliet", "William Shakespeare");

            // Add books to a library
            Huntington.currentInventory.Add(Grapes);
            Huntington.currentInventory.Add(Harry);
            Huntington.currentInventory.Add(DQ);
            Barboursville.currentInventory.Add(RJ);

            Huntington.printInventoryReport();
            Barboursville.printInventoryReport();

            // Check out a book to a patron (book, library, patron)

            Holly.checkOutBook(Grapes, Huntington, Isaac);

            Isaac.printLoanReport();
            Grapes.dueDate = DateTime.Today.AddDays(-10);
            Holly.returnBook(Grapes, Huntington, Isaac);

            Holly.checkOutBook(Grapes, Huntington, Sydney);

            Isaac.payOverdueFees(4);

            // Make a list of all the books in the database
            Dictionary<string, Book> allBooks = new Dictionary<string, Book>()
            {{Grapes.title, Grapes},
             {Harry.title, Harry},
             {DQ.title, DQ},
             {RJ.title, RJ}}
             ;

            // Make a list of all the patrons in the database
            Dictionary<string, Patron> allPatrons = new Dictionary<string, Patron>() {
                {Sydney.firstName, Sydney}, {Isaac.firstName, Isaac}
                 };

            // Make a list of all the Libraries in the database
            Dictionary<string, Library> allLibraries = new Dictionary<string, Library>() {
                {Huntington.name, Huntington},
                {Barboursville.name, Barboursville}
                };

            bool endTask = false;
            while(endTask==false){
            // Ask the librarian to choose an option for performing tasks
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - Check Out Book");
            Console.WriteLine("\t2 - Return Book");
            Console.WriteLine("\t3 - Pay Overdue Fees");
            Console.WriteLine("\t4 - Print Library Inventory");
            Console.WriteLine("\t5 - Print Customer's Loans");
            Console.WriteLine("\t6 - Exit Menu");
            Console.Write("Your option? ");


            // Use a switch statement to run the logic for each option
            switch (Console.ReadLine())
            {
                case "1":
                    // Check out a book
                    Book bookParam = Program.checkBookParam(allBooks);
                    Library libraryParam = Program.checkLibraryParam(allLibraries);
                    Patron patronParam = Program.checkPatronParam(allPatrons);

                    Holly.checkOutBook(bookParam, libraryParam, patronParam);
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;


                case "2":
                    // Check in a book
                    Book bookParam2 = Program.checkBookParam(allBooks);
                    Library libraryParam2 = Program.checkLibraryParam(allLibraries);
                    Patron patronParam2 = Program.checkPatronParam(allPatrons);
                    Holly.returnBook(bookParam2, libraryParam2, patronParam2);
                    Console.Write("Press any key to continue");
                    Console.ReadKey();

                    break;


                case "3":
                    // Pay overdue fees
                    Patron patronParam3 = Program.checkPatronParam(allPatrons);
                    Console.WriteLine($"{patronParam3.firstName} owes ${patronParam3.overdueFees}");
                    bool feeLoop = false;
                    while (feeLoop == false)
                    {
                        Console.Write("Enter payment amount: ");
                        string paymentAmount = Console.ReadLine();

                        try
                        {
                            patronParam3.payOverdueFees(Convert.ToDouble(paymentAmount));
                            feeLoop = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("***Invalid payment entry***");
                        }
                    };
                    Console.Write("Press any key to continue");
                    Console.ReadKey();

                    break;
                case "4":
                    // Print a library's inventory
                    Library libraryParam4 = checkLibraryParam(allLibraries);
                    libraryParam4.printInventoryReport();
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;


                case "5":
                    // Print a customer's loans
                    Patron patronParam5 = checkPatronParam(allPatrons);
                    patronParam5.printLoanReport();
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;

                case "6":
                    Console.WriteLine("*****Goodbye*****");
                    endTask = true;
                    break;

            }
            }

            //End Main
        }
    }
}


