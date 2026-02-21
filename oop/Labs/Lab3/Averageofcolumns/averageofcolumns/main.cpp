#include <iostream>

using namespace std;

int main()
{
   int arr[3][4];
   int average[2];
   int sum=0 ;
   int counter=0 ;

    cout << "Enter Array Items" << endl;
    for(int i = 0 ; i< 3; i++)
    {
        for(int j = 0 ; j< 4; j++)
        {
            cin>>arr[i][j];
        }
    }



    for(int i = 0 ; i< 4; i++)
    {
        for(int j = 0 ; j <3; j++)
        {
         sum += arr[j][i];
        // counter++;
        }
        average[i]= sum/3;
        sum = 0 ;
        //counter= 0 ;

    }
    for(int i = 0 ; i< 4; i++)
    {
        cout <<"avg of column"<<"["<<i<<"]"<<" = " <<average[i]<<endl;
    }


    return 0;
}
