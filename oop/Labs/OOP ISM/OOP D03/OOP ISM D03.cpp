//Arrays
//Variables
//Preprocessor #define
//Memory
//string V01
//struct
////////////////////////////////////////////
//#include<iostream>
//using namespace std;
int main()
{
    int x=10;
    double y=20;
    cout<< sizeof(x); //4
    cout<< sizeof(int); //4
    cout<< sizeof(y); //8
    cout<< sizeof(double); //8
    //...
    return 0; 
}
//////////////////////////////////////////////
//20 students
//5 subjects
float std1sub1;
float std1sub2;
float std1sub3;
float std1sub4;
float std1sub5;
float std2sub1;
//..
//100 variables

//solution 
//create ONE variable carries all 5 subjects
//reduce 100 into 20
//later will be ONE variable
////////////////////////////////////////////////////////////////
//Array
//Fixed-size collection of data with 
//same data type stored sequentially in memory


//Datatype variableName[arraySize];

//int arr[5];
//declare array of 5 integers
//stored sequentially in memory
//size of arr   5 * sizeof(int) B

// int arr[10];  //40B
// ///memory   arr | |1| | | |9| | | | |
// //       index   0 1 2 3 4 5 6 7 8 9
// //access arr via index

// //access => set or get

// //set
// arr[1]=1;
// arr[5]=9;
// //get
//cout<<arr[5]; //9
//int result=arr[5];
//cout<<arr[8]; //rubbish


int main()
{
    int arr[5];
    int length=sizeof(arr)/sizeof(int);

    for (int i = 0; i < 5; i++)
    {
        cout<<"Plz enter # at index"<<i<<endl;
        cin>>arr[i];
    }

    for (int i = 0; i < 5; i++)
    {
        cout<<"# at index"<<i<<"is "<<arr[i]<<endl;
    }
    
    arr[0]=10;
    arr[1]=20;
    arr[2]=30;
    arr[3]=40;
    arr[4]=50;
    cout<<arr[0];
    cout<<arr[1];
    cout<<arr[2];
    cout<<arr[3];
    cout<<arr[4];
    
    return 0;
}

int main()
{
    double darr[5]; //40B
    char carr[5];   //5B
}

////////////////////////////////////////////////
//int arr[5];
//arr itself
int main()
{
    int arr[5];
    cout<<arr;
    //address fst element of array
    //arr=0x18;
    //arr itself : address first element of array ALWAYS EVER
    ////////arr itself is constant address
    return 0;
}
////////////////////////////////////////////////
//array default value with array initialization
int main()
{
    int arr[5]; //arr|#|#|#|#|#|
    for (int i = 0; i < 5; i++)
    {
        arr[i]=0;
    }
    int arr[5]={1,2,3,4,5}; //arr|1|2|3|4|5|
    int arr[10]={1,2,3,4,5,6,7,8,9,10};
    int arr[10]={1,2,3,4,5}; //arr|1|2|3|4|5|0|0|0|0|0|
    int arr[5]={0};
    int arr[5]={1,2,3,4,5,6,7,8,9,10};
    //arr[6]=22;
    //cout<<arr[6];
    //int arr[]; //compile error
    int arr[]={1,2,3,4,5};

    // //WRONG
    // int arr[5];
    // arr={1,2,3,4,5};
    // arr[0]={1,2,3,4,5};

    // //NOT Standard
    // int size;
    // cout<<"Enter Array Size";
    // cin>>size;
    // int arr[size];


    //Compile error initialize after array declared
    //int arr[5];
    //arr={1,2,3,4,5};
    //arr=0x10;

    // //NOT STANDARD [run with codeblocks]
    // int size;
    // cout<<"Enter array size\n";
    // cin>>size;
    // int arr[size];
    // //standard way to dynamically
    // //allocate array at runtime
    // //last day

    //int arr[5]={1,,3,4,5};
}

////////////////////////////////////
//2D array
//int arr[rowSize][colSize];

//access
//arr[rowIndex][colIndex]=value

//declare 2d array of 3 rows, 4 cols
int main()
{
    int arr[3][4];
    // //3 * 4 * sizeof (int) =48B
    // arr[0][0]=1;
    // arr[0][1]=2;
    // arr[0][2]=3;
    // arr[0][3]=4;
    // arr[1][0]=5;

    for (int  i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            cout<<"Enter # at index"<<i<<","<<j<<endl;
            cin>>arr[i][j];
        }
    }
    
    for (int  i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            cout<<"# at index"<<i<<","<<j<<"is "<<arr[i][j]<<endl;
        }
    }

    for (int  i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            cout<<arr[i][j]<<"\t";
        }
        cout<<endl;
    }
    
    //calculate sum of each row
    int sum[3]={0};
    //i 0 1   j 0 1 2 3 4 0
    for (int i = 0; i < 3; i++)
    {
        for (int  j = 0; j < 4; j++)
        {
            sum[i]+=arr[i][j];
        } 
    }
    

    cout<<sum[0];
    cout<<sum[1];
    cout<<sum[2];
}


///////////////////////////////////////////////
//2d array default values
int main()
{

    int arr[3][4]={{1,1,1,1},{2,2,2,2},{3,3,3,3}};
    int arr[2][3]={{1,1,1},{2,2,2}};
    //int arr[][];//error
    int arr[][]={{1,1,1},{2,2,2},{2,2,2}};
    int arr[][]={{1},{2,2},{3,3,3},{4,4,4,4}};
    int arr[3][4]={0};
    return 0;
}
////////////////////////////////////////////
//REMEMBER
int main()
{
    int arr[3][4];
    //arr address
    //arr[0] address
    //arr[0][0] int value
}
///////////////////////////////////////////
//#define
//preprocessor

//#define make create macro data before compile time
//#define is used to create constant values or expression[macro]
//under specific name
//and you can use it whatever you want
//#define CName CValue


/////////////////////////////////////////////////
/////////////////////////////////////////////
///Variables
///1- local variable
///2- global variable
///3- static variable
///////////////////////////////////////////////////
///1- Local variable
//////variable declared inside scope {}  , ()
//////Access :any code inside/below scope
//////life time: at end of its scope
//////storage => Stack

int Add(int a,int b)//local variable
{
    a=33;
    
}
int main()
{   
    int x;
    x=22;
    
    Add(11,22);

    for (int i = 0; i < 34; i++)
    {
        i=1;
    }
    
    i=22;

    do
    {
        int result;
    }
    while();

    return 0;
}


///////////////////////////////////////////////////////
///2- Global variable
///////Variable declared outside any scope [before main]
///////access: any code in program
///////lifetime: at end of program
///////storage : Data Segment [bss]
//#include<iostream>
//using ns;
//
int x=10;
//
void PrintMe()
{
    x=20;
}
int main()
{   
    int x=-10;

    cout<<x;// -10
    cout<<::x;// 10
    //c version
    {
        extern int x;
        //x=1000;
        cout<<x;
    }
    return 0;
}
////////////////////////////////////////////////
void TryMe()
{
    int x=0;
    x++;
    cout<<x;
}
int main()
{
    TryMe();
    TryMe();
    TryMe();
}
//o/p
//1
//1
//1

///////
///3- static variable
///////////Declared ONCE and only Once in memory regardless # of called fn
///////////local variable with keyword static
///////////access:any code inside scope
///////////life time: Alive Till Program end
///////////storage: data segment bss
//////////Static variable 
//always declared with default 0


void TryMe()
{
    //execute this line at first fn call ONLY
    static int x;  
    x++;
    cout<<x;
}
int main()
{

    //int result; cout<<result; //Rubbish
    TryMe(); //1
    TryMe(); //2
    TryMe(); //3
}
////////////////////////////////////////////////
////////////////////////////////////////////////
///string:
///in cpp there is no DT called string
///despite there are many libraries
///deals with string <string.h>

///we can create string by 
//create array of characters |A|L|I||
///////////////////////////////////////////////
//<conio.h> getch()
//program to identify ascii for any key
int main()
{
    char ch;
    cout<<"Enter any key\n";
    cin>>ch; //

    cout<<"ascii ="<<(int)ch<<endl; //77
    return 0;
}
////////////////////////////////
//cin>>
//read any printed key
//continue after press enter

//program to identify ascii for any key printed or non printed

//<conio.h>
//char getch(){}
//char getche(){}
///get any key from user at runtime 
///printed or non printed
///it returns it immedietly without press enter
//<conio.h>
int main()
{
    char ch;
    cout<<"Enter ch\n";
    ch=getch();
    cout<<"ascii is "<<(int)ch;
    return 0;
}
/////////////////////////////////////////////////////////
//prpgram to create string
int main()
{
    char name[15];
    cout<<"Enter name\n";
    for (int i = 0; i < 15; i++)
    {
        cin>>name[i];
    }
    //o/p
    //AENTERhENTERmENTEReENTERdENTERENTERENTERENTERENTERENTERENTERENTERENTERENTERENTERENTER
    
}

int main()
{
    char name[15];
    cout<<"Enter name\n";
    for (int i = 0; i < 15; i++)
    {
        name[i]=getche();
    }
    //o/p
    //AhmedENTERENTERENTERENTERENTERENTERENTERENTER
}

int main()
{
    char name[15];
    char ch;
    int i=0;
    cout<<"Enter name\n";
    do
    {
        ch=getch();
        name[i]=ch;
        i++;
    }
    while(ch!=13);

    i=0;
    while(name[i]!=13)
    {
        cout<<name[i];
        i++;
    }
}




//array of characters default values
int main()
{
    char name[15]={'A','L','i'};
}

//////////////////////////////////////////

//standard terminator for string
//delimeter,zero default value for char
//'\0'


int main()
{
    char name[15];
    char ch;
    int i=0;
    cout<<"Enter name\n";
    do
    {
        ch=getch();
        name[i]=ch;
        i++;
    }
    while(ch!=13);
    name[i-1]='\0';

    i=0;
    while(name[i]!='\0')
    {
        cout<<name[i];
        i++;
    }
}

int main()
{
    char name[15];
    char ch;
    int i=0;
    while((ch=getche())!=13)
    {
        name[i]=ch;
        i++;
    }
    name[i]='\0';

    i=0;
    while(name[i]!='\0')
    {
        cout<<name[i++];
    }
    cout<<"Enter name\n";
}


////////////////////////////////////////////////
int main()
{
     char name[15];
    cout<<"Enter name";
    cin>>name;//ahmed ENTER
    cout<<name;

    return 0;
}
//#include<string.h>
int main()
{
    char name[15];
    cout<<"Enter name";
    gets(name);
    puts(name);
}

//string default values
int main()
{
    char name[15]={'a','l','i','\0'};
    //char fname[15]={'a','b','','','','','',''};
    char fname[15]="Abdelrahman";
}

////String.h Library/////
//gets(array of characters);
//puts(array of characters);
//strlen(array of charachters);
//
//
//////////////////////////////////////////////////////
/////////////////////////////////////////////////////
//store grade of 5 subjects for 20 stds
///100 variables ??? XXX
///1D array 20 variables
///2D Array  1 Variable

///STORING DATA FOR THE SAME DATA TYPE

/////issue
///store data for Employee
///int ssn
///char name[20]
///int age
///float salary

///??Question => Use Array???












///Array can store data for same data type

//////////////////////////////////////////////////////////
//Struct:
///////Data type created with my own definitions
///////Data type can carry several
/////// unrelated Data types

///struct is written in global declaration



////////////////////////////////////////////////////
//struct point 
//#include<iostream>
using namespace std;


////////////////////////////////////////////////////
///Lab Assignments [separate project]

///Arrays of 10 places of integer int arr[10]
///Read ALL Data From user in Runtime
//XXX int arr[10]={1,2,3,4,5,6,7,8,9,0};

//1D Array
//1-Array min  and max value  |7|3|5|6|8|-1|-11|33|99| no built in fn
//2-Array sort    same array            |-11|-1|3|5|6||||||no built in fn
//3-search on array and return index
 |1|2|3|4|1|5|6|2|1|9|10|

//which number you want to search
///4
//done at index 3



//5-2D Array
//array [3][4]
//calculate average of columns
//int avg[4]

//6-multiply 2 matrix
//3*2    *  2*1  =  3*1


//7-  3*3     *    3*2   =  3*2


//8- read string from user
///and then print it reversly

///enter statement
///My name is Ali
//ilA si eman yM

//
//////////////////////////////////////////////////////////







