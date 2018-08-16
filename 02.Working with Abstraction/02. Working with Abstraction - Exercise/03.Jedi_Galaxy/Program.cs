using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimestions[0];
            int col = dimestions[1];

            int[,] matrix = new int[row, col];
            matrix = FullMatrix(matrix, row, col);

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int rowE = evil[0];
                int colE = evil[1];
                matrix = MovesEvil(matrix, rowE, colE);

                int xI = ivoS[0];
                int yI = ivoS[1];
                sum += SumOnIvo(matrix, sum, xI, yI);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static long SumOnIvo(int[,] matrix, long sum, int xI, int yI)
        {
            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                {
                    sum += matrix[xI, yI];
                }

                yI++;
                xI--;
            }

            return sum;
        }

        private static int[,] MovesEvil(int[,] matrix, int rowE, int colE)
        {
            while (rowE >= 0 && colE >= 0)
            {
                if (rowE >= 0 && rowE < matrix.GetLength(0) && colE >= 0 && colE < matrix.GetLength(1))
                {
                    matrix[rowE, colE] = 0;
                }
                rowE--;
                colE--;
            }

            return matrix;
        }

        private static int[,] FullMatrix(int[,] matrix, int row, int col)
        {
            int value = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return matrix;
        }
    }
}
