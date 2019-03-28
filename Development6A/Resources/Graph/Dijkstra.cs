using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Development6A.Resources.Graph
{
    public class Dijkstra
    {
        // The ammount of nodes in the matrix.
        public int ammountofNodes
        {
            get { return this.AdjacencyMatrix.GetLength(0); }
        }

        // The AdjancencyMatrix
        internal double[,] AdjacencyMatrix { get; private set; }

        // Constructor of the class
        public Dijkstra(double[,] matrix)
        {
            // Controlleer of de matrix wel vierkant is.
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException("The adjacency matrix must be a square matrix");
            this.AdjacencyMatrix = matrix;
        }

        private int minDistance(int[] dist, bool[] prev)
        {
            // Initialize min value
            int min = int.MaxValue;
            int min_index = -1;

            // Calculates the minium value's.
            for (int i = 0; i < ammountofNodes; i++)
            {
                if (prev[ammountofNodes] == false && dist[ammountofNodes] <= min)
                {
                    min = dist[ammountofNodes];
                    min_index = ammountofNodes;
                }
            }

            return min_index;
        }

        // Look for the neigbours of an node.
        private List<int> Neighbors(int node)
        {
            List<int> intList = new List<int>();
            for (int index = 0; index < this.AdjacencyMatrix.GetLength(0); ++index)
            {
                if (this.AdjacencyMatrix[node, index] < double.PositiveInfinity)
                {
                    intList.Add(index);
                }
            }

            return intList;
        }

        // Dijkstra Algorithme
        public Tuple<double[], int[]> DijkstraAlgorithme(int source)
        {
            // Initiaze all the array's and default list.
            double[] dist = new double[this.ammountofNodes];
            int[] prev = new int[this.ammountofNodes];
            List<int> SourceList = new List<int>(this.ammountofNodes);

            // Set all the value's to the default value's.
            for (int index = 0; index < ammountofNodes; index++)
            {
                dist[index] = double.PositiveInfinity;
                prev[index] = -1;
                SourceList.Add(index);
            }

            // Set the cost of the source to 0 because it doesn't cost anything to go there and it says that we are home.
            dist[source] = 0;

            // Loop thats callculate the distance from the single source.
            while (SourceList.Count > 0)
            {
                // Get initial value's.
                int index1 = SourceList.First<int>();
                double num1 = dist[index1];
                int node = index1;

                for (int index2 = 0; index2 < SourceList.Count; index2++)
                {
                    if (dist[SourceList[index2]] < num1)
                    {
                        node = SourceList[index2];
                        num1 = dist[SourceList[index2]];
                    }
                }

                // Remove current node from to do sourcelist.
                SourceList.Remove(node);
                // Get all the neigbors for the current node.
                List<int> Neighbors = this.Neighbors(node);
                // Voer de for loop uit voor elke buur van de geselecteerde node.
                for (int index2 = 0; index2 < Neighbors.Count; index2++)
                {
                    double num2 = dist[node] + this.AdjacencyMatrix[node, Neighbors[index2]];
                    // Controlleert of er een kortere weg is gevonden en dit wordt bijgewerkt in de twee array's.
                    if (num2 < dist[Neighbors[index2]])
                    {
                        dist[Neighbors[index2]] = num2;
                        prev[Neighbors[index2]] = node;
                    }
                }
            }

            // Create Tuple that is returnt
            return new Tuple<double[], int[]>(dist, prev);
        }
    }
}