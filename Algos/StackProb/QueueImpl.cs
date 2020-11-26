using System;
using System.Collections.Generic;

namespace Algos.StackProb
{
    public class QueueImpl<T>
    {
        public static void Test()
        {
            var queue = new QueueImpl<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(5);
            queue.Enqueue(6);
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(7);
            queue.Enqueue(8);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

        }

        private readonly Stack<T> S1 = new Stack<T>();
        private readonly Stack<T> S2 = new Stack<T>();

        public void Enqueue(T t)
        {
            S1.Push(t);
        }

        public T Dequeue()
        {
            if (S2.Count == 0)
            {
                if (S1.Count == 0)
                {
                    throw new Exception("Queue is empty");
                }

                while (S1.Count > 0)
                    S2.Push(S1.Pop());
            }

            return S1.Pop();
        }
    }
}
