#include <iostream>

using namespace std;

int main()
{
    int x ;
    int *ptr=&x;
    cout<<"Enter Value of X =  ";
    cin>>*ptr;
    cout<<"value of X = " << *ptr<<endl;
    cout<<"value of X = " << x;

    return 0;
}
