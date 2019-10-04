namespace HackerRankSolutions.InterviewPreparationKit.WarmupChallenges.Tests
{
    using NUnit.Framework;
    using HackerRankSolutions.TestUtils;
    using HackerRankSolutions.InterviewPreparationKit.WarmupChallenges;

    public class Problem_Sock_Merchant_Test
    {
        [TestCase("9|10 20 20 10 10 30 50 10 20", ExpectedResult = "3", TestName = "Sample Test case 0")]
        [TestCase("10|1 1 3 1 2 1 3 3 3 3", ExpectedResult = "4", TestName = "Sample Test case 1")]
        public string SolutionReturnsCorrectResult(string sample)
        {
            return TestUtil.Run(sample.Split('|'), () => Problem_Sock_Merchant.Main(null));
        }
    }
}