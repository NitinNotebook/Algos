namespace Algos.Graph
{
    public class GraphEdge<T>
    {
        public GraphEdge(GraphVertex<T> start, GraphVertex<T> end, int weight = 0)
        {
            this.Start = start;
            this.End = end;
            this.Weight = weight;
        }

        public int Weight { get; set; }

        public GraphVertex<T> Start { get; set; }
        public GraphVertex<T> End { get; set; }
    }

    public class SimpleEdge<T>
    {
        public SimpleEdge(T v1, T v2, int weight = 0)
        {
            this.Vertex1 = v1;
            this.Vertex2 = v2;
            this.Weight = weight;
        }

        public T Vertex1 { get; set; }
        public T Vertex2 { get; set; }
        public int Weight { get; set; }
    }
}
