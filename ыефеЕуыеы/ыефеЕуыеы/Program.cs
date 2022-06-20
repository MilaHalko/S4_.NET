using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ыефеЕуыеы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            countUi();
        }

        static void countUi()
        {
            double[] array = new double[7];
            var start = 39.5;
            string seqSTR = "";
            foreach (int i in array)
            {
                array[i] = start;
                seqSTR += array[i].ToString() + "  ";
                start += 7;
            }
            Console.WriteLine(seqSTR);

            seqSTR = "";
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
                array[i] = (array[i] - 57.585) / 14.82;
                Console.WriteLine(array[i]); 
                array[i] = (double)decimal.Round(Convert.ToDecimal(array[i]), 3, MidpointRounding.AwayFromZero);
                Console.WriteLine(array[i]);
                seqSTR += array[i].ToString() + " ";
            }
            Console.WriteLine(seqSTR);

            Console.ReadLine();
        }
    }
}
