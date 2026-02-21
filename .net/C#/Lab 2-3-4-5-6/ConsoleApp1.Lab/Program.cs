using ConsoleApp1.Lab.Lab3;
using ConsoleApp1.Lab.Lab4;
using ConsoleApp1.Lab.Lab5;
using System.Drawing;

namespace ConsoleApp1.Lab
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Lab2

            #region
            //int[] arr = [1, 1, 1, 1, 1, 1, 1, 1];
            //int count = 0;
            //int maxNum = 0;

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = i+1; j < arr.Length; j++)
            //    {
            //        if(arr[i] == arr[j])
            //        {
            //            count = Math.Max(count, j - i - 1);
            //            //count = j - i - 1;
            //            //if (count > maxNum)
            //            //{
            //            //    maxNum = count;
            //            //}
            //        }

            //    }
            //}
            //Console.WriteLine(count);
            #endregion
            #region
            //string numAsString;
            //int numOfOnes = 0;
            //for (int i = 0; i < 99999999; i++)
            //{
            //    numAsString = i.ToString();
            //    foreach (char j in numAsString)
            //    {
            //        if (j == '1')
            //        {
            //            numOfOnes++;
            //        }

            //    }

            //}
            //Console.WriteLine($"num of ones is = {numOfOnes}");
            //Console.WriteLine("================================================");
            //Console.WriteLine("================================================");
            //Console.WriteLine("================================================");

            //for (int i = 1; i < 99999999; i++)
            //{
            //    int num = i;
            //    while (num > 0)
            //    {
            //        if (num % 10 == 1)
            //        {
            //            numOfOnes++;
            //        }
            //        num /= 10;

            //    }


            //}
            //Console.WriteLine($"num of ones is = {numOfOnes}");


            //Console.WriteLine("================================================");
            //Console.WriteLine("================================================");
            //Console.WriteLine("================================================");

            //int totalOnes = (int)Math.Pow(10, 7) * 8;
            //Console.WriteLine("The total number of 1's from 0 to 99999999 is: " + totalOnes);

            #endregion
            #region
            //Console.WriteLine("Enter Your name: ");

            //string name = Console.ReadLine();

            //string[] arr2 = name.Split(' ').Reverse().ToArray();
            //string reversedName = string.Join(" ", arr2);

            //Console.WriteLine(reversedName);
            #endregion


            #endregion


            #region Lab3
            #region task1

            //Employee[] employees = new Employee[3];

            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine($"\nEnter data for employee {i + 1}");

            //    int id = Helpers.ReadInt("ID: ");
            //    decimal salary = Helpers.ReadDecimal("Salary: ");

            //    int day = Helpers.ReadInt("Hire Day: ");
            //    int month = Helpers.ReadInt("Hire Month: ");
            //    int year = Helpers.ReadInt("Hire Year: ");

            //    HiringDate date = new HiringDate(day, month, year);

            //    Gender gender = Helpers.ReadGender();
            //    SecurityLevel security = Helpers.ReadSecurityLevel();

            //    employees[i] = new Employee(id, salary, date, gender, security);
            //}

            //Console.WriteLine("\nEmployees Data:");
            //foreach (var emp in employees)
            //{
            //    Console.WriteLine(emp.Print());
            //}


            var e1 = new Employee(1, 25000, new HiringDate(24, 8, 2010), Gender.Male, SecurityLevel.developer);
            var e2 = new Employee(2, 25000, new HiringDate(4, 2, 1983), Gender.Male, SecurityLevel.developer);
            var e3 = new Employee(3, 25000, new HiringDate(12, 1, 2002), Gender.Male, SecurityLevel.developer);
            var e4 = new Employee(4, 25000, new HiringDate(1, 1, 1972), Gender.Male, SecurityLevel.developer);
            var e5 = new Employee(5, 25000, new HiringDate(28, 8, 2004), Gender.Male, SecurityLevel.developer);
            var e6 = new Employee(6, 25000, new HiringDate(28, 8, 2002), Gender.Male, SecurityLevel.developer);

            Employee[] arr = { e1, e2, e3, e4, e5 ,e6};
            foreach (Employee e in arr)
            {

                Console.WriteLine(e);
            }

            Array.Sort(arr);
            Console.WriteLine("============================");

            foreach (Employee e in arr)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("============================");


            #endregion
            #endregion


            #region Lab4

            #region  task1
            //Point3D P = new Point3D(10, 10, 10);
            //Console.WriteLine(P.ToString());

            //Point3D[] points = new Point3D[3];

            //for (int i = 0; i < points.Length; i++)
            //{
            //    points[i] = Helpers.ReadPoint($"Point {i + 1}");
            //}

            //Console.WriteLine("\nPoints Data:");
            //foreach (Point3D p in points)
            //{
            //    Console.WriteLine(p);
            //} 


            var p1 = new Point3D(10, 10, 10);
            var p2 = new Point3D(15, 15, 15);
            var p3 = new Point3D(15, 15, 15);
            var p4 = p3;


            Point3D[] Parr =
                [
                    new Point3D (10, 10, 10),
                    new Point3D (5,6,7),
                    new Point3D (5,20,40),
                    new Point3D (5,20,17)
                ];


            Array.Sort(Parr);

            foreach(var  p in Parr)
                { Console.WriteLine(p); }


            Console.WriteLine("======================================");

            if (p2 == p3)
            {
                Console.WriteLine("Eq");
            }
            else
            {
                Console.WriteLine("Not Eq");
            }

             
            if(p2.Equals(p3))
            {
                Console.WriteLine("Eq");
            }
            else
            {
                Console.WriteLine("Not Eq");
            }

            Console.WriteLine();

            var p10 = p1.Clone();
            Console.WriteLine(p10==p1);
            Console.WriteLine(p10.Equals(p1));
            #endregion
            #region task2
            //Console.WriteLine(MathOperations.Add(10, 5));
            //Console.WriteLine(MathOperations.Subtract(10, 5));
            //Console.WriteLine(MathOperations.Multiply(10, 5));
            //Console.WriteLine(MathOperations.Divide(10, 5));
            #endregion

            #endregion


            #region Lab5

            //var myTimeOne = new Duration();
            //Console.WriteLine(myTimeOne);


            //Console.WriteLine("============================================");


            //var myTimeTwo = new Duration()
            //{
            //    Hours = 5,
            //    Minutes = 5,
            //    Seconds = 5,
            //};
            //Console.WriteLine(myTimeTwo);

            //Console.WriteLine("============================================");

            //var myTimeThree = new Duration(3600);
            //Console.WriteLine(myTimeThree);

            //Console.WriteLine("============================================");



            //var d1 = new Duration(1,20,30);
            //var d2 = new Duration(1, 20, 30);
            //var d3 = d1 + d2;
            //Console.WriteLine(d3);

            //var d4 = d1 + 3600;
            //Console.WriteLine(d4);

            //var d5 = d1++;
            //Console.WriteLine(d5);

            //var d6 = d1--;
            //Console.WriteLine(d6);


            //Console.WriteLine((d1 > d2) ? "D1>D2" : "D2<D1");

            //var dateTime = (DateTime)d1;
            //Console.WriteLine(dateTime);











            #endregion






        }
    }
}
