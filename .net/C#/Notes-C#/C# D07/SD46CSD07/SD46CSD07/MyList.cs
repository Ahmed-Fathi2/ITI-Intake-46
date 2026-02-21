using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD07
{
    public class MyList<T>:List<T>
    {
        public void Add(T item) 
        {
            ///keep old behavior
            base.Add(item);
            //add functionality
            Console.WriteLine($"Add to Database {item}");
        }
    }
}
