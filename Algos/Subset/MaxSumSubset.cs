using System;

namespace Algos.Subset
{
    /// <summary>
    ///  find a contiguous subarray with the largest sum in array A[1...n]
    /// </summary>
    public static class MaxSumSubset
    {
        public static void Test()
        {
            UnitTest(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6); //[4, −1, 2, 1]
            UnitTest(new int[] { -2, -3, 4, -1, -2, 1, 5, 3 }, 10); //[ 4, -1, -2, 1, 5, 3 ]
            UnitTest(new int[] { -2, -3, 4, -1, -2, 1, 5, -3 }, 7); //[ 4, -1, -2, 1, 5]
            UnitTest(new int[] { 31, -41, 59, 26, -53, 58, 97, -93, -23, 84 }, 187); //[59, 26, -53, 58, 97]
        }

        private static void UnitTest(int[] A, int expected)
        {
            int result = GetMaxSum(A, false);
            Console.WriteLine($"{expected == result}, Result={result}, Expected={expected}--Divide&Conquer");

            result = GetMaxSum(A, true);
            Console.WriteLine($"{expected == result}, Result={result}, Expected={expected}--Kadane");
        }

        public static int GetMaxSum(int[] A, bool useKadane = true)
        {
            if (A == null || A.Length == 0) return -1;
            if (A.Length == 1) return A[0];

            return useKadane ? Kadane(A) : DivideAndConquer(A, 0, A.Length - 1);
        }

        #region Divide And Conquer
        private static int DivideAndConquer(int[] A, int low, int high)
        {
            if (low == high)
            {
                return A[low];
            }

            int mid = low + (high - low) / 2;
            int lMax = DivideAndConquer(A, low, mid);
            int rMax = DivideAndConquer(A, mid + 1, high);
            int cMax = MaxSumCrossing(A, low, mid, high);
            if (rMax > lMax && rMax > cMax) return rMax;
            if (lMax > rMax && lMax > cMax) return lMax;
            return cMax;
        }

        private static int MaxSumCrossing(int[] A, int low, int mid, int high)
        {
            int maxLeftSuffix = int.MinValue;
            int runningTotal = 0;

            for (int i = mid; i >= low; i--)
            {
                runningTotal += A[i];
                if (runningTotal > maxLeftSuffix) maxLeftSuffix = runningTotal;
            }

            int maxRighPrefix = int.MinValue;
            runningTotal = 0;
            for (int i = mid + 1; i <= high; i++)
            {
                runningTotal += A[i];
                if (runningTotal > maxRighPrefix) maxRighPrefix = runningTotal;
            }

            return maxLeftSuffix + maxRighPrefix;
        }
        #endregion

        public static int Kadane(int[] A)
        {
            int maxSoFar = A[0];
            int maxEndingHere = A[0];

            for (int i = 1; i < A.Length; i++)
            {
                maxEndingHere += A[i];
                
                if (maxEndingHere < A[i])
                    maxEndingHere = A[i];

                if (maxEndingHere > maxSoFar)
                    maxSoFar = maxEndingHere;
            }

            return maxSoFar;
        }
    }
}
