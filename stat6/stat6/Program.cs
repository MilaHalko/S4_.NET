using System;
using System.Collections.Generic;
using System.Linq;

namespace statistics2
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbersInRow = "13,27,25,23,32,49,30,16,25,32,11,37,24,23,23,28,30,14,36,13,26,24,33,35,30,39,54,34,42,30,22,28,36,44,20,34,30,23,13,28,14,6,26,25,15,34,16,39,28,36,24,30,23,27,16,17,2,16,24,24,31,20,26,16,26,21,24,19,44,31,3,20,20,18,18,24,32,11,23,24,30,13,30,18,24,28,19,23,45,39,21,37,1,12,17,37,21,29,14,22";

            //numbersInRow = numbersInRow.Trim();

            var numbers = numbersInRow.Split(',').Select(strNum => int.Parse(strNum));
            int n = numbers.Count();

            var sortedNumbers = numbers.OrderBy(num => num);

            int k = 7; 
            int xMin = sortedNumbers.First();
            int xMax = sortedNumbers.Last();
            Console.WriteLine($"ld: {sortedNumbers}");
            int y = 0;
            string final = "";
            foreach (var sor in sortedNumbers)
            {
                final += sor.ToString() + " ";
                y++;
            }
            Console.WriteLine(y);
            Console.WriteLine(final);
            Console.WriteLine("k = " + k);
            Console.WriteLine("x min = " + xMin);
            Console.WriteLine("x max = " + xMax);

            int h = (int)Math.Ceiling(((double)(xMax - xMin)) / k);
            Console.WriteLine("h = " + h);

            double xStart = 0;
            if (k % 2 == 0)
            {
                xStart = xMin - (double)h / 2;
            }
            else
            {
                xStart = xMin;
            }

            int totalLength = 0;

            List<(double, double, int)> ranges = new List<(double, double, int)>();
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine($"{xStart} {xStart + h}");

                int length = sortedNumbers.Count(num => num >= xStart && num < xStart + h);
                Console.WriteLine("length = " + length);

                ranges.Add((xStart, xStart + h, length));

                totalLength += length;
                xStart += h;
            }
            Console.WriteLine("Total length = " + totalLength + "\n\n");

            var discrete = ranges.Select(range => (((double)(range.Item1 + range.Item2)) / 2, range.Item3));
            foreach (var range in discrete)
            {
                Console.WriteLine("Average of range: " + range.Item1);
                Console.WriteLine("n = " + range.Item2 + "\n");
            }

            double C = (discrete.First().Item1 + discrete.Last().Item1) / 2;
            Console.WriteLine("C = " + C);

            var discreteComfortable = discrete.Select(pair => (pair.Item1 - C, pair.Item2));

            double sum = 0;
            double sumAverage = 0;
            foreach (var pair in discreteComfortable)
            {
                Console.WriteLine("Conditional variant: " + pair.Item1);
                Console.WriteLine("n = " + pair.Item2 + "\n");
                sum += pair.Item1 * pair.Item2;
                sumAverage += pair.Item1 * pair.Item1 * pair.Item2;
            }

            double uV = sum / n;
            double xV = uV + C;

            Console.WriteLine("Вибіркове середнє:");
            Console.WriteLine("uV = " + uV);
            Console.WriteLine(("xV = " + xV));

            double tempSum = 0;
            foreach (var pair in discrete)
            {
                tempSum += pair.Item1 * pair.Item2;
            }

            double X = tempSum / n;
            Console.WriteLine(X);
            double dispersion = sumAverage / n - uV * uV;
            Console.WriteLine("Вибіркова дисперсія: " + dispersion);

            double sigmaV = Math.Round(Math.Sqrt(dispersion), 4);
            Console.WriteLine("Вибіркове середнє квадратичне відхилення: " + sigmaV);

            double s2 = Math.Round(((double)n) / (n - 1) * dispersion, 4);
            Console.WriteLine("Виправлена вибіркова дисперсія: " + s2);

            double s = Math.Round(Math.Sqrt(s2), 4);
            Console.WriteLine("Виправлене вибіркове середнє квадратичне відхилення: " + s);

            double R = discrete.Last().Item1 - discrete.First().Item1;
            Console.WriteLine("Розмах: " + R);

            double V = Math.Round(sigmaV / xV * n, 2);
            Console.WriteLine("Коефіцієнт варіації:" + V);

            //Mode
            var maxRanges = ranges.Where(range => range.Item3 == ranges.Max(rangeLocal => rangeLocal.Item3));

            foreach (var range in maxRanges)
            {
                double xM0 = range.Item1;
                int nM0 = range.Item3;

                int index = Array.IndexOf(ranges.ToArray(), range);

                int nM0Prev = (index - 1 >= 0) ? ranges.ToArray()[index - 1].Item3 : 0;
                int nM0Next = (index + 1 <= ranges.Count() - 1) ? ranges.ToArray()[index + 1].Item3 : 0; ;

                double mode = xM0 + h * ((double)(nM0 - nM0Prev) / (2 * nM0 - nM0Prev - nM0Next));

                Console.WriteLine("Mode = " + mode);
            }

            //Median
            int indexMedRange = 0;
            int sumN = 0;
            foreach (var r in ranges)
            {
                sumN += r.Item3;
                if (sumN > n / 2)
                {
                    break;
                }

                indexMedRange++;
            }

            var medianRange = ranges.ToArray()[indexMedRange];
            double xMe = medianRange.Item1;
            double nMe = medianRange.Item3;
            double sumMed = ranges.TakeWhile(range => range != medianRange).Sum(range => range.Item3);
            double median = xMe + h * ((double)n / 2 - sumMed) / nMe;
            Console.WriteLine("Median = " + median);
            Console.ReadLine();
        }
    }
}