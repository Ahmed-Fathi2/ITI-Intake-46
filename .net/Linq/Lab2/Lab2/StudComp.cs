using Lab2.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Lab2
{
    class StudComp:IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            return x.Id == y.Id;
        }
        /*------------------------------------------------------------------*/
        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id;
        }
    }
}
