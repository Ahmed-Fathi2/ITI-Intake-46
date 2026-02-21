#include <iostream>

using namespace std;

int main()
{
    int size = 5;
    int arr[size] = {1,5,6,4,8};
    int key , j ;


     cout<<"UnSorted Array : \n";
    for(int i = 0 ; i<size ; i++)
    {

        cout<<"arr["<<i<<"] = "<<arr[i]<<endl;
    }
    cout<<"\n\n";
    for (int i = 1 ; i < size ; i++)
    {
        key = arr[i];
        j=i-1;

        while(j>=0 && arr[j]> key)
        {
            arr[j+1]=arr[j];
            j--;
        }

        arr[j+1]= key;

    }

    cout<<"Sorted Array : \n";
    for(int i = 0 ; i<size ; i++)
    {

        cout<<"arr["<<i<<"] = "<<arr[i]<<endl;
    }
    return 0;
}
