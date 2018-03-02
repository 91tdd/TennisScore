using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Love_All()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 0, SecondPlayerScore = 0, FirstPlayerName = "Joey", SecondPlayerName = "Tom"});

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Love All", scoreResult);
        }

        [TestMethod]
        public void Joey_Win()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 0, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Joey Win", scoreResult);
        }

        [TestMethod]
        public void Joey_Win_2()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 5, SecondPlayerScore = 3, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Joey Win", scoreResult);
        }

        [TestMethod]
        public void Tom_Win()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 4, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Tom Win", scoreResult);
        }

        [TestMethod]
        public void Deuce()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 4, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Deuce", scoreResult);
        }

        [TestMethod]
        public void Adv()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 3, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Joey Adv", scoreResult);
        }

        [TestMethod]
        public void Thirty_All()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 2, SecondPlayerScore = 2, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Thirty All", scoreResult);
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 0, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Fifteen Love", scoreResult);
        }

        [TestMethod]
        public void Thirty_Fifteen()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 2, SecondPlayerScore = 1, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Thirty Fifteen", scoreResult);
        }
    }
}