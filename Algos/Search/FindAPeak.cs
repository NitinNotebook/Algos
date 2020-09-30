using System;

namespace Algos.Search
{
    //Given an array of integers A, find and return the peak element in it.
    //An array element is peak if it is NOT smaller than its neighbors.
    //For corner elements, we need to consider only one neighbor.
    //For example, for input array {5, 10, 20, 15}, 20 is the only peak element.

    //Following corner cases give better idea about the problem.
    //If input array is sorted in strictly increasing order, the last element is always a peak element.
    //      For example, 5 is peak element in { 1, 2, 3, 4, 5}.
    //If input array is sorted in strictly decreasing order, the first element is always a peak element.
    //      10 is the peak element in { 10, 9, 8, 7, 6}.
    public static class FindAPeak
    {
        public static void Test()
        {
            UnitTest(new int[] { 10, 9, 8, 7, 6 }, 10);
            UnitTest(new int[] { 1, 2, 3, 4, 5 }, 5);
            UnitTest(new int[] { 5, 17, 100, 11 }, 100);            
        }

        private static void UnitTest(int[] A, int expected)
        {
            int result = FindPeak(A);
            Console.WriteLine($"{result == expected}, {expected}, {result}");
        }

        public static int FindPeak(int[] A)
        {
            if (A == null || A.Length == 0) return -1;
            int n = A.Length;
            if (n == 1) return A[0];
            if (n == 2) return Math.Max(A[0], A[1]);

            if (A[0] > A[1])
                return A[0];

            for (int i = 1; i < n - 1; i++)
            {
                int prev = i - 1;
                int next = i + 1;

                if (A[i] > A[prev] && A[i] > A[next])
                    return A[i];
            }

            if (A[n - 1] > A[n - 2])
                return A[n - 1];

            return -1; //no peak
        }
    }
}
