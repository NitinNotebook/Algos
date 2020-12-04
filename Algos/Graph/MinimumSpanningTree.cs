using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Algos.Graph
{
    public static class MinimumSpanningTree
    {
        public static void Test()
        {
            var path = new List<string>();
            var discoverVertices = new Dictionary<char, DiscoveryState>();
            var graph = GraphRepo.CreateCharGraphSample();
            var pathLength = MST(graph, path, discoverVertices);
            Console.WriteLine($"{string.Join(',',  path.ToArray())}, PathLength = {pathLength}");
            
        }

        public static int MST<T>(Graph<T> graph, List<string> path, Dictionary<T, DiscoveryState> discoverVertices)
        {
            int totalWeigth = 0;
            var v = graph.Vertices[0];
            var discoveredEdges = v.Edges;
            discoverVertices.Add(v.Val, DiscoveryState.Black);
            
            while (discoveredEdges.Count > 0)
            {
                var e = SelectNextEdge(discoveredEdges, discoverVertices);
                discoverVertices.Add(e.End.Val, DiscoveryState.Black);
                path.Add($"{e.Start.Val}->{e.End.Val}({e.Weight})");
                totalWeigth += e.Weight;
                foreach (var newE in e.End.Edges)
                {
                    if (!discoveredEdges.Contains(newE))
                    {
                        discoveredEdges.Add(newE);
                    }
                }
                discoveredEdges = RemoveEdgesForDiscoveredVertices(discoveredEdges, discoverVertices);
            }
            return totalWeigth;
        }

        private static List<GraphEdge<T>> RemoveEdgesForDiscoveredVertices<T>(List<GraphEdge<T>> discoveredEdges, Dictionary<T, DiscoveryState> discoverVertices)
        {
            List<GraphEdge<T>> newDiscoveredEdges = new List<GraphEdge<T>>();
            foreach (var e in discoveredEdges)
            {
                if (!discoverVertices.ContainsKey(e.End.Val))
                {
                    newDiscoveredEdges.Add(e);
                }
            }
            return newDiscoveredEdges;
        }

        public static GraphEdge<T> SelectNextEdge<T>(List<GraphEdge<T>> discoveredEdges, Dictionary<T, DiscoveryState> discoverVertices)
        {
            GraphEdge<T> selectedEdged = null;
            foreach (var e in discoveredEdges)
            {
                if (discoverVertices.ContainsKey(e.End.Val))
                    continue;

                if (selectedEdged == null || e.Weight < selectedEdged.Weight)
                {                    
                    selectedEdged = e;
                }
            }
            return selectedEdged;
        }
    }
}
