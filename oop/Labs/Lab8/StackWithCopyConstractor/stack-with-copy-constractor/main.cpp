#include <iostream>

using namespace std;

class Stack
{
    private:
    int* arr;
    int size;
    int tos;
    public:
    Stack()
    {
        tos=0;
        size=5;
        arr=new int[size];
        cout<<"Stack def ctor\n";
    }
    Stack(int _size)
    {
        tos=0;
        size=_size;
        arr=new int[size];
        cout<<"Stack 1p ctor\n";
    }


    ~Stack()
    {

        for (int i = 0; i < size; i++)
        {
            arr[i]=-1;
        }
        delete[] arr;
        cout<<"Stack dest\n";
    }

    Stack(const Stack& oldObject)
    {

        tos=oldObject.tos;
        this->size=oldObject.size;
        this->arr=new int[size];
        for (int i = 0; i < tos; i++)
        {
            this->arr[i]=oldObject.arr[i];
        }
        cout<<"cpy ctor\n";
    }

    void Push(int value)
    {
        if(!IsFull())
        {
            arr[tos]=value;
            tos++;
        }
        else
        {
            cout<<"FULL!!!\n";
        }
    }
    int Pop()
    {
        int result=-123;
        if(!this->IsEmpty())
        {
            tos--;
            result=arr[tos];
        }
        else
        {
            cout<<"EMPTY!!!\n";
        }
        return result;
    }

    int IsFull(){return tos==size;}
    int IsEmpty(){return tos==0;}
    friend void ViewStack(Stack param);



    Stack Reverse()
    {
        Stack result;
        result.tos = tos;

        for(int i = 0 ; i<tos ; i++)
        {
           result.arr[tos-1-i] = arr[i];

        }
        return result;
    }


    //s2=s1
    Stack& operator=(const Stack& right)
    {
        delete[] arr;
        tos=right.tos;
        size=right.size;
        arr=new int[size];
        for (int i = 0; i < tos; i++)
        {
            arr[i]=right.arr[i];
        }
        return *this;
    }
    //
};
void ViewStack(Stack param)
{
    for (int  i = 0; i < param.tos; i++)
    {
        cout<<param.arr[i]<<endl;
    }
}

int main()
{
    Stack s1(10);
    s1.Push(10);
    s1.Push(20);
    s1.Push(30);
    s1.Push(40);
    s1.Push(50);


    Stack s2=s1.Reverse();
    ViewStack(s1);
    ViewStack(s2);
}
