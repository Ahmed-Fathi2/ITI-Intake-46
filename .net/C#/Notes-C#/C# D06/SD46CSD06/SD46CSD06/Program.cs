using System.Runtime.Intrinsics.Arm;

namespace SD46CSD06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Composition -worst technique-
            //Rect r1=new Rect(1,2,3,4);

            ////Line l2=new Line(1,2,3,4);
            ////o/p
            ////point ctor
            ////point ctor
            ////line ctor

            ////Line l1=new Line();
            ////o/p
            ////point ctor
            ////point ctor
            ////line ctor
            #endregion

            #region Aggregation/Association    SOLID
            //Point pnt1 = new Point { X = 3, Y = 4 };
            //Point pnt2 = new Point { X = 5, Y = 6 };
            //Point pnt3 = new Point { X = 7, Y = 8 };

            //Tri t1 = new Tri();

            ////set relationship
            //t1.P1 = pnt1;
            //t1.P2 = pnt2;
            //t1.P3 = pnt3;

            ////process
            //Console.WriteLine(t1);

            ////remove relationship
            //t1.P1 = null;
            //t1.P2 = null;
            //t1.P3 = null;


            //Tri t2= new Tri(pnt1,pnt2,pnt3);
            ////remove relationship
            //t2.P1 = null;
            //t2.P2 = null;
            //t2.P3 = null;

            #endregion

            #region Inheritance  : C# Supports multi level inheritance ONLY
            ////Child c1= new Child(1,2,3);
            ////Console.WriteLine(c1.Sum());   


            //Parent p2 = new Child(1, 2, 3);
            //Console.WriteLine(p2.Sum()); //6
            #endregion

            #region Interface
            //////classA 
            //////classB
            //////classC :classA,classB   ???  NOOOOOO

            //////interface: protocol bet. classes
            ///////interface is reference type
            ///////interface is like abstract class
            ///////interface in one of data type that is written inside namespace
            ///////we can write methods and property inside interface
            ///////methods inside interface MUST be abstract method  //untilc#9
            ///////properties inside interface MUST be auto property //untilc#9
            ///////properties&methods inside inteface dont use access modifier;as it is implemented ALWAYS public //untilc#9
            ///////you can inherit/implement Multiple Interfaces
            ///////
            /////
            ///

            ////IMyInterface2 myInterface2 = new MyService();
            ////Console.WriteLine(myInterface2.Mul(4,5));


            //MyService s1=new MyService();
            ////s1.(IMyInterface)SignIn();

            //IMyInterface i1 = s1;
            //i1.SignIn();

            //IMyInterface2 i2 = s1;
            //i2.SignIn();



            #endregion

            #region Reference Type Object Equality   [check]

            /////==                                             reference
            /////syatem.Object
            /////public virtual Equals(object o1){}             reference
            /////public static Equals(object o1,object o2){}    reference
            /////public static ReferenceEquals(object o1,object o2){} reference

            //Point p1 = new Point { X = 3, Y = 4 };
            //Point p2 = new Point { X = 5, Y = 6 };
            //Point p3 = new Point { X = 3, Y = 4 };
            //Point p4 = p1;
            //Point p5 = default;
            //Point3D p3d = new Point3D { X = 3, Y = 4, Z = 5 };

            ////if (p1==p4)
            ////if (p1.Equals(p4))
            ////if (object.Equals(p1,p4))
            ////if (object.ReferenceEquals(p1, p4))
            //if (p1.Equals(p3d))
            //{
            //    Console.WriteLine("EQ");
            //}
            //else
            //{
            //    Console.WriteLine("NEQ");
            //}

            #endregion

            #region Value Type Object Equality   [check]
            ///////==                 Not Exist u must overload ==
            ///////syatem.Object
            ///////public virtual Equals(object o1){}             State
            ///////public static Equals(object o1,object o2){}    state
            ///////public static ReferenceEquals(object o1,object o2){} Not work properly

            //Duration d1=new Duration { Hour=1,Minute=1,Second=1};
            //Duration d2=new Duration { Hour=1,Minute=1,Second=1};
            ////if (d1==d2) 
            ////{ }

            #endregion

            #region Sort Array of Points
            #endregion

            #region DI Example
            ///principles   
            ///concepts       
            ///frameworks     
            #endregion


            #region Sort Arrays of built-in DT
            //int[] arr = { 7, 6, 5, 4, 3, 6, 7, 88, 77, 66, 43, 2 };
            //string[] names = { "Ziad", "Osama", "Aalaa", "Ali", "Aya" };

            //Array.Sort(names); //Call CompareTo 

            //foreach (var item in names)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Employee with relations
            #endregion

            #region Sort Arrays of User Defined DT
            //Employee[] employees = 
            //{
            //    new Employee{Id=1,Name="Ziad",Age=22,Salary=9234,DeptId=10},
            //    new Employee{Id=2,Name="Sara",Age=25,Salary=3234,DeptId=20},
            //    new Employee{Id=3,Name="Rodan",Age=24,Salary=5234,DeptId=30},
            //    new Employee{Id=4,Name="Alaa",Age=23,Salary=7234,DeptId=10},
            //    new Employee{Id=5,Name="Osama",Age=22,Salary=1234,DeptId=10}
            //};

            //Array.Sort(employees);

            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Clone

            ////int[] arr = [1, 2, 3, 4, 5];

            ////int[] arr2 = (int[])arr.Clone();

            ////Console.WriteLine($"arr id {arr.GetHashCode()}");
            ////Console.WriteLine($"arr2 id {arr2.GetHashCode()}");



            //Employee e1 = new Employee { Id = 5, Name = "Osama", Age = 22, Salary = 1234, DeptId = 10 };

            //Employee e2 = e1.Clone() as Employee;


            //Console.WriteLine($"e1 id {e1.GetHashCode()}");
            //Console.WriteLine($"e2 id {e2.GetHashCode()}");
            #endregion

            #region Try Catch         -> Worst cases in error handling

            //int age;


            //try
            //{
            //    Console.WriteLine("Enter age");
            //    age = int.Parse(Console.ReadLine());
            //    //int.TryParse(Console.ReadLine(), out age);  

            //    int[] arr = [1, 2, 3, 4, 5];
            //    //if 7 in boundry of array
            //    //arr[7] = 99;

            //    int x = 3, y = 0, z;
            //    //if y != ZERO
            //    z = x / y;
            //}
            //catch (DivideByZeroException ex)
            //{
            //    //log in db
            //    Console.WriteLine($"Error happened {ex.Message}");
            //}
            //catch (IndexOutOfRangeException ex)
            //{
            //    //log in db
            //    Console.WriteLine($"Error happened {ex.Message}");
            //}
            //catch (FormatException ex)
            //{
            //    //log in db
            //    Console.WriteLine($"Error happened {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    //log in db
            //    Console.WriteLine($"Error happened {ex.Message}");
            //}
            //finally
            //{
            //    Console.WriteLine("This will be executed if there is exeption OR NOT");
            //}


            #endregion

            #region Mutable,Immutable
            /////Mutable object:Object we can change its [*state*] anytime 
            /////Immutable object:object when created ,you cannot change its state EVER
            #endregion

            #region String Dt is Immutable Object  intern pool
            ////string str1 = "Hello from .NET";
            ////str1 += " SD Group";
            ////str1 += " Good Bye";


            /////StringBuilder
            /////


            //string name1 = "Hello Rodan";
            //string name2 = "Hello";

            //Console.WriteLine($"name1 {name1.GetHashCode()}");
            //Console.WriteLine($"name2 {name2.GetHashCode()}");

            //name2 += " Rodan";
            //Console.WriteLine();
            //Console.WriteLine($"name1 {name1.GetHashCode()}");
            //Console.WriteLine($"name2 {name2.GetHashCode()}");
            
            //name2 += " AGAIN";
            //Console.WriteLine();
            //Console.WriteLine($"name1 {name1.GetHashCode()}");
            //Console.WriteLine($"name2 {name2.GetHashCode()}");

            #endregion

            #region Template -> Generics V01
            #endregion


        }
    }
}
