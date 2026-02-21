#include <iostream>
#include <cstring>

using namespace std;

int main()
{
    char fName[6]="Ahmed";
    char lName[6]="Fathi";
    char fullName[15];
    strcpy(fullName,fName);
    strcat(fullName," ");
    strcat(fullName,lName);
    cout<<fullName;

    return 0;
}
