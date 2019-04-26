using System;


namespace librarySystem
{
    class Librarian:Person
    {
        public Librarian(string firstNameParam, string lastNameParam): base(firstNameParam, lastNameParam)
        {
            firstName = firstNameParam;
            lastName = lastNameParam;
        }


        public void checkOutBook(Book bookParam, Library libraryParam, Patron patronParam)
        {

            if (libraryParam.currentInventory.Contains(bookParam))
            {
                libraryParam.currentInventory.Remove(bookParam);
                bookParam.dueDate = DateTime.Today.AddDays(14);
                patronParam.checkedOutBooks.Add(bookParam);
                Console.WriteLine($"{patronParam.firstName} just checked out {bookParam.title} from {libraryParam.name} and it is due on {bookParam.dueDate}");
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
                string pastDue = (bookParam.dueDate-DateTime.Today).TotalDays.ToString();
                Console.WriteLine(pastDue);
            }
            else{
                Console.WriteLine($"{bookParam.title} is not currently checked out to {patronParam.firstName}");
            }
        }

    }



}

