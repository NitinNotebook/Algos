using System.Collections.Generic;

namespace Algos.StackProb
{
    public static class DailyTemperatures
    {
        /// <summary>
        /// Given a list of daily temperatures T, return a list such that, for each day in the input, tells you how many days you would have to wait until a warmer temperature. 
        /// If there is no future day for which this is possible, put 0 instead.
        /// For example, T = [73, 74, 75, 71, 69, 72, 76, 73], output: [1, 1, 4, 2, 1, 1, 0, 0].
        /// </summary>
        public static int[] NextWarmerDay(int[] T)
        {
            var stack = new Stack<int>();
            int[] result = new int[T.Length];

            for (int i = result.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && T[i] >= T[stack.Peek()])
                {
                    stack.Pop();
                }

                result[i] = stack.Count > 0 ? stack.Peek() - i : 0;
                stack.Push(i);
            }

            return result;
        }
    }
}
