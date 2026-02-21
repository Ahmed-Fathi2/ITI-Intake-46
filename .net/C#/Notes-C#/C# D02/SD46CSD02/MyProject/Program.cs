//using System.Diagnostics;

namespace MyProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Data Type
            //int x = 10;
            //float y = 20;
            //bool flag = true;
            //double z=1.2;
            //float a = 1.2F;
            //decimal b = 1.2M;
            #endregion

            #region ValueType
            //int x = 3;
            //int y = 5;
            ////int z;  //4b unassigned local variable
            ////Console.WriteLine(z); //compile error
            //x = y; //assign state
            //y = 1000;
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");
            #endregion

            #region ReferenceType
            ////Object o1; //ZEROOOO Bytes have been allocated

            //object o1=new object();
            //object o2 =new object();
            ////new + class= allocation +initialization + reference assign

            //Console.WriteLine($"o1 Id = {o1.GetHashCode()}");
            //Console.WriteLine($"o2 Id = {o2.GetHashCode()}");

            //o1 = o2;

            //Console.WriteLine($"o1 Id = {o1.GetHashCode()}");
            //Console.WriteLine($"o2 Id = {o2.GetHashCode()}");
            #endregion

            #region Write in Console
            #endregion

            #region Read From User in Runtime
            #endregion

            #region If
            ////WRONG [Compile Error]
            ////int x = 10;
            //////if (x) { }
            //////if (x=8) { }
            //////if (!x) { }
            /////

            ////if (Must be condition)
            ////{ }
            ////else { }

            //bool flag = true;
            //if (flag) { }

            #endregion

            #region Switch
            //////switch comes with int ,string,char
            //int month;
            //Console.WriteLine("Enter month #");
            //month=int.Parse(Console.ReadLine());

            //switch (month)
            //{
            //    case 1:
            //    case 11:
            //        Console.WriteLine("Jan");
            //        break; //compile Error
            //    case 2:
            //        Console.WriteLine("Feb");
            //        break;
            //    case 3:
            //        Console.WriteLine("Mar");
            //        break;
            //    case 4:
            //        Console.WriteLine("Apr");
            //        break;
            //    default:
            //        Console.WriteLine("NA");
            //        break;
            //}
            #endregion

            #region Block Statement
            //{
            //    int x;
            //    x = 100;
            //    Console.WriteLine(x);
            //}
            ////Console.WriteLine(x);
            #endregion

            #region 1D Array
            ////Array is a Reference Type
            ////Array :fixed size collection of data with same DT
            ////stored sequentially in memory

            //int[] arr; //ZEROOOOOO B   //null //reference 
            //arr = new int[5];   ///
            ////new + array = allocation in heap + data initialization

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine($"Enter # at index {i}");
            //    arr[i]=int.Parse( Console.ReadLine() );
            //}
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write($"{arr[i]}\t");
            //}
            #endregion

            #region 2D Array
            //int[,] arr = new int[3, 4];
            //for (int i = 0; i<arr.GetLength(0);i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        Console.WriteLine("Enter #");
            //        arr[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}
            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        Console.Write($"{arr[i,j]} \t");
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #region Array Default Values with declaration
            //int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            //int[] arr2 = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ////int[] arr3=new int[]; //Compile error
            //int[] arr4=new int[]{1,2,3,4,5};

            ////sugar syntax
            //int[] arr5 = { 1, 2, 3, 4, 5 };
            //int[] arr6 = [1, 2, 3, 4, 5];


            //int[] arr7; //ZEROOOO Bytes  //NULL

            ////string str=new string("Abdel Aziz");
            ////string str2 = "Abdel Aziz";


            //int[,] arr8 = new int[3, 4] { {1,1,1,1 },{2,2,2,2 },{3,3,3,3 } };
            //int[,] arr9 = new int[, ] { {1,1,1,1 },{2,2,2,2 },{3,3,3,3 } };
            //int[,] arr10 = { {1,1,1,1 },{2,2,2,2 },{3,3,3,3 } };


            #endregion

            #region Jagged Array  Less Usage
            //int[][] arr = new int[4][];
            //arr[0] = new int[2];
            //arr[1] = new int[3];
            //arr[2] = new int[1];
            //arr[3] = new int[4];
            #endregion

            #region foreach
            //int[] arr = [1, 2, 3, 4, 5];
            //foreach (int item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            //Stopwatch s = new Stopwatch();
            //s.Start();
            ////code
            //s.Stop();
            //Console.WriteLine(s.Elapsed);
        }
    }
}
