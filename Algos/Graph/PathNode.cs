namespace Algos.Graph
{
    public class PathNode<T>
    {
        public PathNode(GraphVertex<T> v)
        {
            Vertex = v;
            Weight = int.MaxValue;
        }

        public GraphVertex<T> Vertex { get; set; }
        public GraphVertex<T> Predecssor { get; set; }
        public int Weight { get; set; }
    }
}
