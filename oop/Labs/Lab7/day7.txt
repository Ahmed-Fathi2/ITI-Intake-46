//constructor
//destructor
//Stack
//static
//Friend function
//OOR Concept
///////////////////////////////////////////////
class Complex
{
    private:
    int real;
    int img;
    public:
    void SetReal(int _real)
    {
        real=_real;
    }
    int GetReal() const 
    {
        return real;
    }
    void SetImg(int _img)
    {
        img=_img;
    }
    int GetImg() const
    {
        return img;
    }
    void Print()
    {
        cout<<this->real <<"+"<<img <<"i"<<endl;
    }
    Complex Add(Complex right) 
    {
        Complex result;
        result.real= (*this).real +right.real;
        result.img=img+right.img;
        return result;
    }
    //
    //fn to initialize object
    void Initialize()
    {
        real=3;
        this->img=4;
    }
    void Initialize(int _real,int _img)
    {
        real=_real;
        this->img=_img;
    }
    void Initialize(int _num)
    {
        real=img=_num;
    }
    //
    //--> constructor  called by each object created
    
    
    //
};
//standalone fn to add 2 complex #'s
Complex AddComplex(Complex left,Complex right)
{
    Complex result;
    int r=left.GetReal()+right.GetReal();
    int i=left.GetImg()+right.GetImg();
    result.SetReal(r);
    result.SetImg(i);
    return result;
}
//
//v1
int main()
{
    Complex c1,c2,c3;
    c1.SetReal(3);
    c1.SetImg(4);
    c2.SetReal(3);
    c2.SetImg(4);
    c3.SetReal(3);
    c3.SetImg(4);
}

//v2
int main()
{
    Complex c1,c2,c3;
    c1.Initialize();
    c2.Initialize(5,6);
    c3.Initialize(7);
}

int main()
{
    Complex c1,c2,c3;
}
/////////////////////////////////////////////
//Constructor:
// special method inside class/struct 
// implicitly exist [hidden]
// will be called automatically -we cannot call it-
// Once we create object from that class/struct

//how to write ctor explicitly?
//1-has same name of class
//2-has no return type nor void
//3-can be overloaded
//4-must be public ->private   [design patterns]

class Trial
{
    int x;
    public:
    Trial(){}
    Trial(int _x){}
};

/////////////////////////////////////////////
class Complex
{
    private:
    int real;
    int img;
    public:
    void SetReal(int _real)
    {
        real=_real;
    }
    int GetReal() const 
    {
        return real;
    }
    void SetImg(int _img)
    {
        img=_img;
    }
    int GetImg() const
    {
        return img;
    }
    void Print()
    {
        cout<<this->real <<"+"<<img <<"i"<<endl;
    }
    Complex Add(Complex right) 
    {
        Complex result;
        result.real= (*this).real +right.real;
        result.img=img+right.img;
        return result;
    }
    //--> constructor  called by each object created
    

    // //default ctor generated
    // by o.s IF there is no such ctor exists
    Complex()
    {
        this->real=0;
        img=0;
        cout<<"complex ctor called\n";
    }
    Complex(int _real,int _img)
    {
        this->real=_real;
        img=_img;
        cout<<"complex ctor called\n";
    }
    Complex(int _num)
    {
        this->real=img=_num;
        cout<<"complex ctor called\n";
    }
    //

    //destructor [for learning purpose]
    ~Complex()
    {
        cout<<"dest called\n";
    }
    //
};

int main()
{
    Complex c1,c2(3,4),c3(5);
    //All real|0| img|0|

    //o/p
    //ctor called
    //ctor called
    //ctor called
    //dest called
    //dest called
    //dest called
    return 0;
}

//Destructor:
//Special function inside class/struct will be 
//called automatically
//cannot be called
//implicitly exist
//once O.S will object destructed from Stack
//once object reach end of its scope

///how to write destructor explicitly?
///1-has same name f class starts with ~ tilda 
///2- has no return type nor void
///3- cannot be overloaded -only parameterless copy-
///4- MUST be public

//what is real use of destructor?
//1-dynamic allocation
//2-connect to DB
//3-read/write from file


class Trial
{
    int x;
    public:
    Trial(){}
    Trial(int _x){}

    ~Trial(){}

};


//////////////////////////////

class Draft
{
    private:
    int *ptr;
    public:
    Draft()
    {
        ptr=new int[10];
    }
    ~Draft()
    {
        delete [] ptr;
    }
};

void TryMe()
{
    Draft o1;
}
int main()
{
    TryMe();
    TryMe();
    TryMe();
}

/////////////////////////////////////////////
class Stack
{
    private:
    int arr[5];
    int tos;
    public:
    Stack()
    {
        tos=0;
    }
    ~Stack() //useless [learninig]
    {
        cout<<"dest called";
    }

    //Stack Functions
    void Push(int value)
    {
        if (tos!=5)
        {
            arr[tos]=value;
            tos++;
        }
        else
        {
            cout<<"FULL !!!\n";
        }   
    }

    int Pop()
    {
        int result=-1234;
        if (tos!=0)
        {
            tos--;
            result=arr[tos];
            //return result;
        }
        else
        {
            cout<<"EMPTY!!!\n";
            //return -1234;
            //throw runtime error
        }  
        return result;
    }
    //
};
int main()
{
    Stack s1;   //MEMORY  s1 tos|5| arr|10|20|30|40|50|
    s1.Push(10);
    s1.Push(20);
    s1.Push(30);
    s1.Push(40);
    s1.Push(50);

    s1.Push(60);
    s1.Push(70);

    cout<<s1.Pop(); //50
    cout<<s1.Pop();
    cout<<s1.Pop();
    cout<<s1.Pop();
    cout<<s1.Pop();

    cout<<s1.Pop();//EMPTY -1234
    cout<<s1.Pop();
}

////////////////////////////////////////////
//#include<iostream>
using namespace std;
class Stack
{
    private:
    int *arr;
    int tos;
    int size;
    public:
    Stack()
    {
        tos=0;
        size=5;
        arr=new int[size];
        cout<<"ctor called";
    }
    Stack(int _size)
    {
        tos=0;
        size=_size;
        arr=new int[size];
        cout<<"ctor called";
    }
    ~Stack() //IMPORTANT
    {
        //useless
        for (int i = 0; i < size; i++)
        {
            arr[i]=-1;
        }
        //
        delete[] arr;
        cout<<"dest called";
    }

    //Stack Functions
    void Push(/*this->s2*/int value)
    {
        //if (tos!=size)
        if (!this->IsFull())
        {
            arr[tos]=value;
            tos++;
        }
        else
        {
            cout<<"FULL !!!\n";
        }   
    }

    int Pop()
    {
        int result=-1234;
        //if (tos!=0)
        if (!IsEmpty())
        {
            tos--;
            result=arr[tos];
            //return result;
        }
        else
        {
            cout<<"EMPTY!!!\n";
            //return -1234;
            //throw runtime error
        }  
        return result;
    }

    int IsFull(){return tos==size;}
    int IsEmpty(){return tos==0;}
    //
    //
    friend void ViewStack(Stack param);
    //
};
//Standalone fn to view Stack content
void ViewStack(Stack param)
{
    for (int i = 0; i < param.tos;  i++)
    {
        cout<<param.arr[i]<<",";
    } 
}

//is there any way to access private members of stack in 
//this fn ? YES  it it became friend function

//Friend Fn:
//standalone fn but can 
//access private members of 
//class it is friend at

//
int main()
{
    Stack s1(7),s2(10);
    
    cout<<s1.IsFull(); //0
    cout<<s1.IsEmpty(); //1
    
    //>
    s2.Push(1);
    s2.Push(2);
    s2.Push(3);
    s2.Push(4);
    s2.Push(5);
    s2.Push(6);
    s2.Push(7);
    ViewStack(s2);   //1,2,3,4,5,6,7
}
//////////////////////////////////////////////
class Stack
{
    private:
    int *arr;
    int tos;
    int size;
    //this line of code is executed once per app calling
    static int counter;//=0 //suppost it carries ZERO
    public:
    //getter for counter
    static int GetCounter() 
    {
        return counter;
    }
    //
    Stack()
    {
        //
        counter++;
        //
        tos=0;
        size=5;
        arr=new int[size];
        cout<<"ctor called";
    }
    Stack(int _size)
    {
        //
        counter++;
        //
        tos=0;
        size=_size;
        arr=new int[size];
        cout<<"ctor called";
    }
    ~Stack() //IMPORTANT
    {
        //
        counter--;
        //
        //useless
        for (int i = 0; i < size; i++)
        {
            arr[i]=-1;
        }
        //
        delete[] arr;
        cout<<"dest called";
    }

    //Stack Functions
    void Push(/*this->s2*/int value)
    {
        //if (tos!=size)
        if (!this->IsFull())
        {
            arr[tos]=value;
            tos++;
        }
        else
        {
            cout<<"FULL !!!\n";
        }   
    }

    int Pop()
    {
        int result=-1234;
        //if (tos!=0)
        if (!IsEmpty())
        {
            tos--;
            result=arr[tos];
            //return result;
        }
        else
        {
            cout<<"EMPTY!!!\n";
            //return -1234;
            //throw runtime error
        }  
        return result;
    }

    int IsFull(){return tos==size;}
    int IsEmpty(){return tos==0;}
    //
    //
    friend void ViewStack(Stack param);
    //
};
//Standalone fn to view Stack content
void ViewStack(Stack param)
{
    for (int i = 0; i < param.tos;  i++)
    {
        cout<<param.arr[i]<<",";
    } 
}

//initialization for any class variable even if it is private
int Stack::counter=0;
//
int main()
{
    Stack s1,s2(10),s3;
    
    //before private
    //cout<<s1.counter; //3 //non sense  //c++ ,java
    //cout<< Stack::counter; //3
    //Stack::counter=44;
    //cout<< Stack::counter; //44


    cout<<s1.GetCounter(); //3 //non sense
    cout<<Stack::GetCounter(); //3


}


///Number of live object im memory
///static variable / class variable / shared variable:
///>member variable with keyword static
///>static variable is valriable that o.s 
///will create only one copy of it in Memory[BSS]
///regadless # of objects created from this class
///>life time of class variable till program ends
///>static variable is acceseed by class Name not object name

////////////////////////////////////////////////
//Object Oriented Relations
//Relation between classes

//1-Composition [Tightly Coupled]
    //DT Contains All Of Another DT

//2-Aggregation [loosely coupled]
    //class may contains another class later

//3-Association [Very Loosely coupled]
    //peer to peer each class may not depend on
        //another one 

//4- inheritance
////////////////////////////////////////////////////
//A-Association [Very Loosely coupled]
///1- Peer-To-Peer
        //teacher    subject
///2- Temporarily relation
///3- represent in code
        //Pointer of class inside another class
        //C# Reference
        ///class Teacher
        //{
            //id,name,age
            //Subject * sub; //null
        //};
//4- 1-0 1-1  1-M M-M 
//5- No Dependency


//B-Aggregation [loosely coupled]
///1- Whole vs. part
///      Student       Department
///2- temp. Relation
///3- Represent in code
    /// Pointer of class inside another class
        //C# Reference
        ///class Student
        //{
            //id,name,age
            //Department * Dept;
            //ctor(){new dept[1]}
        //};
///4-1-0 1-1   1-M M-M
///5- No Dependency


//C- Composition [Tightly Coupled]
///1- complete ownership [has a]
///2- Permenant relationship
        //Room    wall
///3- object of class inside another class
        ///class Room
        //{
            //Wall  w1;
            //Wall  w2;
            //Wall  w3;
            //Wall  w4;
            
        //};
        ///main  room r[10] ||||||||
        //room r1,r2,r3
///4- 1-1 1-m 
///5- Complete Dependency



///////////////////////////////////////////

//-fno-elide-constructors   
//settings -> compiler -> other compiler options tab
//RVO
///////////////////////////////////////////////
//OBSERVE
//1-class Complex 
//+  ctor()cout,ctor(,)cout,ctor(int)cout ,dest()cout
///in main
////Complex c1,c2,c3
////pass values
////c3=AddComplex(c1,c2); //pass by value
//o/p
//with observe -> NO static variable  with ur eyes
//ctor
//cotr
//des
//des
//des
//# of ctor != # of dest
//Why -> tomorrow


//OBSERVE with ur eyes
//2-class Stack
///int*arr,int size,int tos ,static counter
///ctor() cout
///ctor(size) cout
///dest()  for loop -1 then delete [] arr then cout
///push,pop ,isfull,isempty


///ViewStack(Stack param)
//as standalone and friend fn

//in main write exactly
//Stack s1(10);
//push 4 or 6 times

//ViewStack(s1); //runs successfully
//ViewStack(s1); //fail 
//Why? tomorrow isa

//try to print counter


//3-implement shift  queue
//4-implement  circular queue












