using System;
using System.Collections.Generic;

namespace Algos.Graph
{
    /// <summary>
    /// White - Node not discovered
    /// Grey - Discovered but not all edges processed
    /// Black - Finished processing all edges
    /// </summary>
    public enum DiscoveryState { White, Grey, Black};
    public class GraphDFS
    {
        public static void Test()
        {
            List<char> path = new List<char>();
            var discoverState = new Dictionary<char, DiscoveryState>();
            var graph = GraphRepo.CreateCharGraphSample();
            DFS(graph, path, discoverState);
            Console.WriteLine($"{new string(path.ToArray())}");
        }
        
        public static void DFS<T>(Graph<T> graph, List<T> path, Dictionary<T, DiscoveryState> discoverState)
        {
            foreach (var v in graph.Vertices)
            {
                if (discoverState.ContainsKey(v.Val))
                {
                    if (discoverState[v.Val] == DiscoveryState.Black) continue;
                }
                else
                {
                    discoverState.Add(v.Val, DiscoveryState.White);
                    path.Add(v.Val);
                }
                DFSGraphVertex(v, path, discoverState);
            }
        }

        public static void DFSGraphVertex<T>(GraphVertex<T> v, List<T> path, Dictionary<T, DiscoveryState> discoverState)
        {
            discoverState[v.Val] = DiscoveryState.Grey;
            foreach (var e in v.Edges)
            {
                var neighbour = e.End;
                if (discoverState.ContainsKey(neighbour.Val))
                {
                    if (discoverState[neighbour.Val] != DiscoveryState.White) continue;
                }
                else
                {
                    discoverState.Add(neighbour.Val, DiscoveryState.White);
                    path.Add(neighbour.Val);
                }
                DFSGraphVertex(neighbour, path, discoverState);
            }
            discoverState[v.Val] = DiscoveryState.Black;
        }
    }
}
