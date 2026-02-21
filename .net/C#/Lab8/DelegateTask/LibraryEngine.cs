using System;
using System.Collections.Generic;

namespace DelegateTask
{
    // a. User Defined Delegate Datatype 
    public delegate string BookDelegate(Book B);

    public class LibraryEngine
    {
        // For Case A (User Defined Delegate)
        public static void ProcessBooks(List<Book> bList, BookDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // For Case B (BCL Delegates - Func)
        public static void ProcessBooksBCL(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
