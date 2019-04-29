using System;


namespace librarySystem
{
    class Book
    {       public Book(string titleParam, string authorParam){
            title=titleParam;
            author=authorParam;
        }
        public string title {get; set;}
        public string author {get; set;}
        public DateTime dueDate {get; set;}



    }
}
