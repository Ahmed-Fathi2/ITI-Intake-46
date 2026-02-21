#include <iostream>

using namespace std;
void SwapV(int num1 , int num2)
{
    int temp = num1;
    num1= num2;
    num2=num1;

}

void SwapA(int *num1 , int *num2)
{
    int temp = *num1;
    *num1= *num2;
    *num2=temp;

}


int main()
{
    int x = 10;
    int y = 50;
    cout<<"Before Swapping"<<endl;
    cout<< "X = " << x << endl;
    cout<< "Y = " << y << endl;
    SwapV(x,y);
    cout<<"After Swapping By Value"<<endl;
    cout<< "X = " << x << endl;
    cout<< "Y = " << y << endl;


    SwapA(&x,&y);
    cout<<"After SwappingBy Address"<<endl;
    cout<< "X = " << x << endl;
    cout<< "Y = " << y << endl;

    return 0;
}
