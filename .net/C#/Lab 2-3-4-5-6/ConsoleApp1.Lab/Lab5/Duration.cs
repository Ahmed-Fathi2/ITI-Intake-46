using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Lab.Lab5;
 class Duration
{

    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }


    public Duration()
    {
        Hours = Minutes=Seconds= 0;
    
    }
    public Duration( int hours , int minutes , int seconds )
    {

        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        
    }

    public Duration(int numOfSec)
    {

        Hours = numOfSec / 3600;
        Minutes = (numOfSec % 3600)/60;
        Seconds = ((numOfSec % 3600)) % 60;
 

    }



    public static Duration operator +(Duration d1, Duration d2)
    {

        Duration d = new Duration();
        d.Hours = d1.Hours + d2.Hours;
        d.Minutes = d1.Minutes + d2.Minutes;
        d.Seconds = d1.Seconds + d2.Seconds;
        return d;

    }
    public static Duration operator +(Duration d1 , int num)
    {

        var d = new Duration(num);


        return new Duration()
        {
            Hours = d1.Hours + d.Hours,
            Minutes = d1.Minutes +d.Minutes,
            Seconds = d1.Seconds + d.Seconds
        };

    }

    public static Duration operator +(int num, Duration d1)
    {
        var d = new Duration(num);


        return new Duration()
        {
            Hours = d1.Hours + d.Hours,
            Minutes = d1.Minutes + d.Minutes,
            Seconds = d1.Seconds + d.Seconds
        };

    }

    public static Duration operator ++(Duration d)
    {
        return new Duration()
        {
            Hours = d.Hours,
            Minutes = d.Minutes + 1,
            Seconds = d.Seconds
        };

    }

    public static Duration operator --(Duration d)
    {
        return new Duration()
        {
            Hours = d.Hours,
            Minutes = d.Minutes - 1,
            Seconds = d.Seconds
        };

    }

    public static bool operator> (Duration d1, Duration d2)
    {
        return ( (d1.Hours > d2.Hours) && (d1.Minutes > d2.Minutes) && (d1.Seconds > d2.Seconds) );
    }
    public static bool operator< (Duration d1, Duration d2)
    {
        return ((d1.Hours < d2.Hours) && (d1.Minutes < d2.Minutes) && (d1.Seconds < d2.Seconds));
    }

    public static bool operator>= (Duration d1, Duration d2)
    {
        return ((d1.Hours >= d2.Hours) && (d1.Minutes >= d2.Minutes) && (d1.Seconds >= d2.Seconds));
    }

    public static bool operator<= (Duration d1, Duration d2)
    {
        return ((d1.Hours <= d2.Hours) && (d1.Minutes <= d2.Minutes) && (d1.Seconds <= d2.Seconds));
    }


    public static explicit operator DateTime(Duration d)
    {

        return DateTime.Today
       .AddHours(d.Hours)
       .AddMinutes(d.Minutes)
       .AddSeconds(d.Seconds);
    }

    public override string ToString()
    {
        return $"Hours:{Hours} Minutes:{Minutes} , Seconds:{Seconds}";
    }

}
