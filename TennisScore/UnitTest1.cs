using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private IRepository<Game> repo = Substitute.For<IRepository<Game>>();

        [TestMethod]
        public void Love_All()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 0, SecondPlayerScore = 0 });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 0 });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 2, SecondPlayerScore = 0 });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Thirty Love");
        }

        [TestMethod]
        public void Forty_Love()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 0 });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Forty Love");
        }

        private void AssertScoreShouldBe(string scoreResult, string expected)
        {
            Assert.AreEqual(expected, scoreResult);
        }
    }
}