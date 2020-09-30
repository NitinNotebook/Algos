using System;

namespace Algos.Sort
{
    public static class InsertionSort
    {
        public static void Test()
        {
            var A = new int[] { 10, 12, 14, 15, 16, 1, 3, 5, 8 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");
        }

        public static void Sort(int[] A)
        {
            for (int i = 1; i < A.Length; i++)
            {
                int j = i;
                while (j > 0 && A[j] < A[j - 1])
                {
                    Swap(A, j, j - 1);
                    j--;
                }
            }
        }

        public static void Swap(int[] A, int i, int j)
        {
            if (i == j) return;
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
    }
}
