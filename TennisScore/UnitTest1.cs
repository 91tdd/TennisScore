using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private IRepository<Game> repo = Substitute.For<IRepository<Game>>();
        private int gameId = 1;

        private TennisGame tennisGame;

        [TestInitialize]
        public void start()
        {
            tennisGame = new TennisGame(repo);
        }

        [TestMethod]
        public void Love_All()
        {
            GivenGameRecord(0, 0);
            NewMethod("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenGameRecord(1, 0);
            NewMethod("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            GivenGameRecord(2, 0);
            NewMethod("Thirty Love");
        }

        [TestMethod]
        public void Forty_Love()
        {
            GivenGameRecord(3, 0);
            NewMethod("Forty Love");
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            GivenGameRecord(0, 1);
            NewMethod("Love Fifteen");
        }

        private void NewMethod(string expected)
        {
            Assert.AreEqual(expected, tennisGame.ScoreResult(gameId));
        }

        private void GivenGameRecord(int firstPlayerScore, int secondPlayerScore)
        {
            this.repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore = secondPlayerScore });
        }
    }
}