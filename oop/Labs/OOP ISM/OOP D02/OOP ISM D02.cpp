///D02
//loops
//Conditions
//Magic Box
//Function
/////////////////////////////////////////
///if condition
///if(condition)
///{
/////code here if condition is true
///}
///////////////////
///if(condition)
///{
/////code here if condition is true
///}
///else
///{
/////code here if condition is false
///}
//////////////////////////////////////////
///if(condition)
///{
/////code here if condition is true
///}
///else if(condition)
///{
/////code here if condition is true
///}
///else if(condition)
///{
/////code here if condition is true
///}
///else
///{
/////code here all conditions are false
///}
/////////////////////////////////////////
///if(condition)
///{
/////if(condition)
    ///{
    ///}
///}
///else if(condition)
///{
/////code here if condition is true
///}
////////////////////////////////////////////
///if(condition)
///{
/////code here if condition is true
///}
///if(condition)
///{
/////code here if condition is true
///}
///if(condition)
///{
/////code here if condition is true
///}
/////////////////////////////////////////////////
//#include<iostream>
using namespace std;
int main()
{
    int grade;
    cout<<"Enter grade\n";
    cin>>grade; //90

    if(grade>=85)
    {
        cout<<"A";
    }
    else if(grade>=75&&grade<85)
    {
        cout<<"B";
    }
    else if(grade>=65&&grade<75)
    {
        cout<<"C";
    }
    else if(grade>=60&&grade<65)
    {
        cout<<"D";
    }
    else
    {
        cout<<"Invalid input";
    }
    return 0;
}
////////////////////////////
int main()
{

    int month;
    cout<<"Enter month #\n";
    cin>>month; //13
    if(month==1)
    {
        cout<<"Jan";
    }
    else if(month==2)
    {
        cout<<"Feb";
    }
    else if(month==3)
    {
        cout<<"Mar";
    }
    else if(month==4)
    {
        cout<<"Apr";
    }
    else
    {
        cout<<"Invalid";
    }




    return 0;
}

//////////////////////////////////////////////////
//if condition with check specific value 
//is not recommended

//switch
//switch is available with int,char ONLY

// switch (variable)
// {
//     case value1:
//     /* code */
//     break;
//     case value2:
//     /* code */
//     break;
//     case value3:
//     /* code */
//     break;
//     default:
//     //code
//     break;
// }

int main()
{
    int month;
    cout<<"Enter month #\n";
    cin>>month; //2

    switch(month)
    {
        case 1:
        cout<<"Jan";
        break;
        case 2:
        cout<<"Feb";
        break;
        case 3:
        cout<<"Mar";
        break;
        case 4:
        cout<<"Apr";
        break;
        default:
        cout<<"Invalid";
        break;
    }
    //->
    return 0;
}

///////////////////////////////////////////////
int main()
{
    char grade;
    cout<<"Enter grade\n";
    cin>>grade;//a

    switch(grade)
    {
        case 'A':
        case 'a':
        cout<<"Excellent";
        break; //forget => fall through
        case 'B':
        case 'b':
        cout<<"V good";
        break;
        case 'C':
        case 'c':
        cout<<"Good";
        break;
        case 'D':
        case 'd':
        cout<<"Fair";
        break;
        default:
        cout<<"Invalid!!!";
        break;
    }

    return 0;
}
////////////////////////////////////////////////////

// cout<<"Hello Intake46 Ism";
// cout<<"Hello Intake46 Ism";
// cout<<"Hello Intake46 Ism";
// cout<<"Hello Intake46 Ism";
// cout<<"Hello Intake46 Ism";

//copy and paste -> bad programming
//effort redundant
//1-cost of declaration
//2-cost of modifications

//for loop

// for(initial value;condition[true];increment/decrement)
// {
//     //code here if condition is true
// }

int main()
{
    
    //  #1     #2#5   #4
    for(int i=1;i<6;i++)
    {
        //#3
        cout<<"Hello I46 Ismailia\n";
    }
    //memory i 1 2 3 4 5 6
    //o/p
    //Hello I46 Ismailia
    //Hello I46 Ismailia
    //Hello I46 Ismailia
    //Hello I46 Ismailia
    //Hello I46 Ismailia


    for(int i=10;i>=1;i--){}

    return 0;
}
///////////////////////////////////////////////////
//Some Practice
int main()
{
    int x=0;
    if(x=22)
    {
        cout<<"T";
    }
    else
    {
        cout<<"F";
    }
    
}
////////////////////////////////////////////////
//nested for loop
int main()
{



    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            cout<<i<<","<<j<<endl;
        }  
    }
    //memory i 0 1  |  j 0 1 2 3 4 0
    //o/p
    //0,0
    //0,1
    //0,2
    //0,3
    //1,0

    
    

    for(int i=0,j=0; i>10||j<11 ;i++,j--)
    {}

    return 0;
}
////////////////////////////////////////////////
//loop non specific # of times
//do-while
//while

// do
// {
//     //code here
// }
/////while(condition[true]);

// while(condition[true])
// {
//     //code here
// }

int main()
{

    int container=0;
    int num;

    do
    {
        cout<<"Enter #\n";
        cin>>num; //100
        container+=num;
        
        cout<<"Debug->" <<container<<endl;
    }
    while(container<=100);

    cout<<"Container="<<container<<endl;

    return 0;
}

int main()
{

    int container=0;
    int num;

    while(container<=100)
    {
        cout<<"Enter #\n";
        cin>>num; //1000
        container+=num;
        
        cout<<"Debug->" <<container<<endl;
    }

    cout<<"Container="<<container<<endl;

    return 0;
}



///plz enter age betw 18 and 60

//plz enter id 1
//plz enter name kareem
//plz enter age 18-60   80
//plz enter age 18-60   90
//plz enter age 18-60   10
//plz enter age 18-60   22
//plz enter grade.....
int main()
{
    int age;

    do
    {   
        cout<<"Enter age\n";
        cin>>age; //22
    }
    while(age < 18 ||  age > 60);

    cout<<"age="<<age<<endl; //22

    int evenNum;

    do 
    {
        cout<<"Enter even #\n";
        cin>>evenNum; //3
    }
    while(evenNum %2!=0);
    //->
    cout<<"Even # is "<<evenNum;
    return 0;
}
////////////////////////////////////////////////
//function

int main()
{
    cout<<"Hello";
    cout<<"Good morning";
    cout<<"Good Bye";
    //
    //
    //
    //
    //
    cout<<"Hello";
    cout<<"Good morning";
    cout<<"Good Bye"
    //
    //
    //
    //
    //
    //
    //
    cout<<"Hello";
    cout<<"Good morning";
    cout<<"Good Bye";
    return 0;
}

//solution 
//for loop  XXXX


//function:
//group of code togrther with specific name
//when to use this code, call that name

//fun is written in global declaration

// //syntax
/*ReturnType FunName(input parameter/s)
{
    //code here
}*/

///return type
///>fn return nothing   -> void
///int,float ....
///>if fn returns any DT but void
/// it must be enclosed by keyword [return]


//#
//using ns

void TryMe()
{
    cout<<"Hello";
    cout<<"Good morning";
    cout<<"Good Bye";
}

int main()
{
    //call FunName
    TryMe();
    //
    //
    //
    //
    //
    TryMe();
    //
    //
    //
    //
    //
    //
    TryMe();
    return 0;
}

///////////////////////////////////////////////
//V1
//#
//using ns

void Add()
{
    int x,y,result;
    cout<<"Enter x\n";
    cin>>x;
    cout<<"Enter y\n";
    cin>>y;
    result=x+y;
    cout<<"x+y="<<result;
    
}
int main()
{
    Add();
    return 0;
}

///////////////////////////////////////////////
//SOLID Principles
///////////////////////////////////////////////
//V2

//#
//using ns

void Add(int left,int right)
{
    int result;
    result=left+right;
    cout<<result;
    
}

int main()
{
    int x,y;
    cout<<"Enter x\n";
    cin>>x; //3
    cout<<"Enter y\n";
    cin>>y; //4

    Add(x,y);  //compiler pass VALUESSSSS Add(3,4)
    return 0;
}

/////////////////////////////////////////
//V3

//#
//using ns
int Add(int left,int right)
{
    int result;
    result=left+right;
    return result;  //compiler returns VALUEEEEE
    
    //unreachable code
    return left+right;
    int x;
}

int main()
{
    int x,y;
    cout<<"Enter x\n";
    cin>>x; //3
    cout<<"Enter y\n";
    cin>>y; //4

    Add(x,y); //pass VALUESSSSS   
    //compiler do nothing

    int result=Add(x,y);
    cout<<result;

    cout<<Add(x,y);
    
    return 0;
}

/////fn prototype//////////////////////////////////////////
//#
//using ns

//
int Add(int ,int );
int Sub(int left,int right);
int Mul(int left,int right);
int Div(int left,int right);
//
int main()
{
    Add(22,33); //
    return 0;
}
int Add(int left,int right)
{
    return left+right;
}
int Sub(int left,int right){return left-right;}
int Mul(int left,int right){return left*right;}
int Div(int left,int right){return left/right;}

//////////////////////////////////////////////////////

//Draft
// #include <stdlib.h>
// #include <windows.h>
// #include<iostream>
// using namespace std;
// void gotoxy( int column, int row )
// {
//     COORD coord;
//     coord.X = column;
//     coord.Y = row;
//     SetConsoleCursorPosition(GetStdHandle( STD_OUTPUT_HANDLE ),coord);
// }


/////////////////////////////////////////
//magic box

// #include <iostream>
// #include <stdlib.h>
// #include <windows.h>
using namespace std;
void gotoxy( int column, int row )
{
     COORD coord;
     coord.X = column;
     coord.Y = row;
     SetConsoleCursorPosition(GetStdHandle( STD_OUTPUT_HANDLE ),coord);
 }

int main()
{
    int size=3;
    
    int col;
    int row;
    row=1;
    col=size/2 +1;   //3*3 =>2    5*5=>3
    //col 1 row 3    i 1 2
    for (int i = 1; i <=size*size; i++)
    {
        gotoxy(col,row);
        cout<<i;
        //adjust coordinates for next #
        if(i % size !=0)  //reminder
        {
            row--;
            col--;
            if(col<1){col=size;}
            if(row<1){row=size;}
        }
        else  //no reminder
        {
            row++;
        }
    }
    
    return 0;
}

//////////////////////////////////////////////


////////////////////
///1,3,5,7,8,10,12     31days
///4,6,9,11           30 days
///2      28,29 leap year    2000,2004,2008,2020,2024


///while ->   do while

///1- Birthdate
///plz enter your year from 1980->2025
1900
///plz enter your year from 1973->2023
1900
///plz enter your year from 1973->2023
2001
///plz enter your month 1-12
22
///plz enter your month
23
///plz enter your month
2
///plz enter your day
31
///plz enter your day
32
///plz enter your day
32
///plz enter your day
29


///you're 22y  3 months and 5 days

int currentday=3;
int currentmonth=11;
int currentyear=2025;

int day,month,year;

//2-magic box  3*3


///3- dynamic magic box based on input 
//not eveen nor 1

//plz enter magic odd size not 1
2
//plz enter odd size
1
//plz enter odd size
44
//plz enter odd size
5
system("cls");  //clear screen



///4-Calculator add,sub,,, as a functions
///plz enter #1
//2
//plz wnter #2
//3
//plz enter operator
//*

//2*3=6
//Continue ??? y or n 
//y Enter

///plz enter #1
//5
//plz wnter #2
//10
//plz enter operator
//+
//5+10=15
//Continue ??? y or n 
//n

//program end


//////////////////////////////////////////////






