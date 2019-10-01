namespace HackerRankSolutions.TestUtils
{
    using System;
    using System.IO;
    using NUnit.Framework;

    public class TestUtil
    {
        /// <summary>Runs the specified action using the provided input data.</summary>
        /// <param name="input">The input to be injected to the console stdin.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="keepOutput"></param>
        public static string Run(string[] input, Action action, bool keepOutput = false)
        {
            string outputPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{TestContext.CurrentContext.Test.ClassName} - {TestContext.CurrentContext.Test.Name}.txt");
            TestContext.WriteLine($"Test '{TestContext.CurrentContext.Test.Name}': {outputPath}");

            // Delete existing output files.
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            // Set the OUTPUT_PATH environment variable which is used by the standard HackerRank code.
            Environment.SetEnvironmentVariable("OUTPUT_PATH", outputPath);

            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    foreach (string line in input)
                    {
                        sw.WriteLine(line);
                    }

                    sw.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    using (StreamReader sr = new StreamReader(ms))
                    {
                        Console.SetIn(sr);
                        action();
                    }
                }
            }

            string result = File.ReadAllText(outputPath).Trim();

            if (!keepOutput)
            {
                File.Delete(outputPath);
            }

            return result;
        }
    }
}
