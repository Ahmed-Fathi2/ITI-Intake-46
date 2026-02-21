using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD08
{
    public static class Filtration
    {
        public static List<Employee> FilterPerDeptId(List<Employee> param)
        {
            var result = new List<Employee>();
            foreach (Employee item in param)
            {
                if (item.DeptId == 10)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Employee> FilterPerSalary(List<Employee> param)
        {
            var result = new List<Employee>();
            foreach (Employee item in param)
            {
                if (item.Salary>5000)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Employee> FilterPerName(List<Employee> param)
        {
            var result = new List<Employee>();
            foreach (Employee item in param)
            {
                if (item.Name.ToLower().Contains("m"))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Employee> FilterPerAny(List<Employee> param)
        {
            var result = new List<Employee>();
            foreach (Employee item in param)
            {
                if (FilterPer.PerDeptAndSalary(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //open close principle
        public static List<Employee> FilterPerDelegate(List<Employee> param,MyDelegate del)
        {
            var result = new List<Employee>();
            foreach (Employee item in param)
            {
                if (del.Invoke(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
