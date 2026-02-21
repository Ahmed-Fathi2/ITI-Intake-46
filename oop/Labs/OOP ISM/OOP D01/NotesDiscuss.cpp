///cpp language keywords is lower case
///int main float  DoubleXXXX

///cpp lang. is case sensitive
//int x=3;int y=33;int z=55;
//int X=3;


//Skeleton of Cpp
///file.cpp
///1-Preprocessing
#include<iostream>  //console   read & write in console
#include<math.h>  //sqrt(4)
//#define Later
//discussed later  d06
using namespace std;

///2-Global Declaration
///global variable
///function
///struct,class

///3- Entry point
int main()
{
    ///4-local declaration 
    ///local variable
    ///processing
    ///operators   5/0   prog. returns -65432345654

    ///5-end of program o.s indicator
    return 0; //when program returns zero 
    //,it means program runs successfully  
}
///////////////////////////////////////////////
///skeleton
//file.cpp
#include<iostream>
using namespace std;

int main()
{
    //
    return 0;
}

//////////////////////////////////////////////////////////
///program to print hello ISM  Helo again
#include<iostream>
using namespace std;

int main()
{
    cout<<"Hello Intake46 Ismailia\n"<<endl;
    cout<<"Hello Again";
    return 0;
}
//o/p
//Hello Intake46 Ismailia

//Hello Again



//\n new line
//\t tab
//<<endl  new line

////////////////////////////////////////////////////////////
///program to print your age ,salary
#include<iostream>
using namespace std;

int main()
{
    int age=22;
    float salary=1.2;
    cout<<"ur age is\t";
    cout<<age;

    cout<<"ur age is "<<age<<endl;
    cout<<"ur salary is "<<salary<<endl;

    cout<<"ur age is "<<age<<"\n"<<"and salary is "<<salary<<endl;
    return 0;
}
//o/p
//ur age is 22


////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////
//Later to be discussed [Address]
#include<iostream>
using namespace std;
int main()
{
    int age=22;        //age|22| 0x10
    float salary=1.2;  //salary|1.2| 0x55

    cout<<"value of age="<<age<<endl;
    cout<<"address of age="<<&age<<endl; //0x10
    cout<<"value of salary="<<salary<<endl;
    cout<<"address of salary="<<&salary<<endl; //0x55

    return 0;
}

///////////////////////////////////////////////////////
//read age from user then print it
//please enter ur age
//22 ENTER
//yur age is 22

//cin>>variable;  read stream of chrachters from user at runtime
///untill press enter
#include<iostream>
using namespace std;
int main()
{
    int age;

    cout<<"Plz enter ur age\n";
    cin>>age; //22 ENTER
    
    cout<<"ur age is "<<age<<endl;
    return 0;
}

////////////////////////////////////////////////////////////
///operators
///1- arithmatic operators
    ///A. Binary arithmatic operator  +,-,*,/,%
    int x=3,y=4,z;
    z=x%y;
    cout<<x; //3
    cout<<y; //4
    cout<<z; //3


    ///B. Unary Operator  ++,--  increment/decrement by 1
        ///variable++ => POSTFIX
        ///++Variable => PREFIX
    
        int x=3,y=4,z=5;
        //x++;
        //++x;
        
        // z=x++;  //Compiler #1 z=x   #2x++
        // cout<<x; //4
        // cout<<z; //3
        // cout<<y++;// o/p 4     memory y|5|
        // cout<<y; //5

        z=++x;  //Compiler #1 x++   #2z=x
        cout<<x; //4
        cout<<z; //4
        cout<<++y;// o/p 5     memory y|5|
        cout<<y; //5


    //REMEMBER
int x=1,z;
z=x+1;
//print x 1
//print z 2
z=++x;
//print x 2
//print z 2

//////////////////////////
///2-Compound Operator +=,-=,*=,/=,%=    ==XXXX
int x=3,y=4,z=5;
x+=y; //x=x+y
/////////////////////////////////////

///3- Comparison operator >,<,>=,<=,==,!=   //1 for true  //0 for false
int x=3,y=4,z=5,a=3;

cout<<x!=y; //1

///4-Logical operator &&,||    Later,<<,>>,&,|,!   
int x=3,y=4,z=5;

cout<<   x>y && y<z && z>x ;   //0
//&& return 1 if all braches are 1
//&& returns 0 if ANY branch is 0

cout<<   x<y || y<z || z>x ;    //1
//|| return 0 if all braches are 0
//|| returns 1 if ANY branch is 1

/////////////////////////////////////////////////////////



///Lab Assignments @12.00    Each in separated Projects
//0- codeblocks setup
//1- print Hello SD OS
//2- read Age and print it
//3- read Age and print value and address

//5-[search] 
///on turnary operator ()?value1:value2;
///[Report] dynamic vs. static linking