using System;

namespace Algos.Sort
{
    public static class QuickSort
    {
        public static void Test()
        {
            var A = new int[] { 10, 1, 3 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");

            A = new int[] { 4, 3 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");

            A = new int[] { 2, 3 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");

            A = new int[] { 4, 3, 2, 1 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");

            A = new int[] { 10, 12, 14, 15, 16, 1, 3, 5, 8 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");

            A = new int[] { 10, 1, 2, 3, 5 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");
        }

        public static void Sort(int[] A)
        {
            if (A == null && A.Length <= 1) return;
            Sort(A, 0, A.Length - 1);
        }

        private static void Sort(int[] A, int start, int end)
        {
            if (start >= end) return;
            int pivot = A[start];
            int i = start + 1;
            int j = end;

            while (i <= j)
            {
                while (A[i] <= pivot && i < end) i++;
                while (A[j] > pivot && j > start) j--;

                if (i < j)
                    Swap(A, i, j);
                else
                {
                    Swap(A, start, j);
                    break;
                }
            }

            Sort(A, start, j - 1);
            Sort(A, j + 1, end);
        }

        private static void Swap(int[] A, int x, int y)
        {
            int aX = A[x];
            A[x] = A[y];
            A[y] = aX;
        }
    }
}
