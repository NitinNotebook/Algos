using System;
using System.Collections.Generic;

namespace Algos.StackProb
{
    public class SortStack
    {
        public static void Test()
        {
            Stack<int> s1 = new Stack<int>();
            s1.Push(10);
            s1.Push(1);
            s1.Push(3);
            s1.Push(8);
            s1.Push(5);
            s1.Push(9);
            s1.Push(6);
            SortStackImpl(s1);

            while (s1.Count > 0)
            {
                Console.WriteLine(s1.Pop());
            }
        }

        public static void SortStackImpl(Stack<int> s1)
        {
            Stack<int> s2 = new Stack<int>();

            while (s1.Count > 0)
            {
                int val = s1.Pop();

                while (s2.Count > 0 && s2.Peek() < val)
                {
                    s1.Push(s2.Pop());
                }

                s2.Push(val);

                while (s1.Count > 0 && s1.Peek() < s2.Peek())
                {
                    s2.Push(s1.Pop());
                }
            }

            while (s2.Count > 0)
            {
                s1.Push(s2.Pop());
            }
        }
    }
}
