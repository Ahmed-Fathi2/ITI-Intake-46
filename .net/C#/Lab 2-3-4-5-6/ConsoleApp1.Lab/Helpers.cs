using ConsoleApp1.Lab.Lab3;
using ConsoleApp1.Lab.Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Lab;
public class Helpers
{
    public static int ReadInt(string msg)
    {
        int value;
        while (true)
        {
            Console.Write(msg);
            if (int.TryParse(Console.ReadLine(), out value))
                return value;
            Console.WriteLine("Invalid number, try again.");
        }
    }

    public static decimal ReadDecimal(string msg)
    {
        decimal value;
        while (true)
        {
            Console.Write(msg);
            if (decimal.TryParse(Console.ReadLine(), out value))
                return value;
            Console.WriteLine("Invalid salary, try again.");
        }
    }

    public static Gender ReadGender()
    {
        while (true)
        {
            Console.Write("Gender (M[0] / F[1]): ");
            string input = Console.ReadLine();
            if (Enum.TryParse(input, true, out Gender gender))
                return gender;

            Console.WriteLine("Invalid gender.");
        }
    }

    public static SecurityLevel ReadSecurityLevel()
    {
        while (true)
        {
            Console.Write("Security Level (Guest[0], Developer[1], Secretary[2], DBA[3]): ");
            string input = Console.ReadLine();
            if (Enum.TryParse(input, true, out SecurityLevel level))
                return level;

            Console.WriteLine("Invalid security level.");
        }
    }


   public static int ReadPointInt(string msg)
    {
        int value;
        while (true)
        {
            Console.Write(msg);
            if (int.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine("Invalid input, try again.");
        }
    }

    public static Point3D ReadPoint(string name)
    {
        Console.WriteLine($"Enter coordinates for {name}:");

        int x = ReadInt("X: ");
        int y = ReadInt("Y: ");
        int z = ReadInt("Z: ");

        return new Point3D(x, y, z);
    }



}
