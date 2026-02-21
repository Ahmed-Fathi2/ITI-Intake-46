#include <iostream>

using namespace std;

int main()
{
   int arr[5];
   int item;
   int index ;
   int flag=0 ;

    cout << "Enter Array Items" << endl;
    for(int i = 0 ; i< 5; i++)
    {
        cout <<"arr"<<"["<<i<<"]"<<" = ";
        cin>>arr[i];
    }

    cout <<"Enter Search Num =  ";
    cin>>item;


    for(int i = 0 ; i< 5; i++)
    {
        if(arr[i]==item)
        {
            index = i;
            cout <<"index of seaching item = "<< index;
            flag = 1 ;
            break;
        }

    }

    if(flag == 0 )
      cout<<"item Not Exist";

    return 0;
}
