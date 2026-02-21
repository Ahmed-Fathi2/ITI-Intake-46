using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD08
{
    public static class FilterPer
    {
        public static bool PerAge(Employee item)
        {
            return item.Age > 25;
        }


        public static bool PerName(Employee item)
        {
            return item.Name.Contains("a");
        }



        public static bool PerDeptAndSalary(Employee item)
        {
            return item.DeptId == 10 && item.Salary > 4000;
        }
        //
        //
        //
        //
        //

    }
}
