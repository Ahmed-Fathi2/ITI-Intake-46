using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Lab.Lab4;
static class MathOperations
{
    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;

    public static double Divide(int a, int b)
    {
        if (b == 0)
            throw new Exception("invalid operation");
        return (double)a / b;
    }
}

