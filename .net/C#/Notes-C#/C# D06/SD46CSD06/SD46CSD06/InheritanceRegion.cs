using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD06
{
    class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Parent()
        {
            X = Y = 0;
        }
        public Parent(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
        public virtual int Sum()
        {
            return X + Y;
        }
    }
    //
    class Child : Parent
    {
        public int Z { get; set; }
        public Child()
        {
            Z = 0;
        }
        public Child(int _x, int _y, int _z)
            : base(_x, _y)
        {
            Z = _z;
        }
        public override int Sum()
        {
            //return X + Y + Z;
            return Z + base.Sum();
        }
    }

    abstract class Geoshape
    {
        public double Dim1 { get; set; }
        public double Dim2 { get; set; }
        public Geoshape()
        {
            Dim1 = Dim2 = 0;
        }
        public abstract double Area();
        //{
        //    return -1;
        //}
    }
    //class Cir : Geoshape
    //{

    //}



    ///partial class:
    ///ONE class distributed among several files
    ///
    ///1-windows Forms
    ///2- EF Core

    ////DB
    ///Employee
    /////int id   pk
    /////vc name
    /////int age null
    /////money salary
    /////vc address

    //EF
    ///partial class Employee
    ///int id
    ///string name
    ///int? age
    ///decimal salary
    ///string Address

}
