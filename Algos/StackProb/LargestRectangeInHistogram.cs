using System;
using System.Collections.Generic;

namespace Algos.StackProb
{
    public class LargestRectangeInHistogram
    {
        public static void Test()
        {
            UnitTest(new int[] { 2, 1, 5, 6, 2, 3 }, 10);
            UnitTest(new int[] { 2, 1, 2 }, 3);
        }

        private static void UnitTest(int[] heights, int expected)
        {
            int result = LargestRectangleArea(heights);
            Console.WriteLine($"{expected == result}");
        }

        public static int LargestRectangleArea(int[] heights)
        {            
            int maxHeight = heights[0];
            Stack<int[]> stack = new Stack<int[]>();
            for (int i = 0; i < heights.Length; i++)
            {
                int start = i;
                while (stack.Count > 0 && stack.Peek()[1] > heights[i])
                {
                    var bar = stack.Pop();
                    maxHeight = Math.Max(maxHeight, bar[1] * (i - bar[0]));
                    start = bar[0];
                }

                stack.Push(new int[] { start, heights[i] });
            }

            while (stack.Count > 0)
            {
                var bar = stack.Pop();
                maxHeight = Math.Max(maxHeight, bar[1] * (heights.Length - bar[0]));
            }

            return maxHeight;
        }
    }
}
