using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD06
{
    ///Tightly coupled
    class Line
    {
        Point start = new Point();
        Point end = new Point();

        public Point Start
        {
            get { return start; }
            set { start = value; }
        }
        public Point End
        {
            get { return end; }
            set { end = value; }
        }
        public Line()
        {
            
        }

        public Line(int x1,int y1,int x2,int y2)
        {
            start.X = x1;
            start.Y = y1;
            end.X = x2;
            end.Y = y2;
        }
    }
    ////////////////////////
    //Composition
    class Rect
    {
        Point ul;
        Point lr;

        public Point Ul
        {
            get
            {
                return ul;
            }

            set
            {
                ul = value;
            }
        }

        public Point Lr
        {
            get
            {
                return lr;
            }

            set
            {
                lr = value;
            }
        }

        public Rect()
        {
            ul=new Point();
            lr=new Point();
        }

        public Rect(int x1,int y1,int x2,int y2)
        {
            ul=new Point(x1,y1);
            lr=new Point(x2,y2);
            //ul.X=x1; //
        }
    }
}