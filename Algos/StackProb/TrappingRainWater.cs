using System;

namespace Algos.StackProb
{
    class TrappingRainWater
    {

        public static void Test()
        {

            UnitTest(new int[] { 4, 2, 0, 3, 2, 5 }, 9);

            UnitTest(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6);
        }

        private static void UnitTest(int[] hieghts, int expected)
        {
            int result = Trap(hieghts);
            Console.WriteLine($"{expected == result}, {expected} == {result}");
        }

        public static int Trap(int[] height)
        {
            var lMax = new int[height.Length];
            var rMax = new int[height.Length];

            lMax[0] = height[0];
            rMax[height.Length - 1] = height[height.Length - 1];            
            for (int i = 1; i < height.Length; i++)
            {
                lMax[i] = Math.Max(lMax[i - 1], height[i]);
                rMax[height.Length - 1 - i] = Math.Max(rMax[height.Length - i], height[height.Length - i - 1]);
            }

            int result = 0;
            for (int i = 0; i < height.Length; i++)
            {
                result += Math.Min(lMax[i], rMax[i]) - height[i];
            }
            return result;
        }
    }
}
