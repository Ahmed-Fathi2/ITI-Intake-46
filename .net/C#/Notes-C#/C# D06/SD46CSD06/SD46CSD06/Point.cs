using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD06
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
            X = Y = 0;
        }
        public Point(int _x,int _y)
        {
            X = _x;
            Y = _y;
        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public override bool Equals(object? obj)
        {
            #region Worst code for casting  [unprotective code]
            /////this -> p1
            /////obj  -> p3
            /////cast obj to Point
            //Point right = (Point)obj;
            //return this.X == right.X && this.Y == right.Y; 
            #endregion
            #region Effective code

            /////With Reference type
            //////is  casting to check object type  return true if obj is object
            ///////////return false if not and no runtime error will be fired
            ///////
            ///////as  //cast object into pourpose DT
            ////////////if cast true ,done
            ////////////if not cast return null & will not fire error
            /////

            //if(obj is Point right)
            //{
            //    //var right = (Point)obj; //NOT RECOMMENDED WITH REFRERENCE TYPE
            //    //var right=obj as Point;  //instead of create variable in if condition
            //    return this.X==right.X&&this.Y==right.Y;
            //}
            //return false;

            #endregion
            #region More Effective code 
            var right=obj as Point;

            if(right ==null) return false;

            if(right.GetType() != this.GetType()) return false;

            if(object.ReferenceEquals(this,right)) return true;

            return this.X==right.X && this.Y==right.Y;

            #endregion

        }
    }
    ///
    class Point3D : Point
    {
        public int Z { get; set; }
        public Point3D()
        {
            X = Y = Z = 0;
        }
        public Point3D(int _x,int _y,int _z):base(_x,_y)
        {
            Z = _z;
        }
    }
}
