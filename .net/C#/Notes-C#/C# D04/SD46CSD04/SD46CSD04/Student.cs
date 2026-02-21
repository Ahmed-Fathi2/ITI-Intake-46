using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD04
{
    struct Student
    {
        #region Data
        int id;
        string name;
        int age;
        #endregion
        #region Setters & Getters
        public void SetId(/*Student this*/int _id) {  id = _id; }
        public void SetName(string _name) { name = _name; }
        public void SetAge(int _age) { age = _age; }
        public int GetId() { return id; }
        public string GetName() { return name; }
        public int GetAge() { return age; }
        #endregion

        #region Properties [new way of setters and getters]  [fst ltr is upper case]
        public int Id
        {
            set   ///void set(int value){}
            {
                id = value;
            }
            get   ///int get(){}
            {
                return this.id;
            }
        }
        public string Name
        {
            set { name = value; }
            get {return name; } 
        }
        public int Age 
        {
            set 
            { 
                //if(age>11&& age<22)
                age = value;
            }
            get { return age; }
        }
        #endregion

        #region Print
        public string Print()
        {
            return string.Format($"{id}:{name}:{age}");
        }


        public override string ToString()
        {
            return $"{id}:{name}:{age}";
        }

        #endregion

    }
}
