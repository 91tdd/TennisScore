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

        [TestMethod]
        public void Love_Fifteen()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 0, SecondPlayerScore = 1 });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Love Fifteen");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 1 });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Fifteen All");
        }

        [TestMethod]
        public void Deuce()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 3 });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Deuce");
        }

        [TestMethod]
        public void DeuceWith4()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 4 });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Deuce");
        }

        [TestMethod]
        public void Joey_Adv()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 3, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Joey Adv");
        }

        [TestMethod]
        public void Tom_Adv()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 4, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Tom Adv");
        }

        [TestMethod]
        public void Joey_Win()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 5, SecondPlayerScore = 3, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Joey Win");
        }

        [TestMethod]
        public void Tom_Win()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 5, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Tom Win");
        }

        [TestMethod]
        public void Joey_Win_with_4_0()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 0, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            AssertScoreShouldBe(tennisGame.ScoreResult(gameId), "Joey Win");
        }

        private void AssertScoreShouldBe(string scoreResult, string expected)
        {
            Assert.AreEqual(expected, scoreResult);
        }
    }
}