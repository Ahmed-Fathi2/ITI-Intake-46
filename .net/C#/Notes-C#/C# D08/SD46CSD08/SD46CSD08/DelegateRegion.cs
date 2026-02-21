using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD08
{
    public delegate bool MyDelegate (Employee abc);


    public delegate int MathDelegate(int x, int y);
    public delegate bool MathDelegate2(int x);



    public delegate bool GenericDelegate<T>(T item);
    
    
    public delegate U GenericDelegate2<T,U>(T item);
    public delegate U GenericDelegate3<in T,out U>(T x,T y);



    public delegate void FinalDelegate();


}
