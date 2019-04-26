using System;
using System.Collections.Generic;

namespace librarySystem
{
    class Program
    {
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

            Isaac.payOverdueFees(4);

            // Make a list of all the books in the database
            List<Book> allBooks = new List<Book>()
            {Grapes, Harry, DQ, RJ};

            // Make a list of all the patrons in the database
            List<Patron> allPatrons = new List<Patron>() { Sydney, Isaac };

            // Make a list of all the Libraries in the database
            List<Library> allLibraries = new List<Library>() { Huntington, Barboursville };

            // Ask the librarian to choose an option for performing tasks
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - Check Out Book");
            Console.WriteLine("\t2 - Return Book");
            Console.WriteLine("\t3 - Pay Overdue Fees");
            Console.WriteLine("\t4 - Print Library Inventory");
            Console.WriteLine("\t5 - Print Customer's Loans");
            Console.Write("Your option? ");


            // Use a switch statement to run the logic for each option
            switch (Console.ReadLine())
            {
                case "1":
                    Book bookParam = new Book("", "");

                    Console.WriteLine($"Enter the name of the book:");
                    string bookName = Console.ReadLine();
                    foreach (Book book in allBooks)
                    {
                        if (book.title == bookName)
                        {
                            bookParam = book;
                            Console.WriteLine($"found book {book.title}");
                            break;
                        }

                    }

                    Library libraryParam = new Library(" ", " ");
                    Console.WriteLine($"Enter the name of the library");
                    string libraryName = Console.ReadLine();

                    foreach(Library library in allLibraries){

                        if(library.name==libraryName){
                            libraryParam=library;
                            break;
                        }
                    }

                    Patron patronParam = new Patron("", "", new Library("",""));
                    Console.WriteLine($"Enter the name of the patron");
                    string patronName = Console.ReadLine();


                    foreach (Patron patron in allPatrons)
                    {
                        if (patron.firstName == patronName)
                        {
                            patronParam = patron;
                            break;
                        }
                        else
                        {

                        }
                    }


                    Holly.checkOutBook(bookParam, libraryParam, patronParam);
                    break;

                case "2":
                    Console.WriteLine($"");
                    break;
                case "3":
                    Console.WriteLine($"");
                    break;
                case "4":
                    Console.WriteLine($"");
                    break;
                case "5":
                    Console.WriteLine($"");
                    break;
            }


        }
    }
}
