using System;

namespace Algos.Search
{
    public static class BinarySearchRotated
    {
        public static void Test()
        {
            var nums = new int[] { 3, 1 };
            SearchTest(nums, 1, 1);

            var A = new int[] { 10, 12, 14, 15, 16, 1, 3, 5, 8 };
            int rInd = NumberOfRotations(A);
            Console.WriteLine($"Number Of Rotations in A is {rInd}");

            var arrX = new int[] { 10, 1, 3, 16, 6 };
            var arrXExpected = new int[] { 0, 5, 6, 4, -1 };
            for (int i = 0; i < arrX.Length; i++)
            {
                SearchTest(A, arrX[i], arrXExpected[i]);
            }
        }

        private static void SearchTest(int[] nums, int target, int expected)
        {
            int result = Search(nums, target);
            Console.WriteLine($"{expected == result}, target={target}, expected={expected}, result={result}");
        }

        public static int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;

            int n = nums.Length;
            int start = 0;
            int end = n - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (nums[mid] == target) return mid;

                if (start == mid || nums[start] < nums[mid]) //left is sorted
                {
                    if (target >= nums[start] && target < nums[mid]) //item is in left sorted half.
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else if (nums[end] > nums[mid]) //right is sorted
                {
                    if (target > nums[mid] && target <= nums[end])
                        start = mid + 1;
                    else
                        end = mid - 1;
                }
                else
                    return -1; //array is not sorted
            }

            return -1;
        }

        public static int NumberOfRotations(int[] A)
        {
            int n = A.Length;
            int start = 0;
            int end = n - 1;

            while (start <= end)
            {
                if (A[start] < A[end]) return start;

                int mid = (start + end) / 2;
                int prev = (mid - 1 + n) % n;
                int next = (mid + 1) % n;

                if (A[prev] > A[mid] && A[next] > A[mid])
                    return mid;
                else if (A[start] < A[mid]) //left is sorted so rotation pivot is in right side
                    start = mid + 1;
                else
                    end = mid - 1;
            }

            return -1;
        }
    }
}
