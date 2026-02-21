namespace SD46CSD05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region MCU Create object from Employee via property initializer
            //var e1 = new Employee { Id = 1, Name = "Sara", Age = 22 };
            #endregion

            #region Enum V1
            //////enum can carry single value
            //DayName d1 = DayName.Fri;
            ////Console.WriteLine(d1);
            ////d1 += DayName.Sat;

            //d1 = DayName.Wed | DayName.Thu;

            //Console.WriteLine(d1);

            #endregion

            #region Enum V2
            //////Enum variable can carry multiple values with some steps;
            //////make attribute [Flags] over enum DT Make enum acts as a Binary VALUES
            //////[Flags]  make choose more than one value from enum
            /////

            ////Position p1;

            ////p1 = Position.Developer | Position.Tester|Position.SWArchitect|Position.DBA|Position.Secretary;
            ////Console.WriteLine(p1);


            //Position p2 = Position.Developer ^ Position.Tester;
            //Console.WriteLine(p2);
            //p2 ^= Position.Tester;
            //Console.WriteLine(p2);



            #endregion

            #region Static
            ////Static variable,shared V ,class V
            ///variable clr will make only one copy of it in memory
            ////static variable is stored in HEAP
            ////static variable is alive till program ends
            ////static is called by class name
            //Complex c1 = new();
            //Complex c2 = new(3,4);
            ////Console.WriteLine(Complex.counter);
            ////Complex.counter = 22;
            ////Console.WriteLine(Complex.counter);
            //Console.WriteLine(Complex.Counter);


            //Static ctor:ctor to initialize static members 

            //static class: class every members iside are static
            #endregion
            #region Indexer

            #endregion

            #region Operator overloading
            /////operators can be overloaded in  c#
            /////operator overloading must be public and static inside class
            /////casting operator must defined as implicit or explicit
            /////+,-,*./ can be overloaded
            /////>,>=,<,<=,==,!= can be overloaded
            /////casting operator can be overloaded
            /////++ can be
            ///// = CANNOT be overloaded
            ///// compound operator CANNOT
            ///// &&,|| operator CANNOT

            ////int x = 3, y = 4, z;
            ////z = x + y;


            //Complex c1 = new Complex { Real = 3, Img = 4 };
            //Complex c2 = new Complex { Real = 5, Img = 6 };
            //Complex c3 = new Complex { Real = 3, Img = 4 };

            ////c3 = c1 + c2;


            ////c3 = c1 + 10;
            ////c3 = 10 + c1;


            //////c3 = c1++;
            ////c3 = ++c1;


            ////int real = c1;
            ////string str = c1;

            ////Console.WriteLine((int)c1);
            ////Console.WriteLine((string)c3);

            //if (c1>c2)
            //{

            //}


            #endregion

            #region Create Single Object from class [SingleTon]
            //Gdriver g1=new Gdriver();
            //Gdriver g2=new Gdriver();
            //Gdriver g3=new Gdriver();
            //Console.WriteLine(g1.GetHashCode());
            //Console.WriteLine(g2.GetHashCode());
            //Console.WriteLine(g3.GetHashCode());


            //Gdriver g1 = Gdriver.CreateOneObject();
            //Gdriver g2 = Gdriver.CreateOneObject();
            //Gdriver g3 = Gdriver.CreateOneObject();
            //Console.WriteLine(g1.GetHashCode());
            //Console.WriteLine(g2.GetHashCode());
            //Console.WriteLine(g3.GetHashCode());

            #endregion

            ///////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            //Object Oriented Relations
            //Relation between classes

            //1-Composition [Tightly Coupled]
            //class Contains All Of Another class

            //2-Aggregation [loosely coupled]
            //class may contains another class later

            //3-Association [Very Loosely coupled]
            //peer to peer each class may not depend on
            //another one 

            //4- inheritance

            //A-Association [Very Loosely coupled]
            ///1- Peer-To-Peer
            //teacher    subject
            ///2- Temporarily relation
            ///3- represent in code
            //Pointer of class inside another class
            //C# Reference
            ///cass Teacher
            //{
            //id,name,age
            //Subject * sub;
            //};
            //4- 1-1  1-M M-M 
            //5- No Dependency


            //B-Aggregation [loosely coupled]
            ///1- Whole vs. part
            ///      Student       Department
            ///2- temp. Relation
            ///3- Resresent in code
            /// Pointer of class inside another class
            //C# Reference
            ///cass Student
            //{
            //id,name,age
            //Department * Dept;
            //ctor(){new dept[10]}
            //};
            ///4- 1-1   1-M M-M
            ///5- No Dependency


            //C- Composition [Tightly Coupled]
            ///1- complete ownership
            ///2- Permenant relationship
            //Room    wall
            ///3- object of class inside another class
            ///class Room
            //{
            //Wall  w1=new Wall();
            //Wall  w2=new Wall();
            //Wall  w3=new Wall();
            //Wall  w4=new Wall();

            //};
            ///main  room r[10] ||||||||
            //room r1,r2,r3
            ///4- 1-1 1-m 
            ///5- Complete Dependency


        }
    }
}
