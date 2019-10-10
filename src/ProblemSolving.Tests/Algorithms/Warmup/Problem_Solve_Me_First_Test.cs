namespace HackerRankSolutions.ProblemSolving.Tests.Algorithms.Warmup
{
    using NUnit.Framework;
    using HackerRankSolutions.TestUtils;
    using HackerRankSolutions.ProblemSolving.Algorithms.Warmup;

    public class Problem_Solve_Me_First_Test
    {
        [TestCase("2|3", ExpectedResult = "5", TestName = "Sample Test case 0")]
        [TestCase("100|1000", ExpectedResult = "1100", TestName = "Sample Test case 1")]
        public string SolutionReturnsCorrectResult(string sample)
        {
            return TestUtil.Run(sample.Split('|'), () => Problem_Solve_Me_First.Main(null));
        }
    }
}