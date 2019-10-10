namespace HackerRankSolutions.TestUtils
{
    using System;
    using System.IO;
    using NUnit.Framework;

    public static class TestUtil
    {
        /// <summary>Runs the specified action using the provided input data.</summary>
        /// <param name="input">The input to be injected to the console stdin.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="keepOutput"></param>
        public static string Run(string[] input, Action action, bool keepOutput = false)
        {
            input = input ?? throw new ArgumentNullException(nameof(input));
            action = action ?? throw new ArgumentNullException(nameof(action));

            string outputFilename = $"{TestContext.CurrentContext.Test.ClassName}__{TestContext.CurrentContext.Test.Name}"
                .Replace('.', '_')
                .Replace(' ', '_');

            string fileOutputPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, outputFilename + ".out.txt");
            string consoleOutputPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, outputFilename + ".con.txt");

            TestContext.WriteLine($"File output: {fileOutputPath}");
            TestContext.WriteLine($"Console output: {consoleOutputPath}");

            // Delete existing output files.
            if (File.Exists(fileOutputPath))
            {
                File.Delete(fileOutputPath);
            }

            // Set the OUTPUT_PATH environment variable which is used by the standard HackerRank code.
            Environment.SetEnvironmentVariable("OUTPUT_PATH", fileOutputPath);

            FileStream fs = null;
            MemoryStream ms = null;

            try
            {
                fs = File.Open(consoleOutputPath, FileMode.Create, FileAccess.Write, FileShare.Write);
                ms = new MemoryStream();

                using (StreamWriter sw = new StreamWriter(ms))
                {
                    foreach (string line in input)
                    {
                        sw.WriteLine(line);
                    }

                    sw.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    using (StreamWriter sw2 = new StreamWriter(fs))
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        Console.SetOut(sw2);
                        Console.SetIn(sr);
                        action();
                    }
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }

                if (ms != null)
                {
                    ms.Dispose();
                }
            }

            string result = null;

            if (File.Exists(fileOutputPath))
            {
                result = File.ReadAllText(fileOutputPath).Trim();
            }
            else if (File.Exists(consoleOutputPath))
            {
                result = File.ReadAllText(consoleOutputPath).Trim();
            }

            if (!keepOutput)
            {
                File.Delete(fileOutputPath);
                File.Delete(consoleOutputPath);
            }

            TestContext.WriteLine("Result:");
            TestContext.WriteLine(result);

            return result;
        }
    }
}
