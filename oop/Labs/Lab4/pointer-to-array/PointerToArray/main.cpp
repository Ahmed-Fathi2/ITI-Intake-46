#include <iostream>

using namespace std;

int main()
{
    int arr[3]={1,2,3};
    int *ptr=arr;

    //V1
    cout<<*ptr<<endl;
    ptr++;
     cout<<*ptr<<endl;
    ptr++;
     cout<<*ptr<<endl;
    ptr=arr;
    *ptr=10;
    ptr++;
    *ptr=20;
    ptr++;
    *ptr=30;
    ptr=arr;

    //V2

     cout<<*(ptr+0)<<endl;
     cout<<*(ptr+1)<<endl;
     cout<<*(ptr+2)<<endl;

     *(ptr+0)=10;
     *(ptr+1)=20;
     *(ptr+2)=30;

    //V3
    cout<<ptr[0]<<endl;
    cout<<ptr[1]<<endl;
    cout<<ptr[2]<<endl;

    ptr[0]=10;
    ptr[1]=20;
    ptr[2]=30;




    return 0;
}
