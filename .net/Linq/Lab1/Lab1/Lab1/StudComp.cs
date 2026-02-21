using Lab1.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Lab1
{
    class StudComp:IEqualityComparer<Student>
    {
        /*------------------------------------------------------------------*/
        public bool Equals(Student? x, Student? y)
        {
            return x.Id == y.Id;
        }
        /*------------------------------------------------------------------*/
        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.Id;
        }
    }
}
