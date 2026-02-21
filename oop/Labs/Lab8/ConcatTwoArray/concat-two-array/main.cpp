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
    friend void ViewStack(const Stack& param);
    friend Stack Concat(const Stack& param1 ,const Stack& param2);
    friend int Compare(const Stack& param1 ,const Stack& param2);

};
void ViewStack(const Stack& param)
{
    for (int  i = 0; i < param.tos; i++)
    {
        cout<<param.arr[i]<<endl;
    }
}

Stack Concat(const Stack& param1 ,const Stack& param2)
{
    int _size = param1.tos+param2.tos;
    int counter=0;
    Stack s3(_size);
    s3.tos = param1.tos + param2.tos;

    for(int i  = 0 ; i < param1.tos ; i++)
    {
        s3.arr[i]=param1.arr[i];
    }

    for (int  i = param1.tos; i <(param1.tos+param2.tos); i++)
    {
        s3.arr[i]=param2.arr[counter];
        counter++;
    }

    return s3;
}


int Compare(const Stack& param1 ,const Stack& param2)
{
    int flag = 0;

    if (param1.tos != param2.tos)
        return 0;

    Stack temp = param2;

    for (int i = 0; i < param1.tos; i++)
    {
        flag = 0;
        for (int j = 0; j < temp.tos; j++)
        {
            if (param1.arr[i] == temp.arr[j])
            {
                flag = 1;
                temp.arr[j] = -1245214;
                break;
            }
        }

        if (flag == 0)
            return 0;
    }

    return 1;
}

int main()
{
    Stack s1(5);
    s1.Push(1);
    s1.Push(2);
    s1.Push(3);
    s1.Push(4);
    s1.Push(5);

    Stack s2(5);
    s2.Push(5);
    s2.Push(4);
    s2.Push(2);
    s2.Push(1);
    s2.Push(1);
/*

    cout<<"First Array:\n";
    ViewStack(s1);
    cout<<"Second Array:\n";
    ViewStack(s2);

    Stack s3=Concat(s1,s2);
    cout<<"Concated Array:\n";
    ViewStack(s3);
*/


    int result = Compare(s1,s2);
    cout<<endl;
    if(result==1)
        cout<<"S1 = S2";
    else
        cout<<"S1 != S2";
    cout<<endl;
}
