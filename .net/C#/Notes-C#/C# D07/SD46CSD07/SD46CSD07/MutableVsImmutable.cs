using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD07
{
    public class MutablePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        //public MutablePoint()
        //{
        //    X = Y = 0;
        //}
        public MutablePoint(int _x, int _y)
        {
            X = _x; Y = _y;
        }
    }
    //////
    class ImmutablePoint
    {
        int x;
        int y;

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public ImmutablePoint()
        {
            x = y = 0;
        }
        public ImmutablePoint(int _x,int _y)
        {
            x = _x; y = _y;
        }
    }
    /////
    class ImmutablePoint2
    {
        public int X { get; init; }
        public int Y { get; init; }
    }
}
