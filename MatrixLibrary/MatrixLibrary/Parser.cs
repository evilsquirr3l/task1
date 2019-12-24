using System;
using System.IO;

namespace MatrixLibrary
{
    public class Parser
    {
        private static string filepath = @"C:\Users\evilsquirrel\source\repos\ConsoleMatrix\ConsoleMatrix\bin\Debug\TextFile1.txt";
        public static int n;
        public static int m;

        public string FilePath
        {
            get => filepath;
            set => filepath = value;
        }

        public static Tuple<int, int, double[,]> ReadFile()
        {
            String input = File.ReadAllText(filepath);

            int i = 0, j = 0;
            double[,] result = new Double[10, 10];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    result[i, j] = double.Parse(col.Trim());
                    j++;
                }
                i++;
            }

            n = i;
            m = j;
            return Tuple.Create(n, m, result);
        }

    }
}