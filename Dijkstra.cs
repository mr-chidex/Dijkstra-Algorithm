using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Dijkstra
    {
        private int vertices;
        private int[,] list;

        public Dijkstra(int vertices)
        {
            this.vertices = vertices;
            this.list=new int [vertices,vertices];
        }

        public void AddEdge(int source, int destination, int weight)
        {
            list[source, destination] = weight;
        }

        public void GetPath(int source)
        {
            int[] pathLength = new int[vertices];
            bool [] visited =new bool[vertices];

            for (int i = 0; i < vertices; i++)
            {
                //Making pathlength infinity
                pathLength[i] = int.MaxValue;
            }

            pathLength[source] = 0;//setting source to 0

            for (int i = 0; i < vertices; i++)
            {
                int currentVertex = GetMinimumPathVertex(pathLength, visited);//Get current minimum vertex
                visited[currentVertex] = true;

                for (int vertex = 0; vertex < vertices; vertex++)
                {
                    if (list[currentVertex, vertex] > 0)
                    {
                        //check if node is already included and pathlength value is infinity
                        if (!visited[vertex] && list[currentVertex, vertex] != int.MaxValue)
                        {
                            //update pathlength value if its not set
                            if (pathLength[currentVertex] + list[currentVertex, vertex] < pathLength[vertex])
                            {
                                pathLength[vertex] = pathLength[currentVertex] + list[currentVertex, vertex];
                            }
                        }
                    }
                }
            }
            

            PrintShow(source, pathLength);
        }



        public int GetMinimumPathVertex(int[] pathLength, bool [] visited)
        {
            int min = int.MaxValue;
            int minVertex = 0;
            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i] && min > pathLength[i])
                {
                    min = pathLength[i];
                    minVertex = i;
                }
            }
            return minVertex;
        }

        void PrintShow(int source, int[] pathLength)
        {
            for (int i = 0; i < vertices; i++)
            {
                Console.WriteLine("from source {0} to {1} the shortest distance = {2}", source, i, pathLength[i]);
            }
        }
    }
}
