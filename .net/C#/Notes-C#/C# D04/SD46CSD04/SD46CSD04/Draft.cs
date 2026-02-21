using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD04
{
    class Draft
    {
        //                 10        20         20  
        public static int Add(int left,int middle,int right)
        {
            return left + middle + right;
        }

        public static void SwapV(int left, int right) 
        {
            int tmp=left;
            left=right;
            right=tmp;
        }

        public static void SwapR(ref int left,ref int right)
        {
            int tmp = left;
            left = right;
            right = tmp;
        }

        public static void PrintArrayV(int[] param)
        {
            Console.WriteLine($"in fn param identity {param.GetHashCode()}");
            for (int i = 0; i < param.Length; i++) 
            {
                Console.Write($"{param[i]}\t");
            }
            //
            param[0] = -1000;
            //
        }

        public static void PrintArrayR(ref int[] param)
        {
            Console.WriteLine($"in fn param identity {param.GetHashCode()}");
            for (int i = 0; i < param.Length; i++)
            {
                Console.Write($"{param[i]}\t");
            }
            //
            param[0] = -1000;
            //
        }


        public static void AddAndSub(int left,int right,out int ResAdd,out int resSub)
        {
            ResAdd = left + right;
            resSub = left - right;
        }

    }
}
