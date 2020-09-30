using System;

namespace Algos.Search
{
    public static class BinarySearchRotated
    {
        public static void Test()
        {
            var A = new int[] { 10, 12, 14, 15, 16, 1, 3, 5, 8 };
            int rInd = NumberOfRotations(A);
            Console.WriteLine($"Number Of Rotations in A is {rInd}");

            var arrX = new int[] { 10, 1, 3, 16, 6 };
            foreach (int x in arrX)
            {
                int index = Search(A, x);
                Console.WriteLine($"{x} is at index: {index}");
            }
        }

        public static int Search(int[] A, int x)
        {
            int n = A.Length;
            int start = 0;
            int end = n - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (A[mid] == x) return mid;

                if (A[start] < A[mid]) //left is sorted
                {
                    if (x >= A[start] && x < A[mid]) //item is in left sorted half.
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else if (A[end] > A[mid]) //right is sorted
                {
                    if (x > A[mid] && x <= A[end])
                        start = mid + 1;
                    else
                        end = mid - 1;
                }
                else
                    return -2; //array is not sorted
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
