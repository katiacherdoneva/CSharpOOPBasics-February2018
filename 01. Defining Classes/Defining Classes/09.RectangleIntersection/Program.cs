using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        int[] numbersForInfo = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int n = numbersForInfo[0];
        int m = numbersForInfo[1];

        List<Rectangle> rectangles = new List<Rectangle>();
        for (int i = 0; i < n; i++)
        {
            string[] infoForRectangles = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            Rectangle rectangle = new Rectangle(infoForRectangles[0], double.Parse(infoForRectangles[1]), 
                double.Parse(infoForRectangles[2]), double.Parse(infoForRectangles[3]),
                double.Parse(infoForRectangles[4]));

            rectangles.Add(rectangle);
        }

        for (int i = 0; i < m; i++)
        {
            string[] nameOfIntersectionChecks = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            Rectangle first = rectangles.Where(x => x.ID == nameOfIntersectionChecks[0]).FirstOrDefault();
            Rectangle second = rectangles.Where(x => x.ID == nameOfIntersectionChecks[1]).FirstOrDefault();

            Console.WriteLine(first.Intersects(second));
        }
    }
}

