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


class LinkedList  {
 protected:
  Employee *pStart;
  Employee *pEnd;

 public:
 LinkedList()
 {
     pStart=pEnd=NULL;
 }
     void addList(Employee *pItem);
     void addFirst(Employee *pItem);
     void addmiddle(Employee *pItem,Employee *firstNode,Employee *secondNode);
     void InsertList(Employee *pItem);
     Employee* searchList(int Code);
     int DeleteList(int Code);
     void freeList();
     void displayAll();
   //  void Sort();
     //void Swap(Employee* e1,Employee* e2);

 };
  void LinkedList :: addList(Employee *pItem) {
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

  void LinkedList :: addFirst(Employee *pItem)
  {
        pItem->pPervious = NULL;
        pItem->pNext =pStart;
        pStart->pPervious= pItem;
        pStart=pItem ;
  }

  void LinkedList :: addmiddle(Employee *pItem,Employee *firstNode,Employee *secondNode)
  {
        pItem->pPervious= firstNode;
        pItem->pNext= secondNode;
        firstNode->pNext=pItem;
        secondNode->pPervious=pItem;
  }

  void LinkedList ::displayAll()
  {
    Employee *pItem = pStart;
    while(pItem)
    {
        pItem->printEmployee();
        pItem=pItem->pNext;
    }


  }
/*
 void LinkedList ::Swap(Employee* e1,Employee* e2)
 {

    Employee* temp = e2->pNext;
    e2->pPervious = e1->pPervious;
    e2->pNext= e1;

    e1->pPervious=e2;
    temp->pPervious=e1;

    e1->pPervious= e2;
    e1->pNext= temp;
 }
   void LinkedList ::Sort()
   {
       Employee *ptr = pStart->pNext;
       Employee *key;
       Employee *j;

       while(ptr)
       {
       key= ptr;
       j = ptr->pPervious;

       while(j &&(j->GetSalary() > key->GetSalary()))
       {
           Swap(j,key);
           j= j->pPervious;
       }

           ptr=ptr->pNext;

       }
   }
   */



int main()
{
    LinkedList myList;


    Employee *e1 = new Employee(101, 5000.5);
    Employee *e2 = new Employee(102, 6000.75);
    Employee *e3 = new Employee(103, 7000.25);
    Employee *e4 = new Employee(104, 8000.00);

    myList.addList(e1);


    myList.addList(e2);


    myList.addFirst(e3);

    myList.addmiddle(e4, e1, e2);


    cout << "\n All Employees:\n";
    myList.displayAll();


   // myList.Sort();

   // cout << "\n All Sorted Employees:\n";
    //myList.displayAll();
    return 0;
}

