using System;

namespace Algos.Search
{
    public static class InterpolatedSearch
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
            int high = A.Length - 1;

            while (low <= high && x >= A[low] && x <= A[high])
            {
                if (low == high)
                {
                    if (x == A[low]) return low;
                    return -1;
                }

                int mid = low + (x - A[low]) * (high - low) / (A[high] - A[low]);
                if (A[mid] == x) return mid;

                if (x > A[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }
    }
}
