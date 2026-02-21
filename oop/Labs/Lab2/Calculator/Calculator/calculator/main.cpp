#include <iostream>

using namespace std;

void Calculate(int num1, int num2 , char oper )
{
    int result ;
    switch(oper)
    {
    case '+':
     result = num1+num2;
    break;
      case '-':
     result = num1-num2;
    break;
      case '*':
     result = num1*num2;
    break;
    default:
     result= num1/num2;
    }

    cout<< "Result = "<<num1<<oper<<num2<<" = "<<result<<endl;


}
int main()
{
    int num1;
    int num2;
    char oper;
    char Continue ;

    do{
    cout << "plz enter #1" << endl;
    cin>>num1;

    do
    {
    cout << "plz enter #2" << endl;
    cin>>num2;

    cout << "plz enter operator" << endl;
    cin>>oper;

    if((num2==0)&&(oper=='/'))
        cout<<"Can't Divide By Zero , Enter the Second Number Again"<<endl;
    }while(((num2==0)&&(oper=='/')));


    Calculate(num1,num2,oper);

    cout << "Continue ??? y or n " << endl;
    cin>>Continue;
    }while(Continue=='y');
    return 0;
}
