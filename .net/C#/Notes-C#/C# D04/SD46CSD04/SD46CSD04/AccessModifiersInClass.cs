using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD04
{
   
    public class Parent
    {
        public int pubx;
        private int privx;
        protected int protx;
        internal int intrnlx;
        internal protected int protIntrnlx;


    }

    public class Child : Parent
    {
        public Child()
        {
            
        }
    }
    public class ABC
    {
        Parent p1=new Parent();

        public ABC()
        {
            //p1.
        }
    } 
}
