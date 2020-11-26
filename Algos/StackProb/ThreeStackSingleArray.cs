using System;

namespace Algos.StackProb
{
    //implement 3 stacks using single array
    public class ThreeStackSingleArray<T>
    {
        public static void Test()
        {
            var stacks = new ThreeStackSingleArray<int>(10);

            try
            {
                stacks.Push(1, 10);
                stacks.Push(2, 20);
                stacks.Push(3, 30);

                stacks.Push(1, 100);
                stacks.Push(2, 200);
                stacks.Push(3, 300);

                stacks.Push(1, 1000);
                stacks.Push(2, 2000);
                stacks.Push(3, 3000);

                stacks.Push(1, 10000);                
                stacks.Push(2, 20000);
                stacks.Push(3, 30000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            

            int j = 1;
            while (j <= 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        Console.WriteLine(stacks.Pop(j));
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                j++;
            }
        }

        public T[] TheArr;
        int stack1CurPos;
        int stack2CurPos;
        readonly int stack2Begin;
        int stack3CurPos;

        public ThreeStackSingleArray(int size)
        {
            TheArr = new T[size];
            stack1CurPos = -1;
            stack2CurPos = size / 3;
            stack2Begin = stack2CurPos;
            stack3CurPos = size;
        }

        public void Push(int stackNum, T element)
        {
            if (stackNum == 1)
            {
                if (stack1CurPos < stack2Begin)
                {
                    stack1CurPos++;
                    TheArr[stack1CurPos] = element;
                }
                else
                {
                    throw new Exception($"No more space on stack: {stackNum}");
                }
            }

            if (stackNum == 2)
            {
                if (stack2CurPos < stack3CurPos - 1)
                {
                    stack2CurPos++;
                    TheArr[stack2CurPos] = element;
                }
                else
                {
                    throw new Exception($"No more space on stack: {stackNum}");
                }
            }

            if (stackNum == 3)
            {
                if (stack3CurPos > stack2CurPos)
                {
                    stack3CurPos--;
                    TheArr[stack3CurPos] = element;
                }
                else
                {
                    throw new Exception($"No more space on stack: {stackNum}");
                }
            }
        }

        public T Pop(int stackNum)
        {
            if (stackNum == 1)
            {
                if (stack1CurPos >= 0)
                {
                    var element = TheArr[stack1CurPos];
                    stack1CurPos--;
                    return element;
                }
                else
                {
                    throw new Exception($"No elements on stack: {stackNum}");
                }
            }

            if (stackNum == 2)
            {
                if (stack2CurPos > stack2Begin)
                {
                    var element = TheArr[stack2CurPos];
                    stack2CurPos--;
                    return element;
                }
                else
                {
                    throw new Exception($"No elements on stack: {stackNum}");
                }
            }

            if (stackNum == 3)
            {
                if (stack3CurPos < TheArr.Length)
                {
                    var element = TheArr[stack3CurPos];
                    stack3CurPos++;
                    return element;
                }
                else
                {
                    throw new Exception($"No elements on stack: {stackNum}");
                }
            }

            return default;
        }

    }
}
