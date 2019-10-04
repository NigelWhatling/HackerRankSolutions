namespace HackerRankSolutions.InterviewPreparationKit.Arrays.Tests
{
    using NUnit.Framework;
    using HackerRankSolutions.TestUtils;
    using HackerRankSolutions.InterviewPreparationKit.Arrays;

    public class Problem_2D_Array_DS_Test
    {
        [TestCase("1 1 1 0 0 0|0 1 0 0 0 0|1 1 1 0 0 0|0 0 2 4 4 0|0 0 0 2 0 0|0 0 1 2 4 0", ExpectedResult = "19", TestName = "Sample Test case 0")]
        [TestCase("1 1 1 0 0 0|0 1 0 0 0 0|1 1 1 0 0 0|0 9 2 -4 -4 0|0 0 0 -2 0 0|0 0 -1 -2 -4 0", ExpectedResult = "13", TestName = "Sample Test case 1")]
        [TestCase("-9 -9 -9 1 1 1|0 -9 0 4 3 2|-9 -9 -9 1 2 3|0 0 8 6 6 0|0 0 0 -2 0 0|0 0 1 2 4 0", ExpectedResult = "28", TestName = "Sample Test case 2")]
        public string SolutionReturnsCorrectResult(string sample)
        {
            return TestUtil.Run(sample.Split('|'), () => Problem_2D_Array_DS.Main(null));
        }
    }
}