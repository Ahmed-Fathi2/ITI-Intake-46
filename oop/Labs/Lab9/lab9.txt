//1-Inheritance
//2-Aggregation[association]
////////////////////////////////////////////////////

//Inheritance:
///>Extending methods and fields from
///class to another one

///>new datatype =>receiving methods and fields
///Was created actually in another datatype

//////////////////////////////////////////////////////////
///TypeA
////x
////y
////funOne()
////funTwo()

///TypeB
////y
////z
////funTwo()
////funThree()

//Solution//////////////////////////////
///Base
////y
////FunTwo()

///TypeA Inherits Base
////x
////funOne()


///TypeB Inherits Base
////z
////funThree()   
///////////////////////////////////////////
class Parent
{
    private:
    int x;
    int y;
    public:
    void SetX(int _x){x=_x;}
    void SetY(int _y){y=_y;}
    int GetX() const{return x;}
    int GetY()const {return y;}
    //c2 call this ctor to initialize inherited members
    Parent()
    {
        x=y=0;
        cout<<"Parent def ctor\n";
    }
    //c2 call this ctor [ctor chaining] to initialize inherited members
    Parent(int _x,int _y)
    {
        x=_x;y=_y;
        cout<<"Parent 2p ctor\n";
    }
    ~Parent(){cout<<"Parent dest";}
    Parent(const Parent& old)
    {
        x=old.x;y=old.y;
        cout<<"Parent cctor";
    }
    int SumXY()
    {
        return x+y;
    }
};
//child inhertis EVERYTHING from Parent
//public: types of inheritance
class Child:public Parent
{
    //x,y,setx,sety,getx,gety,sumxy  
    private:
    int z;
    public:
    void SetZ(int _z){z=_z;}
    int GetZ() const{return z;}
    Child()
    {
        //->  c1  x|0| y|0| z|?|
        z=0;
        //->  c1  x|0| y|0| z|0|
        //x=0;y=0; //Compile Error inaccessible
        
        //useless
        //this->SetX(0);
        //SetY(0);
        cout<<"Child def ctor";
    }

    Child(int _x,int _y,int _z)
    :Parent(_x,_y)
    {
        //c2 x|1| y|2| z|?|
        z=_z;
        //c2 x|1| y|2| z|3|
        
        //useless after ctor chaining
        //SetX(_x);
        //this->SetY(_y);
        //>
        cout<<"Child 3p ctor";
    }
    ~Child(){}
    Child(const Child& old)
    {
        z=old.z;
        SetX(old.GetX());
        SetY(old.GetY());
        cout<<"child cctor";
    }
    int SumXYZ()
    {
        return z+SumXY();
        return z+GetX()+GetY();
        //return x+y+z;
    }
};

int main()
{

    Child c2(1,2,3);
    cout<<c2.SumXYZ(); //6
    cout<<c2.SumXY(); //3
    //o/p
    //parent ctor
    //child ctor

    Child c1; //12B  x|| y|| z||
    //o/p
    //parent def ctor
    //child def ctor
    //child dest
    //parent dest


    //Always access public MEMBERS ONLY
    Parent p1;   ///8B  x|0| y|0|
}

//Rules//////////////////////////////////////////////////////////
//>1-Child Inherits EVERYTHING from parent  except?
//   public ,private  YESSSSS

//>2-public:member can be accessed inside & outside class or struct
//>3-private:member can be accessed inside class or struct ONLY

//>4- [search]  ctor?  static?
///////////////////////////////////////////////////////////////////

//Is there any way to access private members
//in child DT? YES if it became protected

//protected: [smart private]  [inheritance]
///member can be accessed
///inside class scope
///and accessed inside chain of inheritance
///ONLY

///SumXY()   , SumXYZ    ,  SumXYZA   XXXXX

///////////////////////////////////////////////
class Parent
{
    protected:
    int x;
    int y;
    public:
    void SetX(int _x){x=_x;}
    void SetY(int _y){y=_y;}
    int GetX() const{return x;}
    int GetY()const {return y;}
    //c2 call this ctor to initialize inherited members
    Parent()
    {
        x=y=0;
        cout<<"Parent def ctor\n";
    }
    //c2 call this ctor [ctor chaining] to initialize inherited members
    Parent(int _x,int _y)
    {
        x=_x;y=_y;
        cout<<"Parent 2p ctor\n";
    }
    ~Parent(){cout<<"Parent dest";}
    Parent(const Parent& old)
    {
        x=old.x;y=old.y;
        cout<<"Parent cctor";
    }
    int Sum()
    {
        return x+y;
    }
};
//child inhertis EVERYTHING from Parent
//public: types of inheritance
class Child:public Parent
{
    //x,y,setx,sety,getx,gety,sumxy  
    private:
    int z;
    public:
    void SetZ(int _z){z=_z;}
    int GetZ() const{return z;}
    Child()
    {
        z=0;
        x=0;y=0; //useless
        cout<<"Child def ctor";
    }

    Child(int _x,int _y,int _z)
    :Parent(_x,_y)
    {
        z=_z;
        //usless if there is ctor chaining
        x=_x;
        y=_y;
        cout<<"Child 3p ctor";
    }
    ~Child(){}
    Child(const Child& old)
    {
        z=old.z;
        SetX(old.GetX());
        SetY(old.GetY());
        cout<<"child cctor";
    }
    int Sum()
    {
        return z+ Parent::Sum();
        return z+ Sum(); //stack overflow
        return x+y+z;  //effective
    }
};
int main()
{
    //in main Access public ONLYYYY
    Child c1(1,2,3);
    cout<<c1.Sum(); //6
    cout<<c1.Parent::Sum(); //3  //non sense


    Parent p1;
    //p1.x=10; //protected compile error inaccessible
}

//overriding: [inheritance]
//fn with same name,same parameter
//but body/implementation is diffrent
//in child DT

/////////////////////////////////////////////

class Geoshape
{
    protected:
    double dim1;
    double dim2;
    public:
    void SetDim1(double _dim1){dim1=_dim1;}
    double GetDim1(){return dim1;}
    void SetDim2(double _dim2){dim2=_dim2;}
    double GetDim2(){return dim2;}
    Geoshape()
    {
        dim1=dim2=0;
        cout<<"geo def ctor";
    }
    Geoshape(double _dim1,double _dim2)
    {
        dim1=_dim1;
        dim2=_dim2;
        cout<<"geo 2p ctor";
    }
    Geoshape(double _dim)
    {
        dim1=dim2=_dim;
        cout<<"geo 1p ctor";
    }
    ~Geoshape(){}
};
/////
class Rect:public Geoshape
{
    //fields? NOOO
    public:
    Rect()//:Geoshape(0)
    {
        //useless
        //dim1=dim2=0;
        cout<<"Rect def ctor";
    }
    Rect(double _d1,double _d2)//:Geoshape(_d1,_d2)
    {
        dim1=_d1;
        dim2=_d2;
        cout<<"Rect 2p ctor";
    }
    ~Rect(){}
    double Area()
    {
        return dim1*dim2;
    }
};
/////
class Square:protected Geoshape
{
    //
    public:
    Square(){}
    Square(double _d):Geoshape(_d)//Geoshape(_d,_d)
    {
        //useless after ctor chaining
        //dim1=dim2=_d;
    }
    ~Square(){}
    double Area()
    {
        return dim1*dim2;
    }
    //
    void SetDim1(double _dim1){dim1=dim2=_dim1;}
    void SetDim2(double _dim2){dim2=dim1=_dim2;}
    //
};
/////
class SquareV2:public Rect
{
    public:
    SquareV2(){}
    SquareV2(double _d):Rect(_d,_d)
    {}
    ~SquareV2(){}
};
/////
class Circle:public Geoshape
{
    public:
    Circle(){}
    Circle(double _radius)
    {
        dim1=dim2=_radius;
    }
    ~Circle(){}
    double Area()
    {
        3.14 * dim1 * dim2;
    }
};
/////
class Tri:public Geoshape
{
    public:
    Tri(){}
    Tri(double _base,double _height)
    :Geoshape(_height,_base)
    {}
    ~Tri(){}
    double Area()
    {
        return 0.5 * dim1 * dim2;
    }
};

int main()
{
    SquareV2 s1;
    //o/p
    //geo ctor
    //rect ctor
    //sqv2 ctor



    Rect r1;
    Rect r2(1,2);
}

int main()
{
    Square s1(10);  //s1 dim1|10| dim2|10|
    s1.SetDim1(3);  //s1 dim1|3| dim2|3|
    //s1.Geoshape::SetDim2(4);  //s1 dim1|4| dim2|4|
    cout<<s1.Area(); //16
}

///////////////////////////////////////////////
///////////////////////////////////////////////
///////////////////////////////////////
//TYPES OF INHERITANCE
//A. Public [MOST USED] [All MUST:Public]

class Parent
{
    private:
    int x;
    protected:
    int y;
    public:
    int z;
    void setX(int _x){x=_x;}
    void setY(int _y){y=_y;}
    void setZ(int _z){z=_z;}
    int getX(){return x;}
    int getY(){return y;}
    int getZ(){return z;}
    Parent()
    {
        //x,y,z
        x=y=z=0;
    }
    int sum()
    {
        return x+y+z;
    }

};
class Child :public Parent
{
    //x,y,z,sss,ggg,sum
    private:
    int a;
    protected:
    int b;
    public:
    int c;
    void setA(int _a){a=_a;}
    void setB(int _b){b=_b;}
    void setC(int _c){c=_c;}
    int getA(){return a;}
    int getB(){return b;}
    int getC(){return c;}
    Child()
    {
        y=z=a=b=c=0;  //x
    }
    int sum()
    {
        return getX()+y+z+a+b+c;
    }
};
class SubChild:public Child
{
    ///  
    int j;
    protected:
    int k;
    public:
    int l; 
    SubChild()
    {
        //x=y=z=a=b=c=j=k=l=0;  //x,a
    }
    int sum()
    {
    }
};

main()
{
    Parent p;
    //p. PUBLIC ONLY  z sss ggg sum 

    Child c;
    //c. PUBLIC ONLY  z,c,  Parent::sssggg ,chils::sssggg ,sum 

    SubChild sc; //PUBLIC ONLY z,c,l 
}

/////////////////////////////////////////////////////////
//B. Protected
class Parent
{
    int x;
    protected:
    int y;
    public:
    int z;
    void setX(int _x){x=_x;}
    void setY(int _y){y=_y;}
    void setZ(int _z){z=_z;}
    int getX(){return x;}
    int getY(){return y;}
    int getZ(){return z;}
    Parent()
    {
        //x,y,z
        x=y=z=0;
    }
    int sum()
    {
        return x+y+z;
    }

};
class Child :protected Parent
{
    //x,y,z,sss,ggg,sum
    //x private still private cannot access
    //y protected still protected can be accessed
    //z ,sss,ggg,sum public promotes to protected can be accessed
    int a;
    protected:
    int b;
    public:
    int c;
    void setA(int _a){a=_a;}
    void setB(int _b){b=_b;}
    void setC(int _c){c=_c;}
    int getA(){return a;}
    int getB(){return b;}
    int getC(){return c;}
    Child()
    {
        //x=y=z=a=b=c=0; //x
    }
    int sum()
    {
        
    }
};

class SubChild:protected Child
{
    //x,a private still priv cannot access
    //y protected still prot can be accessed
    //z protected still prot can be accessed
    //b protected still prot can be accessed
    //c public promotes to prot can be accessed
    int j;
    protected:
    int k;
    public:
    int l; 
    SubChild()
    {
    }
    int sum()
    {
        
    }
};

main()
{
    Child c;
    //c. setZ

    SubChild sc;  //l
    //sc.x,y,z,a,b,c ???? XXXX
    //sc.setC() 
}


/////////////////////////////////////////////
//C. Private  RARELY USED
class Parent
{
    int x;
    protected:
    int y;
    public:
    int z;
    void setX(int _x){x=_x;}
    void setY(int _y){y=_y;}
    void setZ(int _z){z=_z;}
    int getX(){return x;}
    int getY(){return y;}
    int getZ(){return z;}
    Parent()
    {
        //x,y,z
        x=y=z=0;
    }
    int sum()
    {
        return x+y+z;
    }

};
class Child :private Parent
{
    ////x,y,z,sss,ggg,sum
    //x priv [not accessed here]
    //y protected promotes to private [accessed here]
    //z public promotes to private [accessed here]  
    //setters&getters  sum became private [accessed here]
    
    int a;
    protected:
    int b;
    public:
    int c;
    void setA(int _a){a=_a;}
    void setB(int _b){b=_b;}
    void setC(int _c){c=_c;}
    int getA(){return a;}
    int getB(){return b;}
    int getC(){return c;}
    Child()
    {
        //x=y=z=a=b=c=0;  //x
    }
    int sum()
    {
        return y+z+a+b+c+getX();
    }
};

//(P)x,y,z [private]  ,a b c
class SubChild:private Child
{
    //x private [not accessed] 
    //y private [not accessed]
    //z private [not accessed]
    //a private [not accessed]
    //b private [accessed]
    //c private [accessed]
    //child setter and getter private [accessed]
    //parent setter and getter private [not accessed]
    //sum() parent private [not accessed]
    //sum() child private [accessed]
    int j;
    protected:
    int k;
    public:
    int l; 
    SubChild()
    {
        //xN yN zN aN bT cT
    }
    int sum()
    {
        
    }
};

int main()
{
    Child c1;  //c //setter&getters of child
    SubChild sc1; //l
}

//////////////////////////////////////////////

//Most Commonly used class:public class ONLY
//C# java ONLY class: class   public

//RARELY USED
//child:protected Parent
//class Utility{public color(){} };
//class Button:protected utility {};

//main()
//button b1;

//child:private parent
//class Timer{private:start() ,Stop()};
//class Exam:private Timer
//{

//};

//////////////////////////////////////////////
class Point
{
    private:
    int x;
    int y;
    public:
    void SetX(int _x){x=_x;}
    void SetY(int _y){y=_y;}
    int GetX(){return x;}
    int GetY(){return y;}
    Point()
    {
        x=y=0;
        cout<<"Point def ctor";
    }
    Point(int _x,int _y)
    {
        x=_x;y=_y;
        cout<<"Point 2p ctor";
    }
    ~Point(){cout<<"Point dest";}
    Point(const Point& old){x=old.x;y=old.y;cout<<"cpy ctor";}
};

int main()
{
    
    Point p1(3,4); //Stack
    //point 2p ctor

    Point *pPtr=new Point(3,4);
    //point 2p ctor called
    delete pPtr; //remove one object
    //point dest called

    //anonymous object
    Point(3,4);
    //call ctor then dest at same time

    Point parr[3]; //3*8
    //point def ctor
    //point def ctor
    //point def ctor

    Point parr2[3]={Point(3,4),Point(3,4),Point(3,4)};
    //point 2p ctor
    //point 2p ctor
    //point 2p ctor

    Point* pPtrArr=new Point[3];
    //point def ctor
    //point def ctor
    //point def ctor
    pPtrArr[0].SetX(3);
    pPtrArr[0].SetY(4);

    delete [] pPtrArr;
    //point dest
    //point dest
    //point dest

    return 0;
}

/////////////////////////////////////////////
//aggregation/association
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

class Shape
{
    protected:
    int myColor;
    public:
    void SetMyColor(int _mycolor){myColor=_mycolor;}
    int GetMyColor(){return myColor;}
    Shape()
    {
        myColor=0;
    }
    Shape(int _color)
    {
        myColor=_color;
    }
    ~Shape(){}
};

class MyLine:public Shape
{
    private:
    Point start;
    Point end;
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
    
    MyLine()
    {
        
    }

    MyLine(int x1,int y1,int x2,int y2,int _color)
    :start(x1,y1),end(x2,y2),Shape(_color)
    {
       
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

class Rect:public Shape
{
    private:
    Point ul;
    Point lr;
    public:
    //setters & getters
    Rect()
    {
    }
    Rect(int x1,int y1,int x2,int y2,int _color)
    :ul(x1,y1),lr(x2,y2),Shape(_color)
    {
    }
    ~Rect(){}
    Rect(Rect& old){}
    void Draw()
    {
        setcolor(myColor);
        rectangle(ul.GetX(),ul.GetY(),lr.GetX(),lr.GetY());
    }
};

class MyCircle:public Shape
{
    int radius;
    Point center;
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

class MyTri:public Shape
{
    Point p1;
    Point p2;
    Point p3;
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

class Picture
{
    private:
    MyLine *lPtr;   
    int lSize;
    Rect *rPtr;
    int rSize;
    public:
    Picture()
    {
        lPtr=NULL;
        lSize=0;
        rPtr=NULL;
        rSize=0;
    }
    //set relationship
    void SetLines(MyLine* _lPtr,int _lSize)
    {
        lPtr=_lPtr;
        lSize=_lSize;
    }
     void SetRects(Rect* _rPtr,int _rSize)
    {
        rPtr=_rPtr;
        rSize=_rSize;
    }

    //Process
    void Execute()
    {
        for (int i = 0; i < lSize; i++)
        {
            lPtr[i].Draw();
        }
        for (int i = 0; i < rSize; i++)
        {
            rPtr[i].Draw();
        }
        
        
    }

};

int main()
{
    initgraph();
    MyLine larr[2]={MyLine(1,1,1,1,1),MyLine()};
    Rect rarr[3]={};
    Circle carr[2]={};
    MyTri t1;
    Picture p1;


    ///set relationship
    p1.SetLines(larr,2);
    p1.SetRects(rarr,3);
    //process
    p1.Execute();

    ///Remove relationship
    p1.SetLines(NULL,0);
    p1.SetRects(NULL,0);
}



//////////////////////////////////

///Lab assignments

///abagora  via picture









