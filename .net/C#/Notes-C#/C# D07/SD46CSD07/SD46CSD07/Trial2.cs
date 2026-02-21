using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD07
{
    public class Trial2
    {
        //Generic is applicable with
        //1-class
        //2-struct
        //3-interface
        //4-function
        //5-delegate
        //Trial<int>.Swap()
        //Trial.Swap<int>()
        public static void Swap<T>(ref T left, ref T right)
        {
            T tmp = left;
            left = right;
            right = tmp;
        }
        public static int SearchArray<T>(T[] param, T _num) 
        {
            int result = -1;
            for (int i = 0; i < param.Length; i++)
            {
                //if (param[i] == _num)
                if (param[i].Equals(_num))
                {
                    result = i;
                }
            }
            return result;
        }

        public static void SortArray<T>(T[] param) where T:IComparable
        {
            for (int i = 0; i < param.Length; i++)
            {
                for (int j = 0; j < param.Length; j++)
                {
                    //if (param[i] > param[j])
                    if (param[i].CompareTo(param[j])>0)
                        {
                        T tmp = param[i];
                        param[i] = param[j];
                        param[j] = tmp;
                    }
                }
            }
        }
    }
}
