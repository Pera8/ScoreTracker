using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScoreTrackerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLeagueMethodGetById()
        {
            var leagueId = new Mock();
            var leagueProcessor = new LeagueController(leagueId.Object);

            Assert.Throws(() => leagueProcessor.(new Data.Employee(), DateTime.Today, 8));
        }
    }
}
