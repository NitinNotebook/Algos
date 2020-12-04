using System.Collections.Generic;

namespace Algos.Graph
{
    public class GraphVertex<T>
    {
        public GraphVertex(T val)
        {
            this.Val = val;
            this.Edges = new List<GraphEdge<T>>();
        }

        public T Val { get; set; }
        public List<GraphEdge<T>> Edges { get; set; }
    }
}
