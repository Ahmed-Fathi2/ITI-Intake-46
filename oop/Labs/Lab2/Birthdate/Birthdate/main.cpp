#include <iostream>

using namespace std;

int CalculateDayCount(int month , int year)
{
    if(month==1||month==3||month==5||month==7||month==8||month==10||month==12)
        return 31 ;
    else if (month==4||month==6||month==9||month==11)
        return 30 ;
    return(month==2&&(year%4 == 0 && (year%100 != 0 || year%400 == 0)))? 29:28 ;


}

int main()
{
    int currentday=9;
    int currentmonth=11;
    int currentyear=2025;

    int day,month,year;
    int dayage,monthage,yearage;

    do
    {
      cout<<"plz enter your year from 1980 to 2025 \n";
      cin>>year;
    } while(year<1980 || year>2025);

      do
    {
      cout<<"plz enter your month 1-12 \n";
      cin>>month;
    } while(month<1 || month>12);

    int daycount = CalculateDayCount(month,year) ;

    do
    {
      cout<<"plz enter your Day  \n";
      cin>>day;

    } while((day<1)||(day>daycount));

    if (currentday < day)
    {
        currentmonth -= 1;
        int days= CalculateDayCount(currentmonth,currentyear);
        currentday += days;

    }


    if (currentmonth < month)
    {
        currentyear -= 1;
        currentmonth += 12;
    }

    dayage = currentday - day;
    monthage = currentmonth - month;
    yearage = currentyear - year;


    cout<<"you're  "<<yearage<<"y  "<<monthage<<"  months and  "<<dayage <<"  days" ;

    return 0;
}


