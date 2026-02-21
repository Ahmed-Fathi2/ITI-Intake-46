#include <iostream>

using namespace std;

int* Try()
{
    int static arr[3]={1,2,3};
    return arr;

}

int main()
{

    int *ptr = Try();

    for(int i =0 ; i <3 ; i++)
    {
        cout<<ptr[i]<<endl;
    }



    return 0;
}
