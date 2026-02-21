#include <iostream>

using namespace std;
struct Student
{
    int id;
    int age;
    char name[12];

};
int main()
{
    Student s1 ;

    Student *ptr = &s1;
    (*ptr).id=30;
    cout<<(*ptr).id<<endl;
    ptr->id=20;
    cout<<ptr->id<<endl;
    //ptr->name ---> Error
    gets(ptr->name);
    puts((ptr->name));

    return 0;
}
