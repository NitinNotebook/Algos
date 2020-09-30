using System;

namespace Algos.Sort
{
    public static class SelectionSort
    {
        public static void Test()
        {
            var A = new int[] { 10, 12, 14, 15, 16, 1, 3, 5, 8 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");
        }

        public static void Sort(int[] A)
        {
            for (int index = 0; index < A.Length - 1; index++)
            {
                int minInd = index;
                for (int j = index + 1; j < A.Length; j++)
                {
                    if (A[j] < A[minInd])
                        minInd = j;
                }

                Swap(A, index, minInd);
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
