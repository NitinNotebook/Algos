using System.Collections.Generic;

namespace Algos.Graph
{
    public static class GraphRepo
    {
        public static Graph<char> CreateCharGraphSample()
        {
            List<char> vertices = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };

            List <SimpleEdge<char>> adjacencyList = new List<SimpleEdge<char>>()
            {
                new SimpleEdge<char>('a', 'b', 4),
                new SimpleEdge<char>('a', 'h', 8),
                new SimpleEdge<char>('b', 'c', 8),
                new SimpleEdge<char>('c', 'f', 4),
                new SimpleEdge<char>('c', 'd', 7),
                new SimpleEdge<char>('c', 'i', 2),
                new SimpleEdge<char>('b', 'h', 11),
                new SimpleEdge<char>('h', 'g', 1),
                new SimpleEdge<char>('h', 'i', 7),
                new SimpleEdge<char>('i', 'g', 6),
                new SimpleEdge<char>('g', 'f', 2),
                new SimpleEdge<char>('f', 'e', 10),
                new SimpleEdge<char>('d', 'f', 14),
                new SimpleEdge<char>('f', 'e', 10),
            };

            return Graph<char>.Create(vertices, adjacencyList);
        }
    }
}
