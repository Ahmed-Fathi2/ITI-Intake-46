using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD06
{
    interface IMyInterface
    {
        int Id { set; get; }
        int Add(int left, int right);
        int Sub(int left, int right);
        void SignIn();
    }

    interface IMyInterface2
    {
        string Name { set; get; }
        int Mul(int left, int right);
        void SignIn();

    }


    class MyService : IMyInterface, IMyInterface2
    {
        public int Id
        {
            set;get;
        }

        public string Name
        {
            set;get;
        }

        public int Add(int left, int right)
        {
            return left + right;
        }

        public int Mul(int left, int right)
        {
            return left * right;
        }

        //public void SignIn()
        //{
        //    Console.WriteLine("HELLOOOOOOOOOOOOOOOOOO");
        //}

        public int Sub(int left, int right)
        {
            return left - right;
        }

        /////Implementation must be explicit 
        ///IMyInterface    SignIn
        void IMyInterface.SignIn()
        {
            Console.WriteLine("Hrllo from imi 1");
        }


        ///IMyInterface2    SignIn
        void IMyInterface2.SignIn()
        {
            Console.WriteLine("Hrllo from imi 2");
        }


    }

}
