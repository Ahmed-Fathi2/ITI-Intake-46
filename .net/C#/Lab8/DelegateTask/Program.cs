using System;
using System.Collections.Generic;

namespace DelegateTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
            {
                new Book("123-456", "C# in Depth", new string[] { "Ahmed Fathi" }, new DateTime(2019, 3, 23), 45.99m),
                new Book("345-678", "The Pragmatic Programmer", new string[] { "Mahmoud", "Habiba" }, new DateTime(1999, 10, 30), 42.50m),
                new Book("789-012", "Clean Code", new string[] { "Heba Mohamed" }, new DateTime(2008, 8, 1), 39.95m),
            };

            Console.WriteLine("--- Case A: User Defined Delegate (GetTitle) ---");
            BookDelegate titleDelegate = BookFunctions.GetTitle;
            LibraryEngine.ProcessBooks(books, titleDelegate);



            Console.WriteLine("\n--- Case B: BCL Delegates (GetAuthors) ---");
            Func<Book, string> authorsFunc = BookFunctions.GetAuthors;
            LibraryEngine.ProcessBooksBCL(books, authorsFunc);



            Console.WriteLine("\n--- Case C: Anonymous Method (GetISBN) ---");
            LibraryEngine.ProcessBooksBCL(books, delegate (Book B) { return B.ISBN; });



            Console.WriteLine("\n--- Case D: Lambda Expression (GetPublicationDate) ---");
            LibraryEngine.ProcessBooksBCL(books, B => B.PublicationDate.ToShortDateString());


            
            Console.WriteLine("\n--- Using GetPrice with BCL Delegate ---");
            LibraryEngine.ProcessBooksBCL(books, BookFunctions.GetPrice);
        }
    }
}
