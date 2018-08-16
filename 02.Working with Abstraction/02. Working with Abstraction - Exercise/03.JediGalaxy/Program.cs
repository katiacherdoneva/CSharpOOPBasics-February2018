using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int row = dimestions[0];
        int col = dimestions[1];

        int[,] matrix = FullMatrix(row, col);

        string command = Console.ReadLine();
        long sum = 0;
        while (command != "Let the Force be with you")
        {
            int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            matrix = MovesEvil(matrix, evil);
            sum += SumOnIvo(matrix, ivoS);

            command = Console.ReadLine();
        }

        Console.WriteLine(sum);
    }

    private static long SumOnIvo(int[,] matrix, int[] ivoS)
    {
        int rowI = ivoS[0];
        int colI = ivoS[1];

        long sum = 0;
        while (rowI >= 0 && colI < matrix.GetLength(1))
        {
            if (rowI >= 0 && rowI < matrix.GetLength(0) && colI >= 0 && colI < matrix.GetLength(1))
            {
                sum += matrix[rowI, colI];
            }

            colI++;
            rowI--;
        }

        return sum;
    }

    private static int[,] MovesEvil(int[,] matrix, int[] evil)
    {
        int rowE = evil[0];
        int colE = evil[1];
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

    private static int[,] FullMatrix(int row, int col)
    {
        int[,] matrix = new int[row, col];

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


