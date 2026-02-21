#include <iostream>
using namespace std;

int main() {


    int arr[5];
    cout << "Enter Array Items" << endl;
    for(int i = 0 ; i< 5; i++)
    {

        cout <<"arr"<<"["<<i<<"]"<<" = ";
        cin>>arr[i];

    }

    for (int i = 0; i < 5; i++) {
        for (int j = 0; j < 5; j++) {
            if (arr[j] > arr[j + 1]) {

                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }


    for (int i = 0; i < 5; i++)
        cout << arr[i] << " ";
}
