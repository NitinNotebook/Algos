using System;

namespace Algos.Search
{
    public static class ExponentialSearch
    {
        public static void Test()
        {
            var A = new int[] { 1, 3, 5, 8, 10, 12, 14, 15, 16 };
            var arrX = new int[] { 10, 1, 3, 16, 6 };
            foreach (int x in arrX)
            {
                int index = Search(A, x);
                Console.WriteLine($"{x} is at index: {index}");
            }
        }

        public static int Search(int[] A, int x)
        {
            int low = 0;
            int high = 1;
            while (low <= high)
            {
                if (x == A[low]) return low;

                if (x > A[high])
                {
                    low = high + 1;
                    high += high; //double everytime
                }
                else if (x > A[low] || high >= A.Length)
                {
                    return BinarySearch.RecursiveSearch(A, x, low + 1, Math.Min(high, A.Length - 1));
                }
                else
                    return -1;
            }

            return -1;
        }
    }
}
