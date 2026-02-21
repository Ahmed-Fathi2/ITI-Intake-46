#include <iostream>
#include <stdlib.h>
#include <windows.h>

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
    int _size=3;
    int row;
    int column;
    row=1;
    column=(_size/2)+1;
    for(int i=1 ;i<=_size*_size ;i++)
    {
        gotoxy(column,row);
        cout<<i;
        if(i%_size!=0)
        {
            row--;
            column--;
            if(row<1)row=_size;
            if(column<1)column=_size;

        }
        else
        {
            row++;
        }

    }

    return 0;
}
