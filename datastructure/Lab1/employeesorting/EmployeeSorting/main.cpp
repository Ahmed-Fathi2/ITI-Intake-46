#include <iostream>

using namespace std;

class Employee
{
    private:
    int id ;
    int salary ;
    public:
    void SetId(int _id)
    {
        id = _id;
    }
    int GetId()
    {

        return id;
    }

     void SetSalary(int _salary)
    {
        salary = _salary;
    }
    int GetSalary()
    {

        return salary;
    }
    Employee()
    {

        id = salary = 0 ;
    }

    Employee(int _id , int _salary)
    {
        id = _id;
        salary = _salary;
    }

};

void OrderEmployee(Employee * ptr, int size)
{
    Employee key ;
    int j ;
     for (int i = 1 ; i < size ; i++)
    {
        key = ptr[i];
        j=i-1;

        while(j>=0 && ptr[j].GetSalary()> key.GetSalary())
        {
            ptr[j+1]=ptr[j];
            j--;
        }

        ptr[j+1]= key;

    }

}
int main()
{
    Employee e1(1,2000);
    Employee e2(2,2500);
    Employee e3(3,1500);
    Employee arr[3] = {e1 ,e2 ,e3};



    cout<<"UnSorted Employees Due To Salary : \n";
    for(int i = 0 ; i<3 ; i++)
    {

        cout<<"arr["<<i<<"] = "<<arr[i].GetSalary()<<endl;
    }
    cout<<"\n\n";


    OrderEmployee(arr,3);

    cout<<"Sorted Array : \n";
    for(int i = 0 ; i<3 ; i++)
    {

        cout<<"arr["<<i<<"] ---->> Salary = "<<arr[i].GetSalary()<<" &&& Id = "<<arr[i].GetId() << endl;
    }



    return 0;
}
