using System;
using System.Collections.Generic;

namespace Algos.DP
{
    /// <summary>
    /// You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed,
    /// the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and 
    /// it will automatically contact the police if two adjacent houses were broken into on the same night.
    ///    Given a list of non-negative integers representing the amount of money of each house, 
    ///    determine the maximum amount of money you can rob tonight without alerting the police.
    /// </summary>
    public static class RobHouse
    {
        public static void Test()
        {
            UnitTest(new int[] { 1, 2, 3, 1 }, 4);
            UnitTest(new int[] { 2, 7, 9, 3, 1 }, 12);
            UnitTest(new int[] { 114, 117, 207, 117, 235, 82, 90, 67, 143, 146, 53, 108, 200, 91, 80, 223, 58, 170, 110, 236, 81, 90, 222, 160, 165, 195, 187, 199, 114, 235, 197, 187, 69, 129, 64, 214, 228, 78, 188, 67, 205, 94, 205, 169, 241, 202, 144, 240 }, 4173);
        }

        private static void UnitTest(int[] nums, int expected)
        {
            int result = Rob(nums);

            if (result == expected)
                Console.WriteLine("Passed Recursive");
            else
                Console.WriteLine($"{result == expected}, result={result}, expected={expected}, {string.Join(',', nums)}");

            result = RobTopdown(nums);
                        
            if (result == expected)
                Console.WriteLine("Passed TopDown");
            else
                Console.WriteLine($"{result == expected}, result={result}, expected={expected}, {string.Join(',', nums)}");
        }

        public static int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            houseMax = new Dictionary<int, int>();
            return RobRecursive(nums, 0);
        }


        private static int RobTopdown(int[] nums)
        {
            int tMinus2 = nums[0];
            int tMinus1 = Math.Max(nums[0], nums[1]);
            int tMax = tMinus1;
            for (int i = 2; i < nums.Length; i++)
            {
                tMax = Math.Max(tMinus1, nums[i] + tMinus2);
                tMinus2 = tMinus1;
                tMinus1 = tMax;
            }
            return tMax;
        }

        static Dictionary<int, int> houseMax;
        private static int RobRecursive(int[] nums, int startHouse)
        {
            if (startHouse >= nums.Length) return 0;

            if (houseMax.ContainsKey(startHouse)) return houseMax[startHouse];

            int p1 = RobRecursive(nums, startHouse + 2) + nums[startHouse];
            int p2 = RobRecursive(nums, startHouse + 1);
            p1 = Math.Max(p1, p2);

            houseMax.Add(startHouse, p1);
            return p1;
        }
    }
}
