using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD06
{
    struct Duration
    {
        int hour;
        int minute;
        int second;

        public int Hour
        {
            get
            {
                return hour;
            }

            set
            {
                hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return minute;
            }

            set
            {
                minute = value;
            }
        }

        public int Second
        {
            get
            {
                return second;
            }

            set
            {
                second = value;
            }
        }
    }
}
