using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD07
{
    public class Trial
    {
        public static void SwapI(ref int left,ref int right) 
        {
            int tmp=left;
            left=right;
            right=tmp;
        }

        public static void SwapS(ref string left, ref string right)
        {
            string tmp = left;
            left = right;
            right = tmp;
        }

        public static int SearchArray(int[] param,int _num)
        {
            int result = -1;
            for (int i = 0; i < param.Length; i++) 
            {
                if (param[i] == _num)
                {
                    result = i;
                }
            }
            return result;
        }

        public static void SortArray(int[] param)
        {
            for (int i = 0; i < param.Length; i++) 
            {
                for (int j = 0; j < param.Length; j++) 
                {
                    if (param[i] > param[j])
                    {
                        int tmp=param[i];
                        param[i]=param[j];
                        param[j]=tmp;
                    }
                }
            }
        }
    }
}
