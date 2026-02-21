using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD08
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }

        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}:{Salary}:{DeptId}";
        }

    }
}
