using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD04
{
    public class Employee
    {
        #region Data
        int id;
        string name;
        int age;
        float salary;

        #endregion

        #region Properties  [MUST BE PUBLIC]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }
        public float Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }
        #endregion

        #region ctor
        public Employee()
        {
            id = 1;
            name = "Zizo";
            age = 22;
            salary = 12345f;
        }
        public Employee(int _id,string _name,int _age,float _salary)
        {
            id = _id;
            name = _name;
            age = _age;
            salary = _salary;
        }
        #endregion

        #region Print
        public override string ToString(/*Employee this*/)
        {
            return $"{this.id}:{name}:{age}:{salary}";
        }
        #endregion
    }
}
