using System;
using System.Collections.Generic;

namespace librarySystem
{
    class Patron:Person
    {
        public Patron(string firstNameParam, string LastNameParam, Library defaultLibraryParam):base(firstNameParam, LastNameParam){

            defaultLibrary=defaultLibraryParam;
            checkedOutBooks = new List<Book>();
        }

        public Library defaultLibrary {get; set;}
        public double overdueFees {get; set;}
        public List<Book> checkedOutBooks {get; set;}


    }
}
