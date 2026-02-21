using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EventExample02
{
    public class UnderBalancedEventArgs:EventArgs
    {
        public decimal  Difference { get; set; }
        public DateTime TimeStamp { get; } = DateTime.Now;
    }
}
