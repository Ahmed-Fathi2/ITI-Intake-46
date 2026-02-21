using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD08
{
    public class Trial
    {
        public static void Fun1(int x)
        {
            Console.WriteLine("MILITARYYYYYYYY");
        }
        public static bool PerSalary(Employee item)
        {
            return item.Salary > 5000;
        }
        public static bool PerDept(Employee item)
        {
            return item.DeptId == 20;
        }

        public static void PrintEmployee(Employee item)
        {
            Console.WriteLine(item);
        }

        public static int Add(int left,int right)
        {
            return left + right;
        }
        public static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
    }
}
