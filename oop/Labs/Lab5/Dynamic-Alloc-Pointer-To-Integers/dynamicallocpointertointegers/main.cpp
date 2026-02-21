#include <iostream>

using namespace std;

int main()
{
    int _size =3;
    int *ptr= new int[_size];
    cout<<"Enter Array items : \n" ;
    for(int i = 0 ; i<_size ; i++)
    {
        cin>>ptr[i];
    }

    cout<<"Array items V1 : \n" ;
    for(int i = 0 ; i<_size ; i++)
    {
        cout<<ptr[i]<<endl;
    }

    cout<<"Enter Array items : \n" ;
    for(int i = 0 ; i<_size ; i++)
    {
        cin>>*(ptr+i);
    }

    cout<<" Array items V2 : \n" ;
    for(int i = 0 ; i<_size ; i++)
    {
        cout<<*(ptr+i)<<endl;
    }



    return 0;
}
