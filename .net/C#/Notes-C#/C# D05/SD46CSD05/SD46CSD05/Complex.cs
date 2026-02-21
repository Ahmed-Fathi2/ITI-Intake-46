using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD05
{
    class Complex
    {
        public int Real { get; set; }
        public int Img { get; set; }

        ////this line of code is executed once per program call
        private static int counter;

        public static int Counter
        {
            get { return counter; }
        }

        #region Static ctor
        //static ctor fn is called once per program call 
        static Complex()
        {
            counter = 0;
        }
        #endregion


        //public static int Counter { get; } = 0;

        public Complex()
        {
            counter++;
            Real = Img = 0;
        }
        public Complex(int _real, int _img)
        {
            counter++;
            Real = _real;
            Img = _img;
        }
        public override string ToString()
        {
            return $"{Real}+{Img}i";
        }

        #region Operators
        //c1+c2
        public static Complex operator +(Complex left, Complex right)
        {
            Complex result = new Complex()
            {
                Real = left.Real + right.Real,
                Img = left.Img + right.Img
            };
            return result;
            return new Complex
            {
                Real = left.Real + right.Real,
                Img = left.Img + right.Img
            };
        }

        //c1+10
        public static Complex operator +(Complex left, int _num)
        {
            return new Complex
            {
                Real = left.Real + _num,
                Img = left.Img
            };
        }
        //10+c1
        public static Complex operator +(int _num,Complex right)
        {
            return new Complex
            {
                Real = right.Real + _num,
                Img = right.Img
            };
        }

        //c1++  or ++c1
        public static Complex operator ++(Complex left) 
        {
            return new Complex 
            {
                Real= left.Real + 1,
                Img = left.Img + 1
            };
        }

        //(int) c1
        public static implicit operator int(Complex left)
        {
            return left.Real;
        }

        public static explicit operator string(Complex left)
        {
            return left.ToString();
        }

        public static bool operator> (Complex left, Complex right)
        {
            return left.Real>right.Real && left.Img>right.Img;
        }
        public static bool operator <(Complex left, Complex right)
        {
            return left.Real < right.Real && left.Img < right.Img;
        }

        public static bool operator ==(Complex left, Complex right)
        {
            return left.Real == right.Real && left.Img == right.Img;
        }
        public static bool operator !=(Complex left, Complex right)
        {
            return left.Real != right.Real && left.Img != right.Img;
        }
        #endregion


    }

    ////////
    //static class ABC
    //{
    //    int real;

    //}

    static class MyMath
    {
        static int counter;
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Sub(int x, int y)
        {
            return x - y;
        }
        static MyMath()
        {
            counter = 0;
        }
    }
}
