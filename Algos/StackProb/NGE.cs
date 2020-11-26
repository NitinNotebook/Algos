using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos.StackProb
{
    public static class NGE
    {
        public static void Test()
        {
            UnitTest(new int[] { 4, 5, 2, 25 }, new int[] { 5, 25, 25, -1 });
            UnitTest(new int[] { 13, 7, 6, 12 }, new int[] { -1, 12, 12, -1 });
            UnitTest_2(new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 }, new int[] { -1, 3, -1 });
        }

        private static void UnitTest(int[] arr, int[] expected)
        {
            var result = NextGreatestElement(arr);
            Console.WriteLine($"{string.Join(',', result) == string.Join(',', expected)}");
        }

        //Next greatest element - NGE for a given element x is the first greater element on right side of x in array.
        //For elements which no NGE exist consider -1 as result.
        public static int[] NextGreatestElement(int[] arr)
        {
            var nge = new int[arr.Length];
            var stack = new Stack<int>(nge.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] < arr[i])
                {
                    nge[stack.Pop()] = arr[i];
                }

                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                nge[stack.Pop()] = -1;
            }
            return nge;
        }


        private static void UnitTest_2(int[] nums1, int[] nums2, int[] expected)
        {
            var result = NextGreatestElement_TwoArray(nums1, nums2);
            Console.WriteLine($"{string.Join(',', result) == string.Join(',', expected)}");
        }

        //Find all NGE numbers for nums1 elements for corresponding values in nums2. 
        public static int[] NextGreatestElement_TwoArray(int[] nums1, int[] nums2)
        {
            int[] nge = new int[nums1.Length];
            var hasMap = CreateNgeHashset(nums2);
            for (int i = 0; i < nums1.Length; i++)
            {
                nge[i] = hasMap.ContainsKey(nums1[i]) ? hasMap[nums1[i]] : -1;
            }
            return nge;
        }

private static Dictionary<int, int> CreateNgeHashset(int[] arr)
{
    var nge = new Dictionary<int, int>(arr.Count());
    var stack = new Stack<int>(arr.Length);
    for (int i = 0; i < arr.Length; i++)
    {
        while (stack.Count > 0 && arr[stack.Peek()] < arr[i])
        {
            nge.Add(arr[stack.Pop()], arr[i]);
        }

        stack.Push(i);
    }

    while (stack.Count > 0)
    {
        nge.Add(arr[stack.Pop()], -1);
    }

    return nge;
}
    }
}
