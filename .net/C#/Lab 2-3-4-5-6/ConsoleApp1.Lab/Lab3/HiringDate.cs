using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1.Lab.Lab3;
struct HiringDate :IComparable<HiringDate>
{
    int day;
    int month;
    int year;

    public HiringDate(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }

    public int CompareTo(HiringDate other)
    {
        if (year != other.year)
            return year.CompareTo(other.year);

        if (month != other.month)
            return month.CompareTo(other.month);

        return day.CompareTo(other.day);
    }

    public override string ToString()
    {
        return $"{day:D2}/{month:D2}/{year}";
    }
}

