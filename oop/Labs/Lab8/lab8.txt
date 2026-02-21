///CPY ctor
///operator overloading
///OOR V1.0
//////////////////////////////////////////

//#include<iostream>
using namespace std;
class Complex
{
    private:
    int real;
    int img;
    public:
    void SetReal(int _real)
    {
        this->real=_real;
    }
    int GetReal() const 
    {
        return this->real;
    }
    void SetImg(int _img)
    {
        img=_img;
    }
    int GetImg() const
    {
        return (*this).img;
    }
    void Print()
    {
        cout<<real<<"+"<<this->img<<"i"<<endl;
    }
    Complex Add(Complex right)
    {
        Complex result;
        result.real=this->real+right.real;
        result.img=img+right.img;
        return result;
    }
    Complex()
    {
        cout<<"complec default ctor";
        this->real=0;
        (*this).img=0;
    }
    Complex(int _real,int _img)
    {
        cout<<"complec 2p ctor";
        this->real=_real;
        img=_img;
    }
    Complex(int _num)
    {
        cout<<"complec 1p ctor";
        this->real=img=_num;
    }
    //destructor learning purpose //useless
    ~Complex()
    {
        cout<<"complex destructor\n";
    }
    //

    //cpy ctor [useless]
    Complex(const Complex& old)
    {
        real=old.real;
        img=old.img;
    }
    //
};
Complex AddComplex(Complex left,Complex right)
{
    Complex result;
    int r=left.GetReal()+right.GetReal();
    int i=left.GetImg()+right.GetImg();
    result.SetReal(r);
    result.SetImg(i);
    return result;
}


int main()
{
    Complex c1(3,4),c2(5,6),c3;
    c3=AddComplex(c1,c2);
    c3.Print();
    return 0;
}
////////////////////////////////////////
//#include<iostream>
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
        cout<<"Stack def ctor";
    }
    Stack(int _size)
    {
        tos=0;
        size=_size;
        arr=new int[size];
        cout<<"Stack 1p ctor";
    }

    //dest  important?YESSSSSSSS Very
    ~Stack()
    {
        //useless
        for (int i = 0; i < size; i++)
        {
            arr[i]=-1;
        } 
        delete[] arr;
        cout<<"Stack dest";
    }

    ///cpy ctor
    ///
    //Stack functions
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
    //
    int IsFull(){return tos==size;}
    int IsEmpty(){return tos==0;}
    //
    //
    friend void ViewStack(Stack param);
    //

    //
    Stack Reverse()
    {
        Stack result;
        //go upward into result
        return result; //return VALUESSSSS
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

    ViewStack(s1);
    ViewStack(s1);
}

///////////////////////////////////////

//copy constructor:  [if not -> bitwise copy]
//method  called automatically
//when create object from this calss
//in 3 cases:
//1-when pass object by value
//2-when return object by value
//3-when create object by another object


class Trial
{
    int x;
    public:
    Trial(){}
    //this pointer to new object    param
    //oldObject reference to old object
    Trial(Trial& oldObject)
    {
        ///
    }
};
void TryMe(Trial param)
{

}

int main()
{
    Trial obj;
    TryMe(obj); //pass object by value


    Trial Obj2(obj);
}

////////////////////////////////////////
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
        cout<<"Stack def ctor";
    }
    Stack(int _size)
    {
        tos=0;
        size=_size;
        arr=new int[size];
        cout<<"Stack 1p ctor";
    }

    //dest  important?YESSSSSSSS Very
    ~Stack()
    {
        //useless
        for (int i = 0; i < size; i++)
        {
            arr[i]=-1;
        } 
        delete[] arr;
        cout<<"Stack dest";
    }

    ///cpy ctor
    //this-> pointer to param
    //oldObject-> Reference to s1
    Stack(const Stack& oldObject)
    {
        // //tatataaaaa
        // oldObject.tos=-123;
        // //
        tos=oldObject.tos;
        this->size=oldObject.size;
        this->arr=new int[size];
        for (int i = 0; i < tos; i++)
        {
            this->arr[i]=oldObject.arr[i];
        }
        cout<<"cpy ctor";
    }
    ///
    
    //Stack functions
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
    //
    int IsFull(){return tos==size;}
    int IsEmpty(){return tos==0;}
    //
    //
    friend void ViewStack(Stack param);
    //

    //
    Stack Reverse()
    {
        Stack result;
        //go upward into result
        return result; //return VALUESSSSS
    }
    //

    //s2=s1  [MUST]
    Stack& operator=(const Stack& right)
    {
        delete[] arr; //avoid memory leakage
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


    //Stack s2=s1.Reverse();
    ViewStack(s1);
    ViewStack(s1);
}


//when cpy ctor IS MUST?????
///>when u have pointer will be dynamically allocated
///>when class has field carries addresss


///////////////////////////////////////////////


int main()
{

    int x=3,y=4,z;
    double a=3,b=4,c;

    z=x+y;
    c=a+b;
    //compiler
    //int operator+(int left,int right){}
    //double operator+(double left,double right){}
    //Complex operator+(Complex left,Complex right){}


    Complex c1(3,4),c2(5,6),c3;
    c3=AddComplex(c1,c2);
    c3=c1+c2;

    return 0;
}


///>operators can be overloaded
///>operators can be overloaded 
//as member or standalone fn

class Complex
{
    private:
    int real;
    int img;
    public:
    void SetReal(int _real)
    {
        this->real=_real;
    }
    int GetReal() const 
    {
        return this->real;
    }
    void SetImg(int _img)
    {
        img=_img;
    }
    int GetImg() const
    {
        return (*this).img;
    }
    void Print()
    {
        cout<<real<<"+"<<this->img<<"i"<<endl;
    }
    Complex Add(Complex right)
    {
        Complex result;
        result.real=this->real+right.real;
        result.img=img+right.img;
        return result;
    }
    Complex()
    {
        cout<<"complec default ctor";
        this->real=0;
        (*this).img=0;
    }
    Complex(int _real,int _img)
    {
        cout<<"complec 2p ctor";
        this->real=_real;
        img=_img;
    }
    Complex(int _num)
    {
        cout<<"complec 1p ctor";
        this->real=img=_num;
    }
    //destructor learning purpose //useless
    ~Complex()
    {
        cout<<"complex destructor\n";
    }
    //

    //cpy ctor [useless]
    Complex(const Complex& old)
    {
        real=old.real;
        img=old.img;
    }
    //
    //
    //c1+c2
    Complex operator+(const Complex& right)
    {
        Complex result;
        result.real=real+right.real;
        result.img=img+right.img;
        return result; //return by value

        return Complex(real+right.real,img+right.img);
    }
    //
    //c1+10
    Complex operator+(int _num)
    {
        Complex result(this->real+_num,this->img);
        return result;
    }

    //
    //++c1
    Complex operator++()
    {
        this->real++;
        img++;
        return *this;   
    }

    //c3=c1++
    Complex operator++(int)
    {
        Complex result(real,img);
        //Complex result(*this);
        this->real++;
        this->img++;
        return result;
    }
    //

    //c1+=c2+=c3
    Complex operator+=(const Complex& right)
    {
        real+=right.real;
        img+=right.img;
        return *this;
    }
    //
    //c1>c2
    int operator>(const Complex& right)
    {
        return real>right.real&& img>right.img;
    }
    //

    //c3=c1=c2    [USELESSSSSSSS]
    Complex& operator=(const Complex& right)
    {
        real=right.real;
        img=right.img;
        return *this;
    }
    //
};

//c1+c2
//Complex operator+(Complex left,Complex right){}
//
//10+c1
Complex operator+(int _num,Complex right)
{
    return right+ _num;
    Complex result;
    result.SetReal(_num+right.GetReal());
    result.SetImg(right.GetImg());
    return result;
}
//

Complex AddComplex(Complex left,Complex right)
{
    Complex result;
    int r=left.GetReal()+right.GetReal();
    int i=left.GetImg()+right.GetImg();
    result.SetReal(r);
    result.SetImg(i);
    return result;
}

int main()
{
    Complex c1(3,4),c2(5,6),c3;
    //c3=c1+c2;  //standalone=>operator+(c1,c2)
    
    
    c3=c1  +  c2;  //Compiler member=>c1.operator+(c2)

    c3=c1+10;
    c1.Print(); //3+4i
    c3.Print(); //13+4i


    c3=++c1;  //c1.operator++()
    c3.Print(); //4+5i
    c1.Print(); //4+5i

    
    
    c3=c1++;  //c1.operator++()
    c3.Print(); //3+4i
    c1.Print(); //4+5i

    c3=10+c1;  //10.operator+(c1)  must be standalone


    c1+=c2;  //c1.operator+=(c2)
    c1.Print(); //8+10i
    c2.Print(); //5+6i


    if(c1>c2)
    {
        cout<<"B";
    }

    //casting
    int real=c1;
    cout<<real; //3


    c3=c1;  //assign values

}

////////////////////////////////////////////////
int main()
{
    Stack s1(10);
    Stack s2;

    s1.Push(10);
    s1.Push(20);
    s1.Push(30);
    s1.Push(40);
    s1.Push(50);
    s1.Push(60);
    s1.Push(70);


    s2=s1; //assign values   //call = operator
}

///////////////////////////////////////////////
///Composition
//#include"graphics.h"
//#include<iostream>
class Point
{
    private:
    int x;
    int y;
    public:
    void SetX(int _x){x=_x;}
    int GetX(){return x;}
    void SetY(int _y){y=_y;}
    int GetY(){return y;}
    //l1 call this ctor to construct start
    //l1 call this ctor to construct end
    Point()
    {
        x=y=0;
        cout<<"point def ctor";
    }
    Point(int _x,int _y)
    {
        x=_x;y=_y;
        cout<<"point 2p ctor";
    }
    //useless
    ~Point(){cout<<"point dest";}
    //useless
    Point(const Point& old)
    {
        x=old.x;
        y=old.y;
        cout<<"point cctor";
    }
};

class MyLine
{
    private:
    Point start;
    Point end;
    int myColor;
    public:
    void SetStart(Point _start)
    {
        start=_start;
    }
    Point GetStart()
    {
        return start;
    }
    void SetEnd(Point _end)
    {
        end=_end;
    }
    Point GetEnd()
    {
        return end;
    }
    void SetMyColor(int _mycolor){myColor=_mycolor;}
    int GetMyColor(){return myColor;}
    MyLine()
    {
        //-> l1 start x|0| y|0|  end x|0| y|0|  
        //start.x=0;start.y=0;end.x=0;end.y=0; //inaccessible
        
        //useless
        // start.SetX(0);
        // start.SetY(0);
        // end.SetX(0);
        // end.SetY(0);
        
        myColor=0;
        cout<<"Line def ctor";
    }

    MyLine(int x1,int y1,int x2,int y2,int _color)
    {
        //-> l2 start x|0| y|0| end x|0| y|0|
        start.SetX(x1);
        start.SetY(y1);
        end.SetX(x2);
        end.SetY(y2);
        myColor=_color;
        //->
        cout<<"Line 5p ctor";
    }
    ~MyLine(){}
    MyLine(const MyLine& old)
    {
        start=old.start;
        end=old.end;
        myColor=old.myColor;
    }
    void Draw()
    {
        //built-in fn
        setcolor(myColor);
        line(start.GetX(),start.GetY(),end.GetX(),end.GetY()); 
    }

};

//constructor chaining 1- increase performance   2- reduce written code
class Rect
{
    private:
    Point ul;
    Point lr;
    int myColor;
    public:
    //setters & getters
    Rect()
    {
        //r1  ul  x0 y0   lr x0 y0
        myColor=0;
        cout<<"Rect def ctor";
    }
    Rect(int x1,int y1,int x2,int y2,int _color)
    :ul(x1,y1),lr(x2,y2)
    {
        //-> r2 ul x1 y2  lr x3 y4
        myColor=_color;
        //after ctor chaining -> useless
        // ul.SetX(x1);
        // ul.SetY(y1);
        // lr.SetX(x2);
        // lr.SetY(y2);
        cout<<"Rect 5p ctor";
    }
    ~Rect(){}
    Rect(Rect& old){}
    void Draw()
    {
        setcolor(myColor);
        rectangle(ul.GetX(),ul.GetY(),lr.GetX(),lr.GetY());
    }
};

class MyCircle
{
    int radius;
    Point center;
    int myColor;
    public:
    //
    //
    //
    //
    //
    void Draw()
    {
        //setcolor();
        //circle(,,);
    }
};

class MyTri
{
    Point p1;
    Point p2;
    Point p3;
    int myColor;
    public:
    //
    //
    //
    //
    //
    void Draw()
    {
        setcolor(myColor);
        line();
        line();
        line();
    }
};

int main()
{
    initgraph();
    Rect r2(1,2,3,4,5);
    r2.Draw();
    
    Rect r1;

    MyLine l2(1,2,3,4,5);
    //o/p
    //point def ctor
    //point def ctor
    //line 5p ctor

    MyLine l1;
    //o/p
    //point def ctor start
    //point def ctor end
    //line def ctor
    //line dest
    //point des end
    //point des start
    
    
    
    // initgraph();
    // setcolor(4);
    // line(1,2,3,4);
    // setcolor(6);
    // rectangle(1,2,3,4);
}


/////////////////////////////////////////
//lab assignments
//1-Complex
////cpy ctor [useless]
////= operator [useless]
////c1+c2
////c1+10
////c1+=c2
////c1++
////++c1
////c1>c2

//10+c1 [standalone]

/////////////////////////////////
//2- stack
///cpy ctor [MUST]
///=operator [MUST]
///Stack Reverse(){}

///bonus    s1==s2
///bonus    s3=s1+s2;

//3- composition   [draw abajora]

//4-[bonus]   moving fan

