using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD07
{
    internal class Trial3<T> //where T :INumber<T>
    {
        //T x;
        //T y;

        public Trial3()
        {
            //what is applicable with ant generic

            // ///what is valid for any generic?
            // ///1- declaration
             T x;
             T y;
            // ///2- initialization
             x = default;
             y = default;
            // ///3- =
             x = y;
            // ///4- return type from fn
             T GetOne() { return x; }
            // ///5- System.object
             object o1 = x;
            // //6,7,8,9- system.object methods
            x.Equals(y);
            object.Equals(x, y);
            object.ReferenceEquals(x, y);
            x.ToString();
            //x.GetType() ==y.GetType()


            // ///valid for special cases
            //x = new T();  //where T:new()  , or T:struct


            //x.CompareTo(y);


            //// //not VALID
            //x = null;
            //x = 0;

            //T z = x + y;

        }
    }
}
