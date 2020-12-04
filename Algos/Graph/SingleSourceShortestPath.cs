using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos.Graph
{
    public class SingleSourceShortestPath
    {
        public static void Test()
        {
            var graph = GraphRepo.CreateCharGraphSample();
            var ssspath = SSSP(graph, graph.Vertices.First());

            foreach (var p in ssspath)
            {
                Console.WriteLine($"{p.Predecssor.Val} -> {p.Vertex.Val}, Length={p.Weight}");
            }
        }

        public static List<PathNode<T>> SSSP<T>(Graph<T> graph, GraphVertex<T> source)
        {
            var path = new List<PathNode<T>>();
            foreach (var v in graph.Vertices)
            {
                var p = new PathNode<T>(v);
                if (v == source)
                {
                    p.Predecssor = new GraphVertex<T>(default);
                    p.Weight = 0;
                }
                path.Add(p);
            }

            for (int i = 0; i < graph.Vertices.Count; i++) //belman ford - releax all edges for |V| times
            {
                bool hasRelaxed = false;
                foreach (var v in graph.Vertices)
                {
                    foreach (var e in v.Edges)
                    {
                       var relaxed = Relax(path, e);
                        hasRelaxed = hasRelaxed || relaxed;
                    }
                }

                if (!hasRelaxed) break; //if no edge relaxed in this iteration than no need to run further iterations
            }
            
            //If weigths reduce in one more iteration that means graph has negative edge.

            return path;
        }

        public static bool Relax<T>(List<PathNode<T>> lstPaths, GraphEdge<T> edge)
        {
            bool hasRelaxed = false;
            foreach (var p in lstPaths)
            {
                if (p.Vertex == edge.End)
                {
                    var newWeight = edge.Weight + GetWeight(lstPaths, edge.Start);
                    if (newWeight > 0 && p.Weight > newWeight)
                    {
                        p.Weight = newWeight;
                        p.Predecssor = edge.Start;
                        hasRelaxed = true;
                    }
                }
            }
            return hasRelaxed;
        }

        public static int GetWeight<T>(List<PathNode<T>> lstPaths, GraphVertex<T> v)
        {
            foreach (var p in lstPaths)
            {
                if (p.Vertex == v)
                    return p.Weight;
            }

            return int.MaxValue;
        }

    }
}
