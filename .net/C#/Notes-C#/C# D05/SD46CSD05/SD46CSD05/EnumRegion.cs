using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD05
{
    
    enum DayName
    {
        Fri=1,Sat=0x2,Sun=0b11,Mon,Tue,Wed,Thu ,ABC=7
    }

    [Flags]
    enum Position
    {
        DBA=1,
        Secretary=0b10,
        Developer=0x4,
        Tester=8,
        SWArchitect=16,
        Admin=0b11111
    }
}
