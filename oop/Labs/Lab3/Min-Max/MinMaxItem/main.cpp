#include <iostream>

using namespace std;

int main()
{

    int arr[10];
    cout << "Enter Array Items" << endl;
    for(int i = 0 ; i< 10; i++)
    {

        cout <<"arr"<<"["<<i<<"]"<<" = ";
        cin>>arr[i];

    }
    int max = arr[0] ;
    int min = arr[0];
    for(int i = 0 ; i< 10 ; i++)
    {
        if(arr[i]>max)
        {
            max = arr[i];
        }

        if(min>arr[i+1])
        {

            min= arr[i+1];
        }

    }

    cout<<"max item = " <<max<<endl ;
    cout<<"min item = " <<min ;



    return 0;
}
