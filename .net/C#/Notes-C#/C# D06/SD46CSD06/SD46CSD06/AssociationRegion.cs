using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD06
{
    //loosely coupled
    class Tri
    {
        public Point P1 { get; set; }

        public Point P2 { get; set; }

        public Point P3 { get; set; }

        public Tri()
        {
            //safety factor
            P1 = null;
            P2 = default;
            P3 = default;
        }


        public Tri(Point _p1,Point _p2,Point _p3)
        {
            P1=_p1; P2=_p2; P3=_p3;
        }


        //u have to make it composition
        public Tri(int x1,int y1,int x2,int y2,int x3,int y3)
        {
            //P1 = new Point();
            P1.X = x1;
            P1.Y = y1;

            
        }

        public override string ToString()
        {
            return $"p1={P1} , p2={P2} , p3={P3}";
        }
    }
}
