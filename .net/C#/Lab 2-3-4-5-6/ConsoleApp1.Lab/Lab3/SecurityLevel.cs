using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Lab.Lab3;

[Flags]
public enum SecurityLevel
{
    guest=1,
    developer=2,
    secretary=4,
    databaseAdmin=8
}
