#include <iostream>
#include <string.h>

using namespace std;

int main()
{
    int counter = 0 ;
    char arr[15];
    char name3[15]="ahmed";
    char name2[15]="mo";
    strcat(name3,name2);
    cout<<name3<<endl;

    gets(arr);

    while(arr[counter]!='\0')
    {
        counter++;
    }

    for(int i = counter-1 ; i>=0 ; i--)
    {
        cout<<arr[i];

    }

    /*
        while((ch=getche())!=13)
    {
        name[i]=ch;
        i++;
    }
    name[i]='\0';


    i=0;
    while(name[i]!='\0')
    {
        cout<<name[i];
        i++;
    }
    */
    return 0;
}
