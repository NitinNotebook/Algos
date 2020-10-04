using System;

namespace Algos.Search
{
    public static class BinarySearch
    {
        public static void Test()
        {
            var A = new int[] { 1, 3, 5, 8, 10, 12, 14, 15, 16 };
            var arrX = new int[] { 10, 1, 3, 16, 6};
            foreach (int x in arrX)
            {
                int index = Search(A, x);
                Console.WriteLine($"{x} is at index: {index}");
            }
        }

        public static int Search(int[] A, int x)
        {
            return RecursiveSearch(A, x, 0, A.Length);
        }

        public static int IterativeSearch(int[] A, int x)
        {
            int start = 0;
            int end = A.Length;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (A[mid] == x) return mid;

                if (x < A[mid]) //left half
                    end = mid - 1;
                else
                    start = mid + 1;
            }

            return -1;
        }
        public static int RecursiveSearch(int[] A, int x, int start, int end)
        {
            if (end < start) return -1;

            int mid = (start + end) / 2;

            if (A[mid] == x) return mid;

            if (x < A[mid]) //left half
                return RecursiveSearch(A, x, start, mid - 1);
            else
                return RecursiveSearch(A, x, mid + 1, end);
        }

    }
}
