# Classes Challenge

## Library System


### Data Structure
Your job is to represent a library system with C# classes and methods. Before you begin, create an ERD of the following data structure:
https://dbdiagram.io/d/5cc3475df7c5bb70c72fc599


##### Books
   - A book has a title
   - A book has an author
   - A book can only be at one library at a time, and we don't care which libraries it's been at in the past.
   - A book can only be checked out by one patron, and we don't care which patrons have checked it out in the past.
   - A book has a due date.
##### Libraries
   - A library has a name
   - A library has an address
##### Patrons
   - A patron has a first name
   - A patron has a last name
   - A patron has one local library branch
   - A patron has an amount of money that they owe in overdue fees
##### Librarians
   - A librarian has a first name
   - A librarian has a last name


### Setup
1. Create a new console application
1. Create classes to represent each entity in your ERD. Include all the properties from your ERD, as well as the following:
    - Give your `Library` class a property called `currentInventory`. It should be a list of type `Book` that stores all of the books currently at that location.
    - Give your `Patron` a class of `checkedOutBooks`. It should be a list of type `Book` that stores all of the books that patron has currently checked out.


### Add some functionality
1. Give your `Librarian` class a method called `checkOutBook`.
    - This method should accept three parameters: the `Book` that's being checked out, the `Library` location, and the `Patron` who's checking out the book.
    - First, this method should make sure that the given book exists in the given library's inventory. If not, it should print a descriptive error message.
    - This method should remove the book from the library's current inventory.
    - This method should add the book to the patron's list of checked out books.
    - This method should assign the book's due date property to be two weeks from today's date.
    - Finally, the method should log a sentence to the console about which customer checked out the book and when it's due. (Example: "Julie just checked out The Grapes of Wrath from East Branch Library and it's due on 5/1/19.")
1. Give`Librarian` another method called `returnBook`.
    - It should accept as parameters a `Book`, a `Library`, and a `Patron`.
    - If the book is returned after the due date, add $0.50 to the patron's overdue fees for every late day.
    - It should remove the book from the customer's list of checked out books and add it to the current inventory at the given library.
    - Finally, it sould write to the console a sentence about which customer returned the book to which library and whether any overdue fees were charged. ("Julie just returned The Grapes of Wrath to West Branch Library with no overdue fees.")
1. Give `Patron` a method called `payOverdueFees`. It should accept a double of `payment` and subtract their payment from their overdue fees.
1. Give `Patron` another method called `printLoanReport`. It should print the titles and authors of all the books the patron has currently borrowed.
1. Give `Library` a method called `printInventoryReport`. It should print all of the books currently at that library to the console.
1. Patrons should not be able to return a book that they haven't checked out. If they try to do this, the librairan should see an error message in the console.
1. If a patron tries to check out a book that's out of stock, the librarian should see an error message.
1. Create a few instances of libraries, patrons, and books to test your methods.

### Bonus Challenge:
1. Librarians and patrons have some duplicate properties (`firstName`, `lastName`, etc). To avoid duplicating code, have both classes [inherit](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance) from a base class called `Person` and move any duplicate properties or methods to the `Person` class.

### Extra Bonus Challenge:
Create a [command line application](https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2019) for librarians to manage their inventory system.


When the librarian runs your app, they should see a list of options:

1. Check out book
2. Return book
4. Pay overdue fees
5. Print library inventory
6. Print customer's loans

They should be able to select one of these options by typing in a number between one and six. When an option is selected, they should be prompted into entering the appropriate data and then see an error message or a success message.

For example, if a librarian selects option 1, they might see a prompt that says `Select your library location:` and a numbered list of all the library locations. Then they might see a prompt that says `What book is the customer checking out?` and a line to enter a book title. Finally, they might be prompted to enter the customer's name. When they've entered all the information, they should see a message that confirms the book was checked out successfully and when it's due-- or they should see a descriptive error message of what went wrong.

Consider how you want to notify your librarian of errors. What if they enter a book title incorrectly? What if they enter a customer name that doesn't exist?



