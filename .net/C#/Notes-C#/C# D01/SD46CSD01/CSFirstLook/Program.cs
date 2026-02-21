using System.Data; //use libraries directly exist in that namespace
using System;
using System.Collections;
using System.Collections.Generic;
namespace CSFirstLook
{
    struct Osama
    {
        //Entry Point
        static void Main()
        {
            #region write to console
            //Console.WriteLine("Hello SD");
            //string name = "Sara";
            //int age = 22;

            ////WORST CASE EVER [String concat] [memory overhead]
            //Console.WriteLine("my name is " + name);
            //Console.WriteLine("My name is {0}", name);
            //Console.WriteLine("My name is {0}, age is {1}", name, age);
            ////RECOMMENDED [string interpolation]
            //Console.WriteLine($"my name is {name},age is {age}");
            //string str = "my name is " + name;
            //string str2 = $"my name is {name}";
            #endregion

            #region Read in Console
            int age;
            string name;
            float salary;

            Console.WriteLine("Enter name");
            name=Console.ReadLine();
            Console.WriteLine("Enter age");
            age=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter salary");
            salary=float.Parse(Console.ReadLine());
            Console.WriteLine($"name={name},age={age},salary={salary:c}");
            #endregion
        }
    }
}
