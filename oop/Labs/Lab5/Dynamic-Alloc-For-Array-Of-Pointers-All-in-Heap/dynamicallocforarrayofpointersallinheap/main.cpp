#include <iostream>

using namespace std;

int main()
{
    int **ptr= new int*[3];

   for(int i = 0 ; i<3 ; i++)
   {
       ptr[i]=new int[4];
   }

   for(int i = 0 ; i<3 ; i++)
   {
       for(int j = 0 ; j<4 ; j++)
       {
        cout<<"ptr["<<i<<"]["<<j<<"] = ";
        cin>>  ptr[i][j];
       }
   }
    cout<<"Printed Lists : \n" ;
    for(int i = 0 ; i<3 ; i++)
   {
       for(int j = 0 ; j<4 ; j++)
       {
         cout<<"ptr["<<i<<"]["<<j<<"] = ";
         cout<< ptr[i][j]<<endl;
       }
   }

    return 0;
}
