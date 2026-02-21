using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD03
{
    struct Department
    {
        int deptId;
        string DeptName;
        public void SetDeptId(int _deptId) { deptId = _deptId; }
        public void SetDeptName(string _deptName) { DeptName = _deptName; }
        public string GetDeptName() { return DeptName; }
        public int GetDeptId() { return deptId; }


        public Department()
        {
            deptId = 10;
            DeptName = "SD";
        }
        public Department(int _deptId,string _deptName)
        {
            deptId = _deptId;
            DeptName = _deptName;
        }

        public string Print()
        {
            return $"{DeptName} department";
        }
    }
}
