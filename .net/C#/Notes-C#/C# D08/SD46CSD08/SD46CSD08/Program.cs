//using static System.Console;
namespace SD46CSD08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Repository
            var emps = Repository.Employees;
            //foreach (var emp in emps) 
            //{
            //    Console.WriteLine(emp);
            //}
            #endregion

            #region Filtration V1
            //var filterdEmps=Filtration.FilterPerDeptId(emps);
            //filterdEmps=Filtration.FilterPerSalary(emps);
            //filterdEmps=Filtration.FilterPerName(emps);
            //filterdEmps=Filtration.FilterPerAny(emps);
            //foreach (var item in filterdEmps)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region THINK
            //var filterdEmps=Filtration.FilterPer???(emps,how to filter);
            ///how to filter
            ///salary>5000
            ///age>25
            ///name=="" && age>4
            ///
            //var filterdEmps=Filtration.FilterPer???(emps,FilterPer.PerSalary());
            //filterdEmps=Filtration.FilterPer???(emps,FilterPer.PerDept());

            //i need variable carries function
            //thats called delegate
            #endregion

            #region Delegate
            /////pointer to function
            /////variable can carry/point function
            /////delegate is a reference type
            /////delegate is 5th dt written inside namespace

            /////when you want to declare delegate that points fn
            /////you must declare it with same signature of that fn


            //MyDelegate del1 = new MyDelegate(Trial.PerDept);
            /////function PerDept
            /////add name called del1
            //var e1 = new Employee { Id = 1, Name = "Sara", Age = 22, Salary = 1234, DeptId = 10 };
            //Console.WriteLine(Trial.PerDept(e1));

            //Console.WriteLine(del1.Invoke(e1));
            ////del1 = default;
            //Console.WriteLine(del1?.Invoke(e1));

            ////when delegate points fn ,it acts like fn litterally
            //Console.WriteLine(del1(e1));



            ////MyDelegate del2=new MyDelegate(Trial.PrintEmployee);

            //MathDelegate del3=new MathDelegate(Trial.Add);
            //Console.WriteLine(Trial.Add(11,22));
            //Console.WriteLine(del3?.Invoke(11,22));
            //Console.WriteLine(del3(11,22));
            #endregion

            #region Delegate cont'd
            //MyDelegate del1 = new MyDelegate(Trial.PerDept);
            //MyDelegate del2=Trial.PerDept;


            #endregion

            #region Filtration V02
            //MyDelegate del1 = FilterPer.PerAge;
            //del1= FilterPer.PerName;
            //var filteredEmps = Filtration.FilterPerDelegate(emps, del1);
            //foreach (var item in filteredEmps)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region anonymous fn
            //MyDelegate del1 =   delegate(Employee item)
            //{
            //    return item.Age > 25;
            //};

            //var e1 = new Employee() { Id = 9, Name = "Osama", Age = 23, Salary = 1234, DeptId = 10 } ;
            ////Console.WriteLine(del1(e1));

            //MyDelegate del2 = delegate (Employee item) 
            //{
            //    return item.DeptId == 10;
            //};

            ////lambda expression  [anonymous fn]   => goes to
            ////   (input parameter/s) => return from fn

            //MyDelegate del3 =  (Employee item)=>
            //{
            //    return item.DeptId == 10;
            //};

            //MyDelegate del4 = (item) =>
            //{
            //    return item.DeptId == 10;
            //};

            //MathDelegate mathdel1 = (x,y) => { return x + y; };


            //MyDelegate del5 = item =>
            //{
            //    return item.DeptId == 10;
            //};

            //MyDelegate del6 = item => item.DeptId == 10;

            //MyDelegate del7 = e => e.Name.Contains("m");


            //MathDelegate mathdel2 = (left, right) => left + right;




            #endregion


            #region Filtration V3
            //MyDelegate del1 = ww => ww.Name.Contains("m");
            //var filteredEmps = Filtration.FilterPerDelegate(emps,del1);



            //filteredEmps = 
            //    Filtration.FilterPerDelegate(emps,z=>z.DeptId==10&&z.Name.Contains("m"));

            //MyDelegate del3 = ww => ww.DeptId == 20;
            //filteredEmps = Filtration.FilterPerDelegate(emps,del3);
            //filteredEmps = Filtration.FilterPerDelegate(emps, xyz => xyz.DeptId == 20);



            //foreach (var item in filteredEmps)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Generic Delegate
            ////GenericDelegate<Employee> del1 = abc => abc.DeptId == 10;
            ////GenericDelegate<int> de2 = abc => abc % 2 == 0;


            ////GenericDelegate2<int, bool> del3 = xyz => xyz % 2 == 0;


            //GenericDelegate3<int, int> del4 = (left, right) => left + right;
            //GenericDelegate3<int, bool> del5 = (left, right) => left > right;


            //FinalDelegate del5 = () => Console.WriteLine("Helllo");
            ////Console.WriteLine(del5());
            //del5();
            //del5.Invoke();

            #endregion

            #region Built-In Delegates
            #region Predicate -> takes one generic param and always returns bool
            //Predicate<int> p1 = x => x % 2 == 0;
            //Console.WriteLine(p1.Invoke(10));
            //Console.WriteLine(p1(11));
            //Predicate<Employee> p2 = ww => ww.DeptId == 10;
            //Console.WriteLine(p2.Invoke(emps.First()));

            #endregion

            #region Action ->takes from 0 up to 16 generic params and always returns void
            //Action a1 = () => Console.WriteLine("Hello");
            //Action<int, int> a2 = (x, y) => Console.WriteLine($"{x} {y}");
            //a1();
            //a2.Invoke(3, 4);
            //Action<Employee> a3 = e => Console.WriteLine(e);
            //a3.Invoke(emps.First());
            #endregion

            #region Func ->takes from 0 up to 16 generic params and return is generic also
            //Func<int> f1 = () => 22;
            //Func<int, int, bool> f2 = (w, e) => w > e;
            //Func<Employee, bool> f3 = w => w.DeptId == 20;

            //Console.WriteLine(f3(emps.LastOrDefault()));
            #endregion
            #endregion

            #region List of integers
            //List<int> nums= new List<int>();
            //for (int i = 1; i <=100; i++) 
            //{
            //    nums.Add(i);
            //}




            ////List<int> evenNums=new List<int>();
            ////foreach (var item in nums)
            ////{
            ////    if (item % 2 == 0)
            ////    {
            ////        evenNums.Add(item);
            ////    }
            ////}

            //List<int> evenNums = nums.FindAll(ww => ww % 2 == 0);


            ////foreach (var item in evenNums)
            ////{
            ////    Console.WriteLine(item);
            ////}

            //nums.RemoveAll(ww => ww % 2 == 0);

            //foreach (var item in nums)
            //{
            //    Console.WriteLine(item);
            //}




            #endregion

            #region List of employees
            ////var filteredEmps = emps.FindAll(ww => ww.DeptId == 10);
            ////foreach (var item in filteredEmps)
            ////{
            ////    Console.WriteLine(item);
            ////}


            ////List<Employee> q1 = emps.Where(ww => ww.DeptId == 10 && ww.Name.Contains("m")).ToList();

            //var q2=from item in emps
            //       where item.Age>22
            //       select item;

            #endregion

            #region Multicasting delegate  -> Action ONLY
            //Action<int> a1 = w => Console.WriteLine("Hello");
            //a1 += ww => Console.WriteLine("Good morning");
            //a1 += q => Console.WriteLine("Military is coming");
            //a1 += Trial.Fun1;
            //a1.Invoke(11);
            //Console.WriteLine("============");
            //a1 -= Trial.Fun1;
            //a1.Invoke(11);


            //Func<int, int, int> f1 = (x, y) => x + y;
            //f1 += (w, e) => w - e;
            //f1 += (w, e) => w / e;
            //f1 += (w, e) => w * e;

            //Console.WriteLine(f1.Invoke(11,22));



            #endregion

        }
    }
}
