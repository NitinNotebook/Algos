using System;
using System.Collections.Generic;

namespace Algos.Graph
{
    public static class GraphBFS
    {
        public static void Test()
        {
            List<char> path = new List<char>();
            var discoverState = new Dictionary<char, DiscoveryState>();
            var graph = GraphRepo.CreateCharGraphSample();
            BFS(graph, path, discoverState);
            Console.WriteLine($"{new string(path.ToArray())}");
        }

        public static void BFS<T>(Graph<T> graph, List<T> path, Dictionary<T, DiscoveryState> discoverState)
        {
            foreach (var v in graph.Vertices)
            {
                if (discoverState.ContainsKey(v.Val)) continue;
                BFSGraphVertex(v, path, discoverState);
            }
        }

        private static void BFSGraphVertex<T>(GraphVertex<T> start, List<T> path, Dictionary<T, DiscoveryState> discoverState)
        {
            Queue<GraphVertex<T>> queue = new Queue<GraphVertex<T>>();
            queue.Enqueue(start);
            discoverState.Add(start.Val, DiscoveryState.White);

            while (queue.Count > 0)
            {
                var v = queue.Dequeue();
                if (discoverState.ContainsKey(v.Val) && discoverState[v.Val] != DiscoveryState.White)
                    continue;

                discoverState[v.Val] = DiscoveryState.Grey;
                path.Add(v.Val);

                foreach (var e in v.Edges)
                {
                    if (!discoverState.ContainsKey(e.End.Val))
                    {
                        discoverState.Add(e.End.Val, DiscoveryState.White);
                        queue.Enqueue(e.End);
                    }
                }

                discoverState[v.Val] = DiscoveryState.Black;
            }
        }
    }
}
