#include <iostream>

using namespace std;

class Stack
{
    private:
    int *arr;
    int size;
    int tos;
    static int counter;
    public:
     Stack()
     {
        counter++;
        size=10;
        tos=0;
        arr=new int[size];
        cout<<"ctor called";
     }
     Stack(int _size)
     {
        counter++;
        size=_size;
        tos=0;
        arr=new int[_size];
        cout<<"ctor called";
     }

     ~Stack()
     {
         counter--;
         delete []arr;
         cout<<"dest called";

     }


     void Push(int number)
     {

        if(!IsFull())
        {
             arr[tos]=number;
             tos++;
        }
        else
        {

          cout<<"Array Is Full !!! \n" ;

        }


     }

     int Pop()
     {

         if(!IsEmpty())
         {
             tos--;
             return arr[tos];
         }
         else
         {
            cout<<"Array Is Empty \n" ;
            return -15452514;
         }

     }

     int IsFull()
     {
            return (tos==size) ;

     }


     int IsEmpty()
     {
            return (tos==0) ;

     }

     friend void ViewStack(Stack param);

};

void ViewStack(Stack param)
{
cout<<endl;
    for(int i  =0 ; i<param.tos ; i++)
    {
        cout<<param.arr[i]<<endl;
    }

}

int Stack::counter=0;
int main()
{
   Stack s1 ;
   s1.Push(5);
   s1.Push(6);
   s1.Push(7);
   s1.Push(8);
   s1.Push(9);
   s1.Push(10);
   ViewStack(s1);
   ViewStack(s1);
    return 0;
}
