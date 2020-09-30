using System;
using System.Net.Mail;

namespace Algos.Sort
{
    public static class MergeSort
    {
        public static void Test()
        {
            var A = new int[] { 7, 6, 2 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");

            A = new int[] { 7, 6, 2, 1, 2 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");

            A = new int[] { 7, 6, 1, 3, 2 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");

            A = new int[] { 10, 12, 14, 15, 16, 1, 3, 5, 8 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");

            A = new int[] { 1, 12, 3, 2, 16, 8, 5, 14, 2, 3, 3 };
            //A = new int[] { 1, 12, 3, 2, 16, 5, 14, 2, 3, 3 };
            Sort(A);
            Console.WriteLine($"Sorted: {string.Join(',', A)}");
        }

        public static void Sort(int[] A)
        {
            //MergeSortRecursive(A, 0, A.Length - 1);
            MergeSortIterative(A);
        }

        private static void MergeSortIterative(int[] A)
        {
            for (int step = 2; step <= A.Length; step += step)
            {
                for (int start = 0; start <= A.Length - step; start += step)
                {
                    int end = start + step - 1;
                    int mid = (start + end) / 2;
                    Merge(A, start, mid, end);

                    if (end + step > A.Length - 1 && end < A.Length - 1)
                    {
                        Merge(A, start, end, A.Length - 1);
                    }
                }
            }
        }

        private static void MergeSortRecursive(int[] A, int start, int end, int depth = 0)
        {
            Console.WriteLine($"{new String('-', depth)}({start}, {end})");
            if (start >= end)
                return;

            int mid = (start + end) / 2;

            MergeSortRecursive(A, start, mid, depth + 1);
            MergeSortRecursive(A, mid + 1, end, depth + 1);
            Merge(A, start, mid, end);
        }

        private static void Merge(int[] A, int start, int mid, int end)
        {
            if (end == start) return;

            int[] A1 = new int[1 + end - start];

            int a1P = start, a2P = mid + 1;
            for (int i = 0; i < A1.Length; i++)
            {
                if (a1P <= mid && (a2P > end || A[a1P] <= A[a2P]))
                {
                    A1[i] = A[a1P];
                    a1P++;
                }
                else
                {
                    A1[i] = A[a2P];
                    a2P++;
                }
            }

            int index = 0;
            for (int i = start; i <= end; i++)
            {
                A[i] = A1[index++];
            }
        }
    }
}
