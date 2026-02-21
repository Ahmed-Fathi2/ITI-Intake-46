using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Lab.Lab4;
public class Point3D:IComparable<Point3D>,ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }


    public Point3D() : this(0, 0, 0) { }


    public Point3D(int value) : this(value, value, value) { }


    public Point3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override bool Equals(object? obj)
    {
        //if(obj == null) return false;
        //if(obj is not  Point3D) return false;
        var right = obj as Point3D;
        if(right == null) return false;
        if(right.GetType() != this.GetType()) return false;
        if(Object.ReferenceEquals(this, right)) return true;

        return this.X== right.X && this.Y==right.Y && this.Z==right.Z;
    }
    public override string ToString()
    {
        return $"Point Coordinates: ({X}, {Y}, {Z})";
    }

    public int CompareTo(Point3D? other)
    {
        if(this.X != other.X)
        return this.X.CompareTo(other.X);

        else if (this.Y != other.Y)
            return this.Y.CompareTo(other.Y);

        else 
            return this.Z.CompareTo(other.Z);

    }

    public object Clone()
    {
        return new Point3D(this.X, this.Y, this.Z);
    }
}

