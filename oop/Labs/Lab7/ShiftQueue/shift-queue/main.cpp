#include <iostream>

using namespace std;

class Queue
{
    private:
    int *arr;
    int size;
    int toq;
    int first;
    static int counter;
    public:
     Queue()
     {
        counter++;
        size=10;
        toq=0;
        first=0;
        arr=new int[size];
        cout<<"ctor called";
     }
     Queue(int _size)
     {
        counter++;
        size=_size;
        toq=0;
        first=0;
        arr=new int[_size];
        cout<<"ctor called";
     }

     ~Queue()
     {
         counter--;
         delete []arr;
         cout<<"dest called";

     }


     void InQueue(int number)
     {

        if(!IsFull())
        {
             arr[toq]=number;
             toq++;
        }
        else
        {

          cout<<"Array Is Full !!! \n" ;

        }

     }

     int DeQueue()
     {
         int result ;

         if(!IsEmpty())
         {
             result=arr[first];
             for(int i = 0 ; i < size ; i++)
             {
                 arr[i]=arr[i+1];
             }
             toq--;
            return result;
         }
         else
         {
            cout<<"Array Is Empty \n" ;
            return -15452514;
         }

     }

     int IsFull()
     {
            return (toq==size) ;

     }


     int IsEmpty()
     {
            return (toq==0) ;

     }

     friend void ViewQueue(Queue param);

};

void ViewQueue(Queue param)
{
cout<<endl;
    for(int i  =0 ; i<param.toq ; i++)
    {
        cout<<param.arr[i]<<endl;
    }

}

int Queue::counter=0;
int main()
{
     Queue q1;
     q1.InQueue(10);
     q1.InQueue(20);
     q1.InQueue(30);
     q1.InQueue(40);

     ViewQueue(q1);
     cout<<endl;
     q1.DeQueue();
     q1.InQueue(50);
     ViewQueue(q1);

    return 0;
}
