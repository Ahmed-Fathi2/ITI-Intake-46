#include <iostream>

using namespace std;

int main()
{
    int arr1[3][2];
    int arr2[2][1];
    int Result[3][1]= {{0}};
    cout<<"Enter First Array Elements : \n";
    for(int i = 0 ; i<3 ; i++)
    {
        for(int j = 0 ; j<2 ; j++ )
        {
            cin>>arr1[i][j];

        }

    }
    cout<<"Enter Second Array Elements : \n";
    for(int i = 0 ; i<2 ; i++)
    {
        for(int j = 0 ; j<1 ; j++ )
        {
            cin>>arr2[i][j];

        }

    }



    for(int i = 0 ; i<3 ; i++)
    {
        for(int j = 0 ; j<1 ; j++ )
        {
            for(int k = 0 ; k<2 ; k++ )
            {
           Result[i][j]+=arr1[i][k]*arr2[k][j];

            }
        }

    }

    cout<<"Result Value: \n";

    for(int i = 0 ; i<3 ; i++)
    {
        for(int j = 0 ; j<1 ; j++ )
        {
            cout<<Result[i][j]<<"\n";

        }
    }


    return 0;
}
