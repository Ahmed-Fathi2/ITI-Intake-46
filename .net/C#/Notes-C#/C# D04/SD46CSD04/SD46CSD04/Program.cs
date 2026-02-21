namespace SD46CSD04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region use Property
            //Student s1;
            //s1=new Student();
            ////new + struct=> data initialization ONLY
            ////Console.WriteLine("Enter Id");
            ////s1.SetId(int.Parse(Console.ReadLine()));
            ////Console.WriteLine("Enter Name");
            ////s1.SetName(Console.ReadLine());
            ////Console.WriteLine("Enter Age");
            ////s1.SetAge(int.Parse(Console.ReadLine()));
            ////Console.WriteLine(s1.GetId());
            ////Console.WriteLine(s1.GetName());
            ////Console.WriteLine(s1.GetAge());

            ////s1.Zizo = 10;
            ////Console.WriteLine(s1.Zizo);

            //Console.WriteLine("Enter Id");
            //s1.Id=int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter Name");
            //s1.Name = Console.ReadLine();
            //Console.WriteLine("Enter Age");
            //s1.Age=int.Parse(Console.ReadLine());

            //Console.WriteLine(s1.Id);
            //Console.WriteLine(s1.Name);
            //Console.WriteLine(s1.Age);
            #endregion

            #region ToString()
            //int x = 10;
            //string str = "Zizo";

            //Console.WriteLine(x);
            //Console.WriteLine(x.ToString());
            //Console.WriteLine(str);
            //Console.WriteLine(str.ToString());

            //Student s1=new Student();
            //s1.Id = 1;
            //s1.Name = "Zizo";
            //s1.Age = 22;

            //Console.WriteLine(s1.Print());
            //Console.WriteLine(s1);
            //Console.WriteLine(s1.ToString());

            #endregion

            #region Struct Region
            #region One Student
            //Student s1;  //Object 8Bytes
            //s1=new Student();  //initialization ONLY
            #endregion
            #region Array Of 3 Students
            //Student[] students; //ZEROOOO Bytes
            //students = new Student[3];
            #endregion
            #endregion

            #region Class Region
            #region One Employee
            //Employee e1;  //ZERO Bytes  //null   //refeerence type
            //e1=new Employee();
            ////new +class=> allocation + data initialization
            //Console.WriteLine("Enter id");
            //e1.Id=int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter name");
            //e1.Name = Console.ReadLine();
            //Console.WriteLine("Enter age");
            //e1.Age= int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter salary");
            //e1.Salary= float.Parse(Console.ReadLine());

            //Console.WriteLine(e1);
            #endregion
            #region Array Of 3 Employees
            //Employee[] employees; //ZERO Bytes
            //employees = new Employee[3];
            ////new + array=> allocation + data initialization

            //////
            ////employees[0] = new Employee();
            ////employees[1] = new Employee();
            ////employees[2] = new Employee();
            //////
            //for (int i = 0; i < employees.Length; i++)
            //{
            //    //
            //    employees[i] = new Employee();
            //    //
            //    Console.WriteLine("Enter id");
            //    employees[i].Id = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Enter name");
            //    employees[i].Name = Console.ReadLine();
            //    Console.WriteLine("Enter age");
            //    employees[i].Age = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Enter salary");
            //    employees[i].Salary = float.Parse(Console.ReadLine());
            //}
            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine(employees[i]);
            //}

            #endregion

            #region Famous Runtime error
            //// Object reference not set to an instance of an object.
            #endregion

            #endregion

            #region Create object via named parameters
            //Console.WriteLine(Draft.Add(10,20,30));
            //Console.WriteLine(Draft.Add(right:30,left:10,middle:20));

            ////Employee e1 = new Employee(1,"Ahmed",22,33,44,'M',45678,false);

            //Employee e2 = new Employee(_id:1,_salary:1234,_age:22,_name:"Ahmed");
            #endregion

            #region create object via property initializer [most commonly used]
            //Employee e1 = new Employee()
            //{
            //    Id = 1,
            //    Name = "Ali",
            //    Salary = 1234,
            //    Age = 22
            //};

            ////syntax sugar 
            //Employee e2 = new Employee
            //{
            //    Id = 1,
            //    Name = "Ali",
            //    Salary = 1234,
            //    Age = 22
            //};


            //Employee e3 = new()
            //{
            //    Id = 1,
            //    Age = 22,
            //    Salary = 12345
            //};
            //Console.WriteLine(e3);


            //Student s1 = new() { Id = 2, Name = "", Age = 22 };

            #endregion

            #region Pass Value Type By Values/state   read only
            //int x = 3, y = 5;
            //Console.WriteLine("Before Swap");
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");
            //Draft.SwapV( x, y );  //Pass VALUESSSSSSSSS  / state
            //Console.WriteLine("After Swap");
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");
            #endregion

            #region Pass Value Type By Reference[alias name]   read/write
            //int x = 3, y = 5;
            //Console.WriteLine("Before Swap");
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");
            //Draft.SwapR(ref x,ref y);  //PassReference
            //Console.WriteLine("After Swap");
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");
            #endregion

            #region Pass Reference type By value
            //int[] arr = [1, 2, 3, 4, 5];
            //Console.WriteLine($"in main arr identity {arr.GetHashCode()}");
            //Draft.PrintArrayV(arr); //pass reference type by values
            ////
            //Console.WriteLine("Fn ended");
            //for (int i = 0; i < arr.Length; i++) 
            //{
            //    Console.Write($"{arr[i]}\t");
            //}
            #endregion

            #region Pass Reference type By Reference[alias name]
            //int[] arr = [1, 2, 3, 4, 5];
            //Console.WriteLine($"in main arr identity {arr.GetHashCode()}");
            //Draft.PrintArrayR(ref arr); //pass reference type by reference
            ////
            //Console.WriteLine("Fn ended");
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write($"{arr[i]}\t");
            //}
            #endregion

            #region this
            //Student s1=new Student();
            //s1.SetId(1);   ///Student.SetId(s1,1)

            //Employee e1=new Employee();
            //Console.WriteLine(e1.ToString());   //Employee.ToString(e1)
            #endregion

            #region ref Vs. out [pass by reference]+[pass unassigned local variable]
            //int x = 3, y = 4;
            //int addR, subR;
            //Draft.AddAndSub(x, y,out addR,out subR);
            //Console.WriteLine(addR);
            //Console.WriteLine(subR);


            //int a, s;
            //Draft.AddAndSub(3, 4,out a,out s);


            //Draft.AddAndSub(3, 4, out int a, out int s);
            #endregion

            #region anonymous object
            //new Employee() { Id=1,Name="Zizo",Age=22,Salary=45678}; 

            //Employee[] employees = new Employee[3] 
            //{
            //    new Employee{Id=1,Name="Zizo",Age=22,Salary=12345},
            //    new Employee{Id=2,Name="Zizo",Age=22,Salary=12345},
            //    new Employee{Id=3,Name="Zizo",Age=22,Salary=12345}
            //};


            #endregion

            #region foreach
            //Employee[] employees = new Employee[3]
            //{
            //    new Employee{Id=1,Name="Zizo",Age=22,Salary=12345},
            //    new Employee{Id=2,Name="Zizo",Age=22,Salary=12345},
            //    new Employee{Id=3,Name="Zizo",Age=22,Salary=12345}
            //};

            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            #region namespace access modifiers
            ///inside namespace
            ///1-class
            ///2-struct
            ///3-enum
            ///4-interface
            ///5-delegate
            ///
            ///access modifers inside namespace
            ///1- public [recommended]:this dt can be accessed inside and outside project[assembly]
            ///2- internal[default]:this dt can be accessed inside project[assembly] ONLY


            #endregion

            #region class access modifiers
            ///1-public
            ///2-protected
            ///3-private
            ///4-internal:member can be accessed inside assembly[project]
            ///5-protected internal:member can be accessed inside any inheritance and accessed inside assembly if any relation happened
            ///
            ///6-private protected
            #endregion

            #region Parse,TryParse,Convert
            //int x;
            //Console.WriteLine("Enter #");
            ////x=int.Parse(Console.ReadLine());
            ////x=Convert.ToInt32(Console.ReadLine());

            //if (int.TryParse(Console.ReadLine(), out int result))
            //{
            //    Console.WriteLine(result);
            //}
            //else
            //{
            //    Console.WriteLine("WrongInput");
            //}



            //Console.WriteLine(x);
            #endregion

            #region Early binding vs. late binding
            Geoshape g1 = new Rectangle{ Dim1=3,Dim2=4};
            Console.WriteLine(g1.Area());
            #endregion

        }
    }
}
