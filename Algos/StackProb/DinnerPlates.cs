using System;
using System.Collections.Generic;

namespace Algos.StackProb
{
    /// <summary>
    /// You have an infinite number of stacks arranged in a row and numbered (left to right) from 0, each of the stacks has the same maximum capacity.
    /// Implement the DinnerPlates class:
    /// DinnerPlates(int capacity) Initializes the object with the maximum capacity of the stacks.
    /// void push(int val) Pushes the given positive integer val into the leftmost stack with size less than capacity.
    /// int pop() Returns the value at the top of the rightmost non-empty stack and removes it from that stack, and returns -1 if all stacks are empty.
    /// int popAtStack(int index) Returns the value at the top of the stack with the given index and removes it from that stack, and returns -1 if the stack with that given index is empty.
    /// </summary>
    public class DinnerPlates
    {
        public static void Test()
        {
            var actions = new string[] { "DinnerPlates", "push", "push", "push", "push", "push", "popAtStack", "push", "push", "popAtStack", "popAtStack", "pop", "pop", "pop", "pop", "pop" };
            var actionParam = new int[] { 2, 1, 2, 3, 4, 5, 0, 20, 21, 0, 2, -1, -1, -1, -1, -1 };
            var arrExpected = new int?[] { null, null, null, null, null, null, 2, null, null, 20, 21, 5, 4, 3, 1, -1 };
            Unittest(actions, actionParam, arrExpected);
        }

        private static void Unittest(string[] actions, int[] actionParam, int?[] expected)
        {

            List<string> result = new List<string>();
            var dp = new DinnerPlates(actionParam[0]);
            bool isPass = true;
            for (int i = 1; i < actions.Length; i++)
            {
                if (actions[i] == "push")
                {
                    dp.Push(actionParam[i]);
                    result.Add($"push({actionParam[i]})");
                }
                else if (actions[i] == "popAtStack")
                {
                    var rVal = dp.PopAtStack(actionParam[i]);
                    isPass = isPass && rVal == expected[i];
                    result.Add($"popAtStack({actionParam[i]}): {rVal == expected[i]}, {expected[i]}, {rVal}");
                }
                else if (actions[i] == "pop")
                {
                    var rVal = dp.Pop();
                    isPass = isPass && rVal == expected[i];
                    result.Add($"pop(): {rVal == expected[i]}, {expected[i]}, {rVal}");
                }
            }

            foreach (string str in result)
                Console.WriteLine(str);
        }

        public Dictionary<int, Stack<int>> StackMap = new Dictionary<int, Stack<int>>();
        int stackSize;
        int maxStacks = -1;
        int curPop = 0;
        int curPush = 0;

        public DinnerPlates(int capacity)
        {
            stackSize = capacity;
        }

        public void Push(int val)
        {
            Stack<int> stack = null;
            if (StackMap.ContainsKey(curPush))
                stack = StackMap[curPush];
            else
            {                
                stack = new Stack<int>();
                StackMap.Add(curPush, stack);
                if (curPush > maxStacks) maxStacks = curPush;
                curPop = maxStacks;
            }

            stack.Push(val);
            if (stack.Count == stackSize)
            {
                for (int i = curPush + 1; i <= maxStacks + 1; i++)
                {
                    if (!StackMap.ContainsKey(i) || StackMap[i].Count < stackSize)
                    {                       
                        curPush = i;
                        break;
                    }
                }
            }
        }

        public int Pop()
        {
            return PopAtStack(curPop);
        }

        public int PopAtStack(int index)
        {
            if (index > curPop || !StackMap.ContainsKey(index)) return -1;

            var result = StackMap[index].Pop();
            if (StackMap[index].Count == 0)
            {
                StackMap.Remove(index);
                while (curPop > 0 && !StackMap.ContainsKey(curPop))
                {
                    curPop--;
                }
            }

            if (index < curPush) curPush = index;
            return result;
        }
    }
}
