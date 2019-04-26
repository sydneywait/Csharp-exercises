using System;

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

            // Check out a book to a patron

            Holly.checkOutBook(Grapes, Huntington, Isaac);

            Isaac.printLoanReport();
            Grapes.dueDate=DateTime.Today.AddDays(-10);
            Holly.returnBook(Grapes, Huntington, Isaac);

            Isaac.payOverdueFees(4);

        }
    }
}
