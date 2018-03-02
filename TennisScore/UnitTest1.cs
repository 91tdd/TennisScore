using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Love_All()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 0,
                    SecondPlayerScore = 0,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Love All", scoreResult);
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 1,
                    SecondPlayerScore = 0,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Fifteen Love", scoreResult);
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 0,
                    SecondPlayerScore = 1,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Love Fifteen", scoreResult);
        }

        [TestMethod]
        public void Thirty_Love()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 2,
                    SecondPlayerScore = 0,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Thirty Love", scoreResult);
        }

        [TestMethod]
        public void Love_Thirty()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 0,
                    SecondPlayerScore = 2,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Love Thirty", scoreResult);
        }

        [TestMethod]
        public void Forty_Love()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 3,
                    SecondPlayerScore = 0,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Forty Love", scoreResult);
        }

        [TestMethod]
        public void Love_Forty()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 0,
                    SecondPlayerScore = 3,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Love Forty", scoreResult);
        }

        [TestMethod]
        public void Fifteen_All ()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 1,
                    SecondPlayerScore = 1,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Fifteen All", scoreResult);
        }

        [TestMethod]
        public void Thirty_All()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 2,
                    SecondPlayerScore = 2,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Thirty All", scoreResult);
        }

        [TestMethod]
        public void Deuce()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 3,
                    SecondPlayerScore = 3,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            IRepository<Game> repo1 = Substitute.For<IRepository<Game>>();
            repo1.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 4,
                    SecondPlayerScore = 4,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            TennisGame tennisGame1 = new TennisGame(repo1);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Deuce", scoreResult);

            var scoreResult1 = tennisGame1.ScoreResult(gameId);
            Assert.AreEqual("Deuce", scoreResult1);
        }

        [TestMethod]
        public void Adv()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 4,
                    SecondPlayerScore = 3,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            IRepository<Game> repo1 = Substitute.For<IRepository<Game>>();
            repo1.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 3,
                    SecondPlayerScore = 4,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            TennisGame tennisGame1 = new TennisGame(repo1);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual($"Joey Adv", scoreResult);

            var scoreResult1 = tennisGame1.ScoreResult(gameId);
            Assert.AreEqual("Tom Adv", scoreResult1);
        }

        [TestMethod]
        public void Win()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 5,
                    SecondPlayerScore = 3,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            IRepository<Game> repo1 = Substitute.For<IRepository<Game>>();
            repo1.GetGame(gameId).Returns(
                new Game
                {
                    Id = gameId,
                    FirstPlayerScore = 3,
                    SecondPlayerScore = 5,
                    FirstPlayerName = "Joey",
                    SecondPlayerName = "Tom"
                });

            TennisGame tennisGame = new TennisGame(repo);

            TennisGame tennisGame1 = new TennisGame(repo1);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual($"Joey Win", scoreResult);

            var scoreResult1 = tennisGame1.ScoreResult(gameId);
            Assert.AreEqual("Tom Win", scoreResult1);
        }
    }
}