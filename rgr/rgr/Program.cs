using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace linearTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////// ваші параметри
            int xMin = -5;
            int xMax = 5;
            int roundDecimals = 2; // до скільки знаків округлювати y
            int pointsNumber = 30;

            int minPercentForScatterY = 85;
            int maxPercentForScatterY = 115;

            /// y = ax1 +bx2 + c
            double aCoefficient = 1;
            double bCoefficient = 1;
            double cCoefficient = 1;

            //////////////////////////
            Random random = new();

            List<(int x1, int x2, double y)> points = new();

            for (int i = 0; i < pointsNumber; i++)
            {
                int x1 = random.Next(xMin, xMax);
                int x2 = random.Next(xMin, xMax);


                double scatterCoef = random.Next(minPercentForScatterY, maxPercentForScatterY) / 100.0;
                double y = Math.Round((aCoefficient * x1 + bCoefficient * x2 + cCoefficient) * scatterCoef, roundDecimals);

                points.Add((x1, x2, y));

            }



            foreach (var point in points)
            {
                Console.WriteLine($"X1: {point.x1} X2: {point.x2} Y: {point.y}");
            }


            Console.WriteLine("Points in geogebra format, where (x1, y, x2) is (x, y, z)");
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            var res = points.Select(tuple => $"({tuple.x1.ToString(nfi)}, {tuple.y.ToString(nfi)}, {tuple.x2.ToString(nfi)})");
            string result = $"{{{String.Join(", ", res)}}}";
            Console.WriteLine(result);

            foreach (var point in points)
            {
                double x1 = point.x1;
                double x2 = point.x2;
                double y = point.y;
                Console.WriteLine($"x1: {x1,-5} x2: {x2,-5} y: {y,-5}, x1*x2: {x1 * x2,-5}, x1^2: {x1 * x1,-5}, x2^2: {x2 * x2,-5}, x1*y: {x1 * y,-10:N5}, x2*y: {x2 * y,-10:N5}");
            }
            var x1Sum = points.Select(point => point.x1).Sum();
            var x2Sum = points.Select(point => point.x2).Sum();
            var ySum = points.Select(point => point.y).Sum();

            var x1x2Sum = points.Select(point => point.x1 * point.x2).Sum();
            var x1SquaredSum = points.Select(point => point.x1 * point.x1).Sum();
            var x2SquaredSum = points.Select(point => point.x2 * point.x2).Sum();

            var x1ySum = points.Select(point => point.x1 * point.y).Sum();
            var x2ySum = points.Select(point => point.x2 * point.y).Sum();

            Console.WriteLine($"x1 Sum: {x1Sum} x2 Sum: {x2Sum} y Sum: {ySum}");
            Console.WriteLine($"x1x2 Sum: {x1x2Sum} x1^2 Sum: {x1SquaredSum} x2^2 Sum: {x2SquaredSum}");
            Console.WriteLine($"x1y Sum: {x1ySum} x2y Sum: {x2ySum}");
            Console.ReadLine();
        }
    }
}