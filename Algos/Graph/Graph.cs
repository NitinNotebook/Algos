using System.Collections.Generic;

namespace Algos.Graph
{
    public class Graph<T>
    {
        public Graph()
        {
            this.Vertices = new List<GraphVertex<T>>();
        }

        public List<GraphVertex<T>> Vertices { get; set; }

        public static Graph<T> Create(List<T> vertices, List<SimpleEdge<T>> adjacencyList)
        {
            var graph = new Graph<T>();
            var vertexMap = new Dictionary<T, GraphVertex<T>>();
            foreach (var theC in vertices)
            {
                var vertex = new GraphVertex<T>(theC);
                graph.Vertices.Add(vertex);
                vertexMap.Add(theC, vertex);
            }

            foreach (var kvpAdj in adjacencyList)
            {
                var v1 = vertexMap[kvpAdj.Vertex1];
                var v2 = vertexMap[kvpAdj.Vertex2];               
                
                v1.Edges.Add(new GraphEdge<T>(v1, v2, kvpAdj.Weight));
                v2.Edges.Add(new GraphEdge<T>(v2, v1, kvpAdj.Weight));
            }

            return graph;
        }
    }
}
