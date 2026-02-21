///namespace 
///logical grouping for one or more DT's
///to acheive performance and identity 

//in c

// struct Book
// {
//     isbn;
//     authorName;
//     title;
//     year;
// };

// struct Book
// {
//     ticketNo;
//     passengerName;
//     from;
//     to;
// };


//in cPP

namespace BookRead
{
    struct Book
    {
        isbn;
        authorName;
        title;
        year;
    };
}
namespace BookTicket
{
    struct Book
    {
        ticketNo;
        passengerName;
        from;
        to;
    };
}
using namespace BookRead;
int main()
{
    Book b1;
    Book b2;
    Book b3;
    BookTicket::Book bt1;
}


//////////////////////////////////////////////


//#include<iostream>  ///   namespace std{ cout<<,cin>>}
using namespace std;
int main()
{
    int age;
    std::cout<<"Enter age"<<endl;
    cin>>age;
    cout<<"age="<<age<<endl;
    return 0;
}
/////////////////////////////////////////////
//Reference : alias name for another variable in momory

int main()
{

    int x=10;  //x|10|0x10

    int& y=x; //alias name for x named y
    //y x|10|0x10
    
    int& z=y;  //compile error

    return 0;
}

/////////////////////////////////////////

void SwapV(int left,int right)
{
    int tmp=left;
    left=right;
    right=tmp;
}
void SwapA(int* left,int* right)
{
    int tmp=*left;
    *left=*right;
    *right=tmp;
}

void SwapR(int& left,int& right)
{
    int tmp=left;
    left=right;
    right=tmp;
}
int main()
{
    int x=3,y=5;

    SwapR(x,y); //pass references
    cout<<x;
    cout<<y;
}

//Notes//////////////////////////////////////////
//class=== struct in cPP  except 1-   2-
//any member is accessed by object name
//private: member can be accessed inside class/struct scope ONLY
//public: member can be accessed inside and outside class/struct scope
//struct default access modifier -> public
//class default access modifier -> private
////////////////////////////////////////////
struct Employee
{
    //member data
    private:
    int id;
    int age;
    float salary;
    //password
    public:
    //gates [setters & getters]

    //setter for id
    //caller [e2]
    void SetId(int _id)
    {
        /*caller e2*/id=_id;
    }

    //getter for id
    //caller e1
    //caller e2
    int GetId()
    {
        return /*caller e2*/id;
    }

    void SetAge(int _age)
    {
        age=_age;
    }
    int GetAge()
    {
        return age;
    }
    void SetSalary(float _salary)
    {
        if(_salary>=5000&&_salary<=10000)
        {salary=_salary;}
        else{salary=5000;}
    }
    float GetSalary()
    {
        return salary;
    }

    //fn to Print Employee
    //caller e1
    void Print()
    {
        cout<</*caller e1*/id<<endl;
        cout<</*caller e1*/age<<endl;
        cout<</*caller e1*/salary<<endl;
    }
};

//oop violation [encapsulation]
int main()
{
    Employee e1;  //object/instance from Employee
    Employee e2;  //object/instance from Employee

    e1.id=1;
    e1.age=22;
    e1.salary=1234;

    cout<<e1.id;
    cout<<e1.age;
    cout<<e1.salary;

}

int main()
{
    Employee e1;    //object/instance from Employee
    Employee e2;  //object/instance from Employee
    //e1.id=1; //compile error inaccessible
    //memory
    //e1  id|1| age|| salary||
    //e2  id|2| age|| salary||
    
    e1.SetId(1);
    e1.SetAge(22);
    e1.SetSalary(25000);

    cout<<e1.GetId();
    cout<<e1.GetAge();
    cout<<e1.GetSalary(); 

    int tmp;
    float tmpSal;
    cout<<"Enter id\n";
    cin>>tmp;
    e2.SetId(tmp);
    cout<<"Enter age\n";
    cin>>tmp;
    e2.SetAge(tmp);
    cout<<"Enter salary\n";
    cin>>tmpSal;
    e2.SetSalary(tmpSal);

    cout<<e2.GetId();
    cout<<e2.GetAge();
    cout<<e2.GetSalary(); 
    
    e1.Print();
    e2.Print();

}
/////////////////////////////////////////
//inside any member fn
//there is hidden input parameter
//called   className* this


class Employee
{
    private:
    int id;
    int age;
    float salary;
    public:
    //caller e1
    void SetId(/*Employee *this,*/int _id)
    {
        (*this).id=_id;
        // //or
        // this->id=_id;
        // //or
        // id=_id;
    }
    int GetId()
    {
        return this->id;
    }

    void SetAge(int _age)
    {
        (*this).age=_age;
    }
    int GetAge()
    {
        return age;
    }
    void SetSalary(float _salary)
    {
        if(_salary>=5000&&_salary<=10000)
        {this->salary=_salary;}
        else{salary=5000;}
    }
    float GetSalary()
    {
        return salary;
    }
    void Print()
    {
        cout<</*caller e1*/id<<endl;
        cout<<this->age<<endl;
        cout<<(*this).salary<<endl;
    }
};
int main()
{
    Employee e1;

    e1.SetId(1);
    //compiler Employee::SetId(&e1,1);
    e1.SetAge(22);
    //compiler Employee::SetAge(&e1,1);
    e1.SetSalary(1234);
    //compiler Employee::SetSalary(&e1,1234);
    return 0;
}
/////////////////////////////////////////
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
    //member fn to add 2 complex #'s
    //Complex Add(Complex left ,Complex right)
    Complex Add(const Complex& right) const
    {
        Complex result;
        //tatataaaaaaaaaa
        //right.real=-12345;
        //
        result.real= (*this).real +right.real;
        result.img=img+right.img;
        return result;
    }
    //
};
//standalone fn to add 2 complex #'s
Complex AddComplex(const Complex& left,const Complex& right)
{
    Complex result;

    //tatataaaa
    left.SetReal(-1234);
    //
    //result.real=left.real+right.real; //Compile error inaccessible
    int r=left.GetReal()+right.GetReal();
    int i=left.GetImg()+right.GetImg();
    result.SetReal(r);
    result.SetImg(i);
    return result;
}
//

int main()
{
    Complex c1,c2,c3;

    c1.SetReal(3);
    c1.SetImg(4);

    int tmp;
    cout<<"Enter real\n";
    cin>>tmp;
    c2.SetReal(tmp);
    cout<<"Enter img\n";
    cin>>tmp;
    c2.SetImg(tmp);

    //
    //c3=c1.Add(c1,c2);  //pass by value[read only]
    
    //c3=c1.Add(c2);  //pass by Reference [read/wrire]
    
    c3=AddComplex(c1,c2); //pass by Reference
    
    ///compiler Complex::Add(&c1,c2)
    //
    c1.Print(); //3+4i
    c2.Print(); //5+6i
    c3.Print(); //8+10i
    return 0;
}

/////////////////////////////////////////////
//overloading:
//fns [at same scope] has same name
///but different input parameters
///number,order or type


class Math
{
    public:
    int Add(int left,int right)
    {
        return left+right;
    }

    int Add(int left,int middle,int right)
    {
        return left+middle+right;
    }

};
int main()
{
    Math obj;
    cout<<obj.Add(1,2); //3
    cout<<obj.Add(1,2,3); //6
}

//////////////////////////////////////////
//default Arguments
//v1

class Math
{
    public:
    int Add(int left=0,int middle=0,int right=0)
    {
        return left+middle+right;
    }

};
int main()
{
    Math obj;
    cout<<obj.Add(1,2,3); //6
    cout<<obj.Add(1,2); //3
    cout<<obj.Add(1); //1
    cout<<obj.Add(); //0
}

/////////////////
//v2

class Math
{
    public:
    int Add(int left,int middle=0,int right=0)
    {
        return left+middle+right;
    }

};
int main()
{
    Math obj;
    cout<<obj.Add(1,2,3); //6
    cout<<obj.Add(1,2); //3
    cout<<obj.Add(1); //1
    cout<<obj.Add(); //Compile error
}

////////////
//v3

class Math
{
    public:
    int Add(int left,int middle,int right=0)
    {
        return left+middle+right;
    }

};
int main()
{
    Math obj;
    cout<<obj.Add(1,2,3); //6
    cout<<obj.Add(1,2); //3
    cout<<obj.Add(1); //Compile Error
    cout<<obj.Add(); //Compile error
}

////////////
//v4   WRONGGGGGGGGG
//default argument [optional paramters] must come 
//after all required parameters
class Math
{
    public:
    int Add(int left=0,int middle,int right) //compile error
    {
        return left+middle+right;
    }

};
int main()
{
    Math obj;
    cout<<obj.Add(,2,3); 
}

///////////////////////////////////////
//v5    أوعى

//use overloading OR default arguments
class Math
{
    public:
    int Add(int left,int right)
    {
        return left+right;
    }

    int Add(int left=0,int middle=0,int right=0)
    {
        return left+middle+right;
    }

};
int main()
{
    Math obj;
    cout<<obj.Add(1,2,3);
    cout<<obj.Add(1);
    cout<<obj.Add();


    cout<<obj.Add(1,2); //compile error //ambiguty
}

//////////////////////////////////////////////

//lab
//try const,this

//Complex
//real,img set set,get,get print ,add

//add standalone

//print

//real   img
//3      4   3+4i
//3      -4   3-4i
//3      1    3+i
//3      -1    3-i
//0      1     i
//0      -1    -i
//0      0     0
//1      0     1




