using System;

namespace Development6A.Resources.Graph
{
    public class FloydWarshall
    {
        // The ammount of nodes in the matrix.
        public int ammountofNodes
        {
            get { return this.AdjacencyMatrix.GetLength(0); }
        }

        // The AdjancencyMatrix
        internal double[,] AdjacencyMatrix { get; private set; }

        // Constructor of the class
        public FloydWarshall(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException("The adjacency matrix must be a square matrix");
            this.AdjacencyMatrix = matrix;
        }

        public Tuple<double[,], int[,]> FloydWarshallAlgorithme()
        {
            // make the two matrix's
            double[,] distination = new double[this.ammountofNodes, this.ammountofNodes];
            int[,] prev = new int[this.ammountofNodes, this.ammountofNodes];

            // Set all initial value's of the matrix's
            for (int index1 = 0; index1 < this.ammountofNodes; index1++)
            {
                for (int index2 = 0; index2 < this.ammountofNodes; index2++)
                {
                    distination[index1, index2] = double.PositiveInfinity;
                    prev[index1, index2] = -1;
                }
            }

            // Set the cost from the node's to source where both is the same to the cost of 0.
            for (int index = 0; index < this.ammountofNodes; index++)
            {
                distination[index, index] = 0.0;
            }

            // Get the current shortest path from AdjencyMatrix
            for (int index1 = 0; index1 < this.ammountofNodes; index1++)
            {
                for (int index2 = 0; index2 < this.ammountofNodes; index2++)
                {
                    if (this.AdjacencyMatrix[index1, index2] != double.PositiveInfinity)
                    {
                        distination[index1, index2] = this.AdjacencyMatrix[index1, index2];
                        prev[index1, index2] = index2;
                    }
                }
            }

            // Thertermites the shortest path.
            for (int index1 = 0; index1 < this.ammountofNodes; index1++)
            {
                for (int index2 = 0; index2 < this.ammountofNodes; index2++)
                {
                    for (int index3 = 0; index3 < this.ammountofNodes; index3++)
                    {
                        if (distination[index2, index3] > distination[index2, index1] + distination[index1, index3])
                        {
                            distination[index2, index3] = distination[index2, index1] + distination[index1, index3];
                            prev[index2, index3] = prev[index2, index1];
                        }
                    }
                }
            }

            // Return an tuple with two matrixes with the paths.
            return new Tuple<double[,], int[,]>(distination, prev);
        }
    }
}