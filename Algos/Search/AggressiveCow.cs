using Algos.Sort;
using System;

namespace Algos.Search
{
    /// <summary>
    /// Farmer John has built a new long barn, with N (2 <= N <= 100,000) stalls. 
    ///     The stalls are located along a straight line at positions x1,...,xN (0 <= xi <= 1,000,000,000).
    /// His C (2 <= C <= N) cows don't like this barn layout and become aggressive once put into a stall. 
    ///     To prevent the cows from hurting each other, FJ wants to assign the cows to the stalls, 
    ///     such that the minimum distance between any two of them is as large as possible. 
    /// What is the largest minimum distance? or Maximize the minimum distance between two occupied stalls.
    /// </summary>
    public static class AggressiveCow
    {
        public static void Test()
        {
            // FJ can put 3 cows in stalls at positions 1, 4 and 8, resulting in a minimum distance of 3.
            // 12.4...89
            UnitTest(new int[] { 1, 2, 8, 4, 9 }, 3, 3);

            //can have minimum distance of 1, if [1,2 4] barns are used.
            //12..45
            UnitTest(new int[] { 1, 2, 4, 5 }, 3, 1);

            //.2.4...8.......16 using barns [2, 8, 16]
            UnitTest(new int[] { 2, 4, 8, 16 }, 3, 6);
        }

        private static void UnitTest(int[] barns, int cows, int expected)
        {
            int actual = Solve(barns, cows);
            Console.WriteLine($"{expected == actual}, expected:{expected}, actual:{actual}");
        }

        public static int Solve(int[] barns, int cows)
        {
            int N = barns.Length;

            if (N < cows) return -1; //no possible solution

            QuickSort.Sort(barns); //input barns might not be in sorted order
            int start = barns[0];
            int end = barns[barns.Length -1];
            int result = 0;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                
                if (IsValid(barns, cows, mid))
                {
                    result = mid;
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return result;
        }

        private static bool IsValid(int[] barns, int cows, int minDistance)
        {
            cows--;//first cow is always placed at the 0th index or left most barn
            int prevBarn = barns[0];
            for (int i = 1; i < barns.Length; i++)
            {                
                if (barns[i] - prevBarn >= minDistance)
                {
                    prevBarn = barns[i];
                    cows--;
                    if (cows == 0) return true;
                }
            }

            return false;
        }
    }
}
