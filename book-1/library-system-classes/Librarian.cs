using System;


namespace librarySystem
{
    class Librarian : Person
    {
        public Librarian(string firstNameParam, string lastNameParam) : base(firstNameParam, lastNameParam)
        {
            firstName = firstNameParam;
            lastName = lastNameParam;
        }


        public void checkOutBook(Book bookParam, Library libraryParam, Patron patronParam)
        {

            // Check if the book is in the current inventory
            if (libraryParam.currentInventory.Contains(bookParam))
            {
                libraryParam.currentInventory.Remove(bookParam);
                bookParam.dueDate = DateTime.Today.AddDays(14);
                patronParam.checkedOutBooks.Add(bookParam);
                Console.WriteLine($"{patronParam.firstName} just checked out {bookParam.title} from {libraryParam.name} and it is due on {bookParam.dueDate.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine($"{bookParam.title} is not in the inventory at {libraryParam.name}");
            }
        }

        public void returnBook(Book bookParam, Library libraryParam, Patron patronParam)
        {
            if (patronParam.checkedOutBooks.Contains(bookParam))
            {
                patronParam.checkedOutBooks.Remove(bookParam);
                libraryParam.currentInventory.Add(bookParam);
                // See if the book is past due and by how many days
                double pastDue = (bookParam.dueDate - DateTime.Today).TotalDays;
                if (pastDue < 0)
                {
                    // calculate the late fee and add to the patron's overdue fees
                    double overdueFee =Math.Abs(pastDue * 0.50);
                    patronParam.overdueFees += overdueFee;
                    Console.WriteLine($"The book, '{bookParam.title},' was overdue--the late fee is ${overdueFee}.  {patronParam.firstName}'s total overdue fees are ${patronParam.overdueFees}");
                }
                else
                {

                    Console.WriteLine($"{patronParam.firstName} returned the book {bookParam.title} without any overdue fees");
                }
            }
            else
            {
                Console.WriteLine($"{bookParam.title} is not currently checked out to {patronParam.firstName}");
            }
        }

    }



}

