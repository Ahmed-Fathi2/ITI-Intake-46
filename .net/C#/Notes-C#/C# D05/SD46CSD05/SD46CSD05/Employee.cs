using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD05
{
    class Employee
    {
        #region Traditional Way for encapsulation
        //int id;
        //string name;
        //int age;

        //public int Id
        //{
        //    get
        //    {
        //        return id;
        //    }

        //    set
        //    {
        //        id = value;
        //    }
        //}

        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }

        //    set
        //    {
        //        name = value;
        //    }
        //}

        //public int Age
        //{
        //    get
        //    {
        //        return age;
        //    }

        //    set
        //    {
        //        age = value;
        //    }
        //} 
        #endregion
        #region Automatic property discuss
        //int id;
        //public int Id
        //{
        //    set { id = value; }
        //    get { return id; }
        //}
        //float salary;
        //public float Salary
        //{
        //    set
        //    {
        //        if(value>5000&& value<50_000)
        //        salary = value;
        //    }
        //    get { return salary; }
        //}

        //////أوعى
        ////int age;
        ////public int Age { set; get; }
        #endregion


        #region Auto property [MCU]
        public int Id { get; set; } 
        public string Name { get; set; }// = "sara";
        public int Age { set; get; } //= 22;

        #endregion

        public Employee()
        {
            Id = 1;
            Name = "sara";
            Age = 22;
        }

        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}";
        }
    }

}
