#include <iostream>

using namespace std;

int main()
{

   int* ptrArr[3];

   for(int i = 0 ; i<3 ; i++)
   {
       ptrArr[i]=new  int[4];
   }

   for(int i = 0 ; i<3 ; i++)
   {
       for(int j = 0 ; j<4 ; j++)
       {
        cout<<"PtrArr["<<i<<"]["<<j<<"] = ";
        cin>>  ptrArr[i][j];
       }
   }
    cout<<"Printed Lists : \n" ;
    for(int i = 0 ; i<3 ; i++)
   {
       for(int j = 0 ; j<4 ; j++)
       {
         cout<<"PtrArr["<<i<<"]["<<j<<"] = ";
         cout<< ptrArr[i][j]<<endl;
       }
   }




    return 0;
}
