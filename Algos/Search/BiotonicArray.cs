using System;

namespace Algos.Search
{
    /// <summary>
    /// Also called mountain array. Meets below conditions
    ///     A.length >= 3
    ///     There exists some i with 0 < i < A.length - 1 such that:
    ///         A[0] < A[1] < ... A[i - 1] < A[i]
    ///         A[i]> A[i + 1] > ... > A[A.length - 1]
    /// </summary>
    public static class BiotonicArray
    {
        public static void Test()
        {
            var theArr = new MountainArray(new int[] { 1, 2, 3, 4, 5, 3, 1 });
            UnitTest(theArr, 3, 2);

            theArr = new MountainArray(new int[] { 1, 2, 3, 4, 5, 3, 1 });
            UnitTest(theArr, 1, 0);

            theArr = new MountainArray(new int[] { 0, 1, 2, 4, 2, 1 });
            UnitTest(theArr, 3, -1);

            var theArr1 = new MountainArray(new int[] { 3, 5, 3, 2, 0 });
            UnitTest(theArr1, 3, 0);            
        }

        private static void UnitTest(MountainArray mountainArr, int target, int expected)
        {
            int result = FindInMountainArray(target, mountainArr);
            Console.WriteLine($"{expected == result}, {expected}, {result}");
        }

        public static int FindInMountainArray(int target, MountainArray mountainArr)
        {
            int peak = FindPeak(mountainArr);
            int result = BinarySearch(mountainArr, peak - 1, target);
            
            if (result != -1) return result;

            return BinarySearchOnReverse(mountainArr, peak, target);
        }

        private static int FindPeak(MountainArray mountainArr)
        {
            int start = 0;
            int end = mountainArr.Length() - 1;
            
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                int midVal = mountainArr.Get(mid);

                if (mid == 0)
                {
                    return midVal > mountainArr.Get(1) ? 0 : 1;
                }
                if (mid == mountainArr.Length() - 1)
                {
                    return midVal > mountainArr.Get(mid - 1) ? mid : mid - 1;
                }

                int nextVal = mountainArr.Get(mid + 1);
                int prevVal = mountainArr.Get(mid - 1);
                
                if (midVal >= prevVal && midVal >= nextVal)
                    return mid;

                if (midVal >= prevVal)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        private static int BinarySearch(MountainArray mountainArr, int end, int target)
        {
            int start = 0;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                int midVal = mountainArr.Get(mid);
                if (midVal == target)
                    return mid;

                if (target > midVal)
                    start = mid + 1;
                else
                    end = mid - 1;
            }

            return -1;
        }

        private static int BinarySearchOnReverse(MountainArray mountainArr, int start, int target)
        {
            int end = mountainArr.Length() - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                int midVal = mountainArr.Get(mid);
                if (midVal == target)
                    return mid;

                if (target > midVal)
                    end = mid - 1;
                else
                    start = mid + 1;
            }

            return -1;
        }
    }

    public class MountainArray
    {
        int[] A;
        public MountainArray(int[] theA)
        {
            A = theA;
        }

        public int Get(int index) { return A[index]; }
        public int Length() { return A.Length; }
    }
}
