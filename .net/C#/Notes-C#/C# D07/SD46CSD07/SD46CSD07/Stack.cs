using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD07
{
    //generic constraints
    //1- primary constraint class,struct
    ///    0->1
    ///    special primary constraint  [inheritance]
    //2-secondry constraint [interface]
    //     0 -> *
    //3-parameterless ctor    new()
    public class MyStack<T> where T:new()
    {
        T[] arr;
        int tos;
        int size;
        public MyStack()
        {
            size = 5;
            tos = 0;
            arr = new T[size];
        }
        public MyStack(int _size)
        {
            size = _size;
            tos = 0;
            arr = new T[size];
        }
        
        public void Push(T value)
        {
            if (!IsFull())
            {
                arr[tos] = value;
                tos++;
            }
            else
            {
                Console.WriteLine("FULL");
            }
        }

        public T Pop()
        {
            T result=default; //-1
            if (!IsEmpty())
            {
                tos--;
                result = arr[tos];
                return result;
            }
            else
            {
                throw new Exception();
            }
        }




        public bool IsFull() {  return tos==size; }
        public bool IsEmpty() {  return tos==0; }
    }
}
