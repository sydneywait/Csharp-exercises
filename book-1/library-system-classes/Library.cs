using System;
using System.Collections.Generic;

namespace librarySystem
{
    class Library
    {
        public Library(string nameParam, string addressParam)
        {
            name = nameParam;
            address = addressParam;
            currentInventory = new List<Book>();
        }
        public string name { get; set; }
        public string address { get; set; }
        public List<Book> currentInventory { get; set; }
        public void printInventoryReport()
        {
            Console.WriteLine($"{name} has the following books in inventory:");
            foreach (Book book in currentInventory)
            {
                Console.WriteLine($"  -'{book.title}' by {book.author}");
            }
        }

    }
}
