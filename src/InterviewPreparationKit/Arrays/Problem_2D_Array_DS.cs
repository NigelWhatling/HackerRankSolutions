namespace HackerRankSolutions.InterviewPreparationKit.Arrays
{
    using System;
    using System.IO;

    public class Problem_2D_Array_DS
    {

        // Complete the hourglassSum function below.
        static int hourglassSum(int[][] arr)
        {
            int[,] hourglass = new int[7, 2]
            {
                { 0, 0 },
                { 1, 0 },
                { 2, 0 },
                { 1, 1 },
                { 0, 2 },
                { 1, 2 },
                { 2, 2 }
            };

            int max = int.MinValue;
            for (int y = 0; y <= 3; y++)
            {
                for (int x = 0; x <= 3; x++)
                {
                    int sum = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        sum += arr[y + hourglass[i, 1]][x + hourglass[i, 0]];
                    }

                    max = Math.Max(sum, max);
                }
            }

            return max;
        }

        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }

}