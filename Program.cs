using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Dijkstra graph = new Dijkstra(5);
            graph.AddEdge(0, 1, 10);
            graph.AddEdge(0, 3, 7);
            graph.AddEdge(1, 2, 5);
            graph.AddEdge(1, 3, 8);
            graph.AddEdge(1, 4, 2);
            graph.AddEdge(2, 4, 8);
            graph.AddEdge(3, 4, 6);

            graph.GetPath(0);

            Console.ReadKey();
        }
    }
}
