namespace SD46CSD03
{

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Enum Part 01
            //////enum -> value type
            //////enum is represented by numeric value
            /////

            //Gender g1;
            //g1 = Gender.female;
            //Console.WriteLine(g1);

            //Gender g2;
            //string str;
            //Console.WriteLine("Enter Gender male or female");
            //str=Console.ReadLine();
            //if (str.ToLower()=="female")
            //{
            //    g2 = Gender.female;
            //}
            //else
            //{
            //    g2 = Gender.male;
            //}
            //Console.WriteLine(g2);

            ////Enum.Parse(,);


            //DayName d1 = 0;
            //d1 = (DayName)1;
            //Console.WriteLine(d1);

            #endregion

            #region casting between numeric DT    _[discard]
            //int x = int.MaxValue;
            //double y = 44_444_444_444;

            ////unsafe casting [implicit casting->compile error]
            ////x = y;

            ////explicit casting is MUST
            //x = (int)y;


            ///////safe casting => done implicitly
            ////y = x;

            //////explicit casting  [useless here]
            ////y = (double)x;

            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");


            //checked
            //{
            //    x = (int)y;
            //    unchecked 
            //    {
            //        //x = (int)y;
            //    }



            //    ///


            //}


            #endregion

            #region casting between value Type and system.Object
            //int x = 10;
            //double y = 20;
            //string str = "Rodan";

            ////safe casting   [Boxing]
            //object o1 = x;
            //object o2 = y;

            //Console.WriteLine(o1.GetType().Name);
            //Console.WriteLine(o2.GetType().Name);


            ////--->unboxing
            //int result = (int)o1;




            //object o3 = str;

            //int result2 = (int)o3;
            //Console.WriteLine(result2);



            #endregion

            #region implicit type cast [var]  => Linq
            //int x = 3;
            //var y = 4;
            //var str = "Ahmed";
            //var z = 1.2f;
            //var a="";

            /////var A1=List.Where(ww=>ww.Id==1).OrderBy(ww=>ww.Name)

            ////var fff = new Dictionary<string, WeakReference>();
            #endregion

            #region dynamic    => asp.net core mvc [ViewBag]   //interoperability
            //dynamic x;

            //x = 10;
            //Console.WriteLine(x.GetType());
            //Console.WriteLine(x.Length);
            //x = "Rodan";
            //Console.WriteLine(x.GetType());
            //Console.WriteLine(x.Length);
            #endregion

            #region Nullable Value type
            ////value type cannot be null
            //int x;

            ////DB  sql Server
            /////Employee
            /////intPK  vcNN   intN    decimalN     
            /////id     name   age    salary
            /////1      ali    22     null
            /////2      sara   null   null
            /////3      osama  null   null
            /////

            /////ORM [EF]
            /////class Employee{
            /////int id
            /////string name
            /////int? age
            /////decimal? salary
            /////}
            /////Employee e1=new Employee(3,"Osama",null,null);
            /////
            ///

            //////nullabe value type
            ////Nullable<int> x;
            //int? x = null;

            ////x = 10;
            //if (x.HasValue)
            //{
            //    Console.WriteLine(x.Value);
            //}
            //else 
            //{
            //    Console.WriteLine("EMPTY");
            //}

            #endregion

            #region default & null propagation operator
            //string str = default;
            //int x = default;
            //int[] arr = default;

            ////Console.WriteLine(str);
            ////Console.WriteLine(str.Length);

            //if (str != null)
            //{
            //    Console.WriteLine(str.Length);
            //}
            //else 
            //{
            //    Console.WriteLine("EMPTY");
            //}

            //Console.WriteLine(str?.Length);


            ////for (int i = 0; i < arr.Length; i++) 
            ////for (int i = 0;arr!=null&&i < arr.Length; i++)
            //for (int i = 0;i<arr?.Length; i++) 
            //{
            //    Console.WriteLine(arr[i]);
            //}
            ///

            ////left??right   [Reference type]
            //Console.WriteLine(str?.Length??-1);








            //////unprotective/undefensive code
            ////Console.WriteLine(str.Length);
            //////Object reference not set to an instance of an object.

            ////if(str !=null )
            ////{
            ////    Console.WriteLine(str.Length);
            ////}
            ////else
            ////{
            ////    Console.WriteLine("EMPTY!!!!");
            ////}


            //Console.WriteLine(str?.Length ?? -1);

            ////left??right

            ////for (int i = 0; arr!=null && i < arr.Length; i++)
            //for (int i = 0; i < arr?.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            ////Console.WriteLine(x.Value);
            #endregion

            #region non nullable reference type start from .net 6
            ///////till .net 5
            ///////reference type can carry null as a normal way

            ///////from .net 6
            ///////reference type is non nullabe [as default]
            ///////if non nullabale ref type assigned by null 
            ///////WARNING NOT COMPILE ERROR
            /////


            //string str = null;
            //Console.WriteLine(str);


            #endregion


            #region One Employee  [struct]
            //Employee e1; //object from Emloyee 24B

            //e1 = new Employee();
            ////new +struct=> data initialization ONLY
            //e1.SetId(1);
            //e1.SetName("Ahmed");
            //e1.SetAge(22);
            //e1.SetSalary(23456);

            //Console.WriteLine(e1);  //T  namespaceName.DTName 
            //Console.WriteLine(e1.GetId());
            //Console.WriteLine(e1.GetName());
            //Console.WriteLine(e1.GetAge());
            //Console.WriteLine(e1.GetSalary());
            //Console.WriteLine(e1.Print());


            //Employee e2=new Employee();
            ////new + struct=> initialization only
            //Console.WriteLine("Enter id");
            //e2.SetId(int.Parse(Console.ReadLine()));
            //Console.WriteLine("Enter name");
            //e2.SetName(Console.ReadLine());
            //Console.WriteLine("Enter age");
            //e2.SetAge(int.Parse(Console.ReadLine()));
            //Console.WriteLine("Enter salary");
            //e2.SetSalary(decimal.Parse(Console.ReadLine()));

            //Console.WriteLine(e2.Print());

            #endregion

            #region Employees array
            //Employee[] employees; //ZEROOOOOB  //null  //reference
            ////new + array -> allocation + data initialization
            //employees = new Employee[3];

            ////////useless
            ////employees[0]=new Employee();  //new +struct=> initialization ONLY
            ////////
            
            //for (int i = 0; i < employees?.Length; i++) 
            //{
            //    Console.WriteLine("Enter id");
            //    employees[i].SetId(int.Parse(Console.ReadLine()));
            //    Console.WriteLine("Enter name");
            //    employees[i].SetName(Console.ReadLine());
            //    Console.WriteLine("Enter age");
            //    employees[i].SetAge(int.Parse(Console.ReadLine()));
            //    Console.WriteLine("Enter salary");
            //    employees[i].SetSalary(decimal.Parse(Console.ReadLine()));
            //}
            //for (int i = 0; i < employees?.Length; i++)
            //{
            //    Console.WriteLine(employees[i].Print());
            //}
            #endregion

            #region Employee With Dept & Gender
            //Employee e1=new Employee();
            //Console.WriteLine(e1.Print());

            //Employee e2 = new Employee();
            ////new + struct=> initialization only
            //Console.WriteLine("Enter id");
            //e2.SetId(int.Parse(Console.ReadLine()));
            //Console.WriteLine("Enter name");
            //e2.SetName(Console.ReadLine());
            //Console.WriteLine("Enter age");
            //e2.SetAge(int.Parse(Console.ReadLine()));
            //Console.WriteLine("Enter salary");
            //e2.SetSalary(decimal.Parse(Console.ReadLine()));
            //Console.WriteLine("Enter Gender");
            //var resG=(Gender)Enum.Parse(typeof(Gender), Console.ReadLine());
            //e2.SetGender(resG);
            //Department ResD= new Department();
            //Console.WriteLine("Enter Dept id");
            //ResD.SetDeptId(int.Parse(Console.ReadLine()));
            //Console.WriteLine("Enter Dept name");
            //ResD.SetDeptName(Console.ReadLine());
            //e2.SetDepartment(ResD);

            //Console.WriteLine(e2.Print());
            #endregion

        }
    }
}
