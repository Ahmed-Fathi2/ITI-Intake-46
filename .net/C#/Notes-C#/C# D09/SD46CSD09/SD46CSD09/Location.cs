using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD09
{
    public struct Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Location()
        {
            X = 3;Y = 4;Z = 5;
        }
        public Location(int _x,int _y,int _z)
        {
            X = _x;Y = _y;Z = _z;
        }
        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }

        public override bool Equals(object? obj)
        {
            return obj is Location location &&
                   X == location.X &&
                   Y == location.Y &&
                   Z == location.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public static bool operator ==(Location left, Location right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !(left == right);
        }

        public static Location operator -(Location left, Location right)
        {
            return new Location 
            {
                X = left.X - right.X,
                Y = left.Y - right.Y,
                Z= left.Z - right.Z
            };
        }
    }
}
