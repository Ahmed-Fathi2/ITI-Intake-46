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

void SortEmployee(Employee * ptr , int size)
{

    Employee key;
    int j ;

    for(int i = 1 ; i < size ; i++)
    {
        key=ptr[i];
        j= i-1;

        while(j>=0 && ptr[j].GetId()> key.GetId())
        {

            ptr[j+1]=ptr[j];
            j--;
        }

        ptr[j+1]=key;
    }

}
Employee* FindEmployee(Employee* ptr, int size, int id)
{
    int start = 0;
    int last = size - 1;

    while (start <= last)
    {
        int mid = (start + last) / 2;

        if (ptr[mid].GetId() == id)
            return &ptr[mid];

        else if (id > ptr[mid].GetId())
            start = mid + 1;

        else
            last = mid - 1;
    }

    return NULL;
}



int main()
{
    int _size = 10;
    Employee e1(1,2000);
    Employee e2(3,2500);
    Employee e3(2,1500);
    Employee e4(5,1700);
    Employee e5(4,1800);
    Employee e6(6,1900);
    Employee e7(8,1950);
    Employee e8(7,4000);
    Employee e9(10,4500);
    Employee e10(9,5000);
    Employee arr[_size] = {e1 ,e2 ,e3,e4,e5,e6,e7,e8,e9,e10};




    cout<<"UnSorted Employees Due To Salary : \n";
    for(int i = 0 ; i<_size ; i++)
    {

        cout<<"arr["<<i<<"] = "<<arr[i].GetSalary()<< " &&& Id = "<<arr[i].GetId()<<endl;
    }
    cout<<"\n\n";

    SortEmployee(arr,_size);

    cout<<"Sorted Employees Due To Salary : \n";
    for(int i = 0 ; i<_size ; i++)
    {

        cout<<"arr["<<i<<"] = "<<arr[i].GetSalary()<< " &&& Id = "<<arr[i].GetId()<<endl;
    }
    cout<<"\n\n";


    Employee * ptr = FindEmployee(arr,_size,10);

    if(ptr)
      cout<< "Id ="<<ptr->GetId()<<"   &&& salary = "<<ptr->GetSalary();

    else
      cout<< "Item Not Found";

    cout<< "\n\n";













    return 0;
}
