#include <iostream>

using namespace std;

class Employee
{
 private:
 float salary;
 int code;
 public:
   Employee *pNext;
   Employee *pPervious;
   Employee()
   {
    code = 0;
    salary = 0;
    pNext=NULL;
    pPervious =NULL;
   }
  Employee(int _code,  float _salary)
   {
    code   =  _code;
    salary = _salary ;
    pNext=NULL ;
    pPervious =NULL;

   }

   float GetSalary()
   {
       return salary;
   }
void printEmployee()
{
    cout<<"Code = " << code <<"\t&&& Salary = " <<salary<<endl ;
}
 };


class LinkedList
{
 protected:
  Employee *pStart;
  Employee *pEnd;

 public:
 LinkedList()
 {
     pStart=pEnd=NULL;
 }

 };




class Stack:public LinkedList
{
    public:
    void Push(Employee *pItem)
    {
    if (!pStart)
     {
       pItem->pNext = NULL;
       pItem->pPervious = NULL;
       pStart = pEnd = pItem;
     }
   else
    {
       pEnd->pNext = pItem;
       pItem->pPervious = pEnd;
       pItem->pNext = NULL;
       pEnd = pItem;
     }
   }


    Employee* Pop()
    {
        Employee* item =  pEnd;

        if(pEnd)
        {
            if(pEnd==pStart)
            {
                pEnd=pStart = NULL;
            }

            else
            {
                pEnd= pEnd->pPervious;
                pEnd->pNext= NULL;
            }
          return item;
        }
        else
          return NULL;

    }


    void displayAll()
    {
        Employee *pItem = pStart;
        while(pItem)
        {
            pItem->printEmployee();
            pItem=pItem->pNext;
        }

    }



};

int main()
{
    Stack s1 ;

    Employee *e1 = new Employee(101, 5000.5);
    Employee *e2 = new Employee(102, 6000.75);
    Employee *e3 = new Employee(103, 7000.25);
    Employee *e4 = new Employee(104, 8000.00);



    s1.Push(e1);
    s1.Push(e2);
    s1.Push(e3);
    s1.Push(e4);

    cout << "\n All Employees:\n";
    s1.displayAll();

    Employee* ptr =  s1.Pop();

    if(ptr)
    {
        cout<< "\n\nPoped Item";
        ptr->printEmployee();
    }
    else
    {
            cout<<"\n\nEmpty Stack";
    }

    Employee* ptr2 = s1.Pop();
    Employee* ptr3 = s1.Pop();
    Employee* ptr4 = s1.Pop();
    Employee* ptr5=  s1.Pop();


    if(ptr5)
    {
        cout<< "\n\nPoped Item";
        ptr5->printEmployee();
    }
    else
    {
            cout<<"\n\nEmpty Stack\n\n";
    }

    Employee *e5= new Employee(105, 6500.00);
    Employee *e6 = new Employee(106, 8500.00);

    s1.Push(e5);
    s1.Push(e6);


    cout << "\n All Employees:\n";
    s1.displayAll();




    return 0;
}

