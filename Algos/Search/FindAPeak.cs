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
            UnitTest(new int[] { 1 }, 0);
            UnitTest(new int[] { 10, 9, 8, 7, 6 }, 0);
            UnitTest(new int[] { 1, 2, 3, 4, 5 }, 4);
            UnitTest(new int[] { 5, 17, 100, 11 }, 2);
            UnitTest(new int[] { 1, 2, 3, 1 }, 2);
            UnitTest(new int[] { 1, 2, 1, 3, 5, 6, 4 }, 5); //two peaks (1 or 5)            
        }

        private static void UnitTest(int[] A, int expected)
        {
            int result = FindPeakElement(A);
            Console.WriteLine($"{result == expected}, {expected}, {result}");
        }

        public static int FindPeakElement(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;
            
            if (nums.Length == 1) return 0;

            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (mid == 0)
                {
                    if (nums[mid] >= nums[mid + 1]) return mid;

                    start = mid + 1;
                }
                else if (mid == nums.Length - 1)
                {
                    if (nums[mid] >= nums[mid - 1]) return mid;

                    end = mid - 1;
                }
                else if (nums[mid] >= nums[mid - 1] && nums[mid] >= nums[mid + 1])
                {
                    return mid;
                }
                else if (nums[mid + 1] > nums[mid])
                {
                    start = mid + 1;
                }
                else if (nums[mid - 1] > nums[mid])
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        public static int FindPeakElement_On(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;
            int n = nums.Length;
            if (n == 1) return 0;
            if (n == 2) return nums[0] >= nums[1] ? 0 : 1;

            if (nums[0] > nums[1])
                return 0;

            for (int i = 1; i < n - 1; i++)
            {
                int prev = i - 1;
                int next = i + 1;

                if (nums[i] > nums[prev] && nums[i] > nums[next])
                    return i;
            }

            if (nums[n - 1] > nums[n - 2])
                return n - 1;

            return -1; //no peak
        }
    }
}
