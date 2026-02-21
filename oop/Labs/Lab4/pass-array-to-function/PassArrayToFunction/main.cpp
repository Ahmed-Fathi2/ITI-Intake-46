#include <iostream>

using namespace std;

void PrintV1(int arr[] , int _size)
{
    for(int i = 0 ; i<_size ; i++ )
    {
        cout<<arr[i]<<endl;

    }

}

void PrintV2(int *ptr , int _size)
{
    for(int i = 0 ; i<_size ; i++ )
    {
        cout<<ptr[i]<<endl;

    }

}


int main()
{
    int arr[3] = {1,2,3};
    PrintV1(arr,3);
    PrintV2(arr,3);


    return 0;
}
