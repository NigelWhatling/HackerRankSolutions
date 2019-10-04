namespace HackerRankSolutions.InterviewPreparationKit.WarmupChallenges
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Problem_Sock_Merchant
    {

        // Complete the sockMerchant function below.
        static int sockMerchant(int n, int[] ar)
        {
            Dictionary<int, int> socks = new Dictionary<int, int>();
            foreach (int sock in ar)
            {
                if (socks.ContainsKey(sock))
                {
                    socks[sock]++;
                }
                else
                {
                    socks[sock] = 1;
                }
            }

            int pairs = 0;
            foreach (int sock in socks.Keys)
            {
                pairs += socks[sock] / 2;
            }

            return pairs;
        }

        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
            ;
            int result = sockMerchant(n, ar);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
