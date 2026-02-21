using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD04
{
    abstract class Geoshape
    {
        protected double dim1;
        protected double dim2;

        public double Dim1
        {
            get
            {
                return dim1;
            }

            set
            {
                dim1 = value;
            }
        }

        public double Dim2
        {
            get
            {
                return dim2;
            }

            set
            {
                dim2 = value;
            }
        }

        public Geoshape()
        {
            dim1 = dim2 = 0;
        }
        public Geoshape(double _d1,double _d2)
        {
            dim1 = _d1;
            dim2 = _d2;
        }
        //public virtual double Area()
        //{
        //    return -1;
        //}

        public abstract double Area();

    }
    ///
    class Rectangle : Geoshape
    {
        public Rectangle()
        {
           
        }
        public Rectangle(double _d1,double _d2)
            :base(_d1,_d2)
        {
            
        }

        public override double Area()
        {
            return dim1 * dim2;
        }
    }
}
