///d02
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
    cout<<"plz enter grade\n";
    cin>>grade;

    if(grade>=85)
    {
        cout<<"A";
    }
    else if(grade >=75 && grade<85)
    {
        cout<<"B";
    }
    else if(grade >=65 && grade<75)
    {
        cout<<"B";
    }
    //
    else
    {
        cout<<"invalid input";
    }
    return 0;
}
////////////////////////////
int main()
{
    int month;
    cout<<"Enter month #\n";
    cin>>month; //14

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
    //
    //
    //
    //
    //
    //
    //
    //
    else
    {
        cout<<"Invalid input";
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
    cin>>month;
    switch(month)//4
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
    return 0;
}

///////////////////////////////////////////////
int main()
{
    char grade;
    cout<<"Enter grade"<<endl;
    cin>>grade; //a

    switch(grade)
    {
        case 'A':
        case 'a':
        cout<<"Excellent\n";
        break;  //forgot -> fall through another case
        case 'B':
        case 'b':
        cout<<"V Good\n";
        break;
        case 'C':
        case 'c':
        cout<<"Good\n";
        break;
        case 'D':
        case 'd':
        cout<<"Fair\n";
        break;
        default:
        cout<<"Invalid\n";
        break;
    }
    return 0;
}
////////////////////////////////////////////////////

// cout<<"Hello SD and OS\n";
// cout<<"Hello SD and OS\n";
// cout<<"Hello SD and OS\n";
// cout<<"Hello SD and OS\n";
// cout<<"Hello SD and OS\n";

//copy and paste -> bad programming
//effort redundant
//1-cost of declaration
//1-cost of modifications

//for loop

// for(initial value;condition[true];increment/decrement)
// {
//     //code here if condition is true
// }

int main()
{
    //   #1     #2#5  #4
    for(int i=1; i<6 ;i++)
    {
        //#3
        cout<<"Hello SD & OS\n";
    }
    //memory  i 1 2 3 4 5 6
    //o/p
    //hello sd & os
    //hello sd & os
    //hello sd & os
    //hello sd & os
    //hello sd & os

    for(int i=10;i>0;i--){}

    return 0;
}
///////////////////////////////////////////////////
//Some Practice
int main()
{
    int age=10;
    if(age=0)
    {
        cout<<"T"<<age;
    }
    else
    {
        cout<<"F";
    }
    //memory age |20|
    for(int i=0;i<10;i++);
    {
        //code here
    }

}
////////////////////////////////////////////////
//nested for loop
int main()
{
    for(int i=0;i<3;i++)
    {
        for (int j = 0; j < 4; j++)
        {
            cout<<i<<","<<j<<endl;
        }
    }
    //memory i 0 1 | j 0 1 2 3 4 0
    //o/p
    //0,0
    //0,1
    //0,2
    //0,3
    //1,0

    for(int i=0,j=0; i>10 || j<11 ;i++,j--)
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
// }while(condition[true]);

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
        cin>>num; //10   70   -100  1000
        container+=num;
        cout<<"debug"<<container<<endl;
    }
    while(container < 100);
    cout<<"container="<<container;

    return 0;
}

int main()
{
    int container=0;
    int num;

    while(container < 100)
    {
        cout<<"Enter #\n";
        cin>>num; //10   70   -100  1000
        container+=num;
        cout<<"debug"<<container<<endl;
    }
    
    cout<<"container="<<container;

    return 0;
}



///plz enter age betw 18 and 60
//i need age to be initialized first
//then to check it

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
    while(age <18 || age>60);
    cout<<"age="<<age<<endl;  //22


    int evenNum;

    do
    {   

        cout<<"Enter even #\n";
        cin>>evenNum; //10
    }
    while(evenNum %2!=0);
    cout<<"even # is "<<evenNum<<endl;  //10
    return 0;
}
////////////////////////////////////////////////
//function

int main()
{
    cout<<"Hello";
    cout<<"Good morning";
    cout<<"Good Bye";
    cout<<"------------";
    //
    //
    //
    //
    //
    cout<<"Hello";
    cout<<"Good morning";
    cout<<"Good Bye"
    cout<<"------------";
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
    cout<<"------------";
    return 0;
}

//solution 
//for loop

//function:
//group of code togrther with specific name
//when to use this code, call that name

// //syntax
// ReturnType FunctionName(input parameter/s)
// {
//     //code here
// }

///ReturnType
///fn return nothing -> void
///if fn returns anythig but void,
///it must enclosed by keyword [return]




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
    //to call fn
    TryMe();
    //
    //
    //
    TryMe();
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
    int result;
    int x,y;
    cout<<"Enter x\n";
    cin>>x;  //3
    cout<<"Enter y\n";
    cin>>y;  //4
    result=x+y;
    cout<<"x+y="<<result<<endl;
}

int main()
{
    Add();  //o/p 7
    return 0;
}

///////////////////////////////////////////////
//SOLID Principles
//S->Single Responsibility
///////////////////////////////////////////////
//V2

//#
//using ns

void Add(int left,int right)
{
    int result;
    result=left+right;
    cout<<"result="<<result<<endl;
}

int main()
{
    int x,y;
    cout<<"Enter x\n";
    cin>>x;  //3
    cout<<"Enter y\n";
    cin>>y;  //4
    Add(x,y);   
    //compiler pass VALUES
    //Add(3,4); 
    return 0;
}

/////////////////////////////////////////
//V3

//#
//using ns

int Add(int left,int right)
{
    //int result;
    //result=left+right;
    //return result; //compiler returns VALUE  return 7;
    
    return left+right;  
    
    // //unreachable code
    // int abc=10;
    // cout<<abc;
}

int main()
{
    int x,y;
    cout<<"Enter x\n";
    cin>>x;  //3
    cout<<"Enter y\n";
    cin>>y;  //4
    Add(x,y);  //do nothing
    
    int z=Add(x,y);
    cout<<z;

    cout<<Add(x,y);

    return 0;
}

///////////////////////////////////////////////////
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
//////////////////////////////////////////////////////
//magic box example


//#include <stdlib.h>
//#include <windows.h>
//#include<iostream>
//using namespace std;
void gotoxy( int column, int row )
{
    COORD coord;
    coord.X = column;
    coord.Y = row;
    SetConsoleCursorPosition(GetStdHandle( STD_OUTPUT_HANDLE ),coord);
}
int main()
{
    int size;
    int row;
    int col;
    size=3;
    row=1;
    col=size/2 +1;

    for(int i=1;i<=size*size;i++)
    {
        gotoxy(col,row);
        cout<<i;
        //process before i became 2
        if(i%size!=0) //reminder
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
        //
    }

    return 0;
}


///////////////////////////////////////////////////
///lab assignments

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
2000
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

int currentday=20;
int currentmonth=10;
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



