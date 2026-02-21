using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SD46CSD07
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Mutabililty
            //////mutable object:object u can change its state anytime
            //MutablePoint o1 = new MutablePoint { X = 3, Y = 4 };
            //Console.WriteLine(o1.GetHashCode());
            //o1.X = 5;
            //o1.Y = 6;
            //Console.WriteLine(o1.GetHashCode());
            #endregion
            #region Immutability
            //ImmutablePoint o1 = new ImmutablePoint(3,4);
            //Console.WriteLine(o1.GetHashCode());

            //o1= new ImmutablePoint(5,6);
            //Console.WriteLine(o1.GetHashCode());


            //var o2 = new ImmutablePoint2 { X = 5, Y = 6 };
            //o2.X = 9;

            #endregion

            #region StringBuilder
            //StringBuilder sb=new StringBuilder();
            //Console.WriteLine(sb.GetHashCode());
            //sb.Append("Hello SD");
            //sb.Append(Environment.NewLine);
            //sb.Append("Byeeee");
            //Console.WriteLine(sb.GetHashCode());
            //Console.WriteLine(sb);
            #endregion

            #region Generics
            ////Stack s1=new Stack(10);
            //MyStack<int> s1=new MyStack<int>();
            //s1.Push(1);
            //MyStack<string> s2=new MyStack<string>();
            //s2.Push("Sara");
            //MyStack<MutablePoint> s3 = new MyStack<MutablePoint>();
            #endregion

            #region Generic Constraints

            #endregion

            #region Array Big Issue
            //FIXED SIZE
            #endregion

            #region ArrayList    ///NON Generic Collection   System.Collections
            //ArrayList l1=new ArrayList(5);
            //int x = 1;
            //l1.Add(x);
            //l1.Add(2);
            //l1.Add(3);
            //l1.Add("Ahmed");
            //l1.Add(new Employee());
            //Console.WriteLine(l1.Capacity);
            //l1.Add(1000);
            //Console.WriteLine(l1.Capacity);
            //l1.Add(1000);
            //l1.Add(1000);
            //l1.Add(1000);
            //l1.Add(1000);
            //l1.Add(1000);
            //l1.AddRange(new int[] { 4, 5, 6, 7, 8 });
            //Console.WriteLine(l1.Capacity);

            //foreach (var item in l1)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion


            #region Generic Collection => List<T>
            //int[] arr = [6, 7, 8, 9, 10];
            //List<int> numbers=new List<int>(5);
            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            //numbers.Add(4);
            //numbers.Add(5);
            //numbers.AddRange(arr);
            //Console.WriteLine($"------>{numbers.Capacity}");
            //numbers.Add(5);
            //Console.WriteLine($"------>{numbers.Capacity}");
            //numbers[0] = 1000;  //update
            //Console.WriteLine(numbers[0]); //select
            ////numbers[10] = 500;   //insert  WRONG

            //foreach (var item in numbers) 
            //{
            //    Console.WriteLine(item);
            //}

            //numbers.TrimExcess();
            //Console.WriteLine($"========>{numbers.Capacity}");

            ////numbers.

            ////for (int i = 0; i < numbers.Count; i++)
            ////{

            ////}
            #endregion

            #region Dictionary<Key,Value> Generic collections
            //Dictionary<int, string> map = new Dictionary<int, string>();
            //map.Add(5, "Ahmed");
            //map.Add(4, "Sara");
            //map.Add(3, "Osama");
            //map.Add(2, "Shahd");
            //map.Add(1, "Mohamed");


            //map[1] = "Kaza"; //Update
            //map[6] = "Ay 7aga"; //Add
            ////Console.WriteLine(map[3]); //select



            ////map.Add(1, "Ziad");
            //if (map.TryAdd(1, "Ziad"))
            //{

            //}
            //else
            //{
            //    map[1] = "Ziad";
            //}

            //foreach (var item in map)
            //{
            //    Console.WriteLine($"{item.Key}:{item.Value}");
            //}


            #endregion

            #region Check Equality
            //var e1 = new Employee { Id = 1, Name = "MNasser", Age = 22 };
            //var e2 = new Employee { Id = 1, Name = "MNasser", Age = 22 };

            //Console.WriteLine(e1.Equals(e2));
            //Console.WriteLine(e1.GetHashCode());
            //Console.WriteLine(e2.GetHashCode());


            //var p1 = new Person(1, "MNasser", 22);
            //var p2 = new Person(1, "MNasser", 22);

            //Console.WriteLine(p1.Equals(p2));

            #endregion

            #region Additional data with Add  [List]
            ////List<int> nums=new List<int>();
            ////nums.Add(1);


            //MyList<int> nums=new MyList<int>();
            //nums.Add(1);
            //nums.Add(2);
            //nums.Add(3);
            //nums.Add(4);
            //nums.Add(5);
            //Console.WriteLine("===============================");
            //foreach (var item in nums)
            //{
            //    Console.WriteLine(item);
            //}

            //List<int> XYZ=new MyList<int>();    

            #endregion

            #region REMEMBER  [LINQ]
            /////ALL COLLECTIONS : IEnumerable
            /////
            //IEnumerable<int> xarr=new List<int>();
            //IEnumerable arr = new int[] { 1, 2, 3, 4 };
            #endregion

            #region Lab Assignment
            ///Examination System
            #endregion

        }
    }
}
