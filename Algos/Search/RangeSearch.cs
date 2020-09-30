using System;

namespace Algos.Search
{
    public static class RangeSearch
    {
        public static void Test()
        {
            int[] A = new int[] { 5, 7, 7, 8, 8, 10 };
            var result = Search(A, 8);
            Console.WriteLine($"Result: {result[0] == 3 && result[1] == 4}, {string.Join(',', result)}");
        }

        private static int[] Search(int[] A, int b)
        {
            if (A == null || A.Length == 0) return new int[] { -1, -1 };
            BinarySearchRecursive(A, b, 0, A.Length - 1);
            return new int[] { leftMostIndex, rightMostIndex };
        }

        static int leftMostIndex = -1;
        static int rightMostIndex = -1;
        private static void BinarySearchRecursive(int[] A, int b, int start, int end)
        {
            if (start > end) return;

            int mid = (start + end) / 2;

            if (b == A[mid])
            {
                leftMostIndex = leftMostIndex == -1 ? mid : Math.Min(leftMostIndex, mid);
                rightMostIndex = rightMostIndex == -1 ? mid : Math.Max(rightMostIndex, mid);
            }

            if (start == end) return;

            if (b <= A[mid])
            {
                BinarySearchRecursive(A, b, start, mid - 1);
            }
            else if (b >= A[mid])
            {
                BinarySearchRecursive(A, b, mid + 1, end);
            }
        }
    }
}
