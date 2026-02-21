using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD03
{
    struct Employee
    {
        #region Data
        int id;
        string name;
        int age;
        decimal salary;
        Department d1;
        Gender g1;
        #endregion
        #region Setters&Getters
        public void SetId(int _id) { id = _id; }
        public void SetName(string _name) { name = _name; }
        public void SetAge(int _age) { age = _age; }
        public void SetSalary(decimal _salary) { salary = _salary; }
        public int GetId() { return id; }
        public string GetName() { return name; }
        public int GetAge() { return age; }
        public decimal GetSalary() { return salary; }
        public void SetDepartment(Department _d) { d1 = _d; }
        public Department GetDepartment() { return d1; }
        public void SetGender(Gender _g1) { g1 = _g1; }
        public Gender GetGender() { return g1; }
        #endregion
        #region Ctors [struct]  => initialization ONLY
        //no ctor -> o.s generate default ctor
        //paramaterized ctor -> o.s still create defauult ctor 
        public Employee()
        {
            id = 1;
            name = "Hanaa";
            age = 22;
            salary = 1234;
            d1 = new Department();
            g1 = Gender.female;
        }

        public Employee(int _id, string _name, int _age, decimal _salary,Department _d1,Gender _g1)
        {
            id = _id;
            name = _name;
            age = _age;
            this.salary = _salary;
            this.d1 = _d1;
            this.g1 = _g1;
        }
        #endregion
        #region Fn To Print
        //NOT RECOMMENDED
        public void OldPrint()
        {
            Console.WriteLine(id);
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(salary);
        }
        public string Print()
        {
            return $"{id}:{name}:{age}:{salary}:{d1.Print()}:{g1}";
        }
        #endregion
    }
}
