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
            Game g = new Game { Id = 1, FirstPlayerScore = 0, SecondPlayerScore = 0 };
            string checkResult = "Love All";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            Game g = new Game { Id = 1,
                FirstPlayerScore = 1,
                SecondPlayerScore = 0 };
            string checkResult = "Fifteen Love";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Thirty_Love()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 2,
                SecondPlayerScore = 0
            };
            string checkResult = "Thirty Love";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Forty_Love()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 3,
                SecondPlayerScore = 0
            };
            string checkResult = "Forty Love";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 0,
                SecondPlayerScore = 1
            };
            string checkResult = "Love Fifteen";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Fifteen_All()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 1,
                SecondPlayerScore = 1
            };
            string checkResult = "Fifteen All";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Thirty_All()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 2,
                SecondPlayerScore = 2
            };
            string checkResult = "Thirty All";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Deuce()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 3,
                SecondPlayerScore = 3
            };
            string checkResult = "Deuce";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Deuce_4()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 4,
                SecondPlayerScore = 4
            };
            string checkResult = "Deuce";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Joey_Adv()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 4,
                SecondPlayerScore = 3
            };
            string checkResult = "Joey Adv";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Tom_Adv()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 3,
                SecondPlayerScore = 4
            };
            string checkResult = "Tom Adv";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Joey_Win_64()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 6,
                SecondPlayerScore = 4
            };
            string checkResult = "Joey Win";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Joey_Win_40()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 4,
                SecondPlayerScore = 0
            };
            string checkResult = "Joey Win";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Joey_Win_41()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 4,
                SecondPlayerScore = 1
            };
            string checkResult = "Joey Win";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Joey_Win_42()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 4,
                SecondPlayerScore = 2
            };
            string checkResult = "Joey Win";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Tom_Win_57()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 5,
                SecondPlayerScore = 7
            };
            string checkResult = "Tom Win";
            TestBase(g, checkResult);
        }

        [TestMethod]
        public void Tom_Win_24()
        {
            Game g = new Game
            {
                Id = 1,
                FirstPlayerScore = 2,
                SecondPlayerScore = 4
            };
            string checkResult = "Tom Win";
            TestBase(g, checkResult);
        }

        public void TestBase(Game game, string check)
        {
            game.FirstPlayerName = "Joey";
            game.SecondPlayerName = "Tom";

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(game.Id).Returns(game);

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(game.Id);
            
            Assert.AreEqual(check, scoreResult);
        }
    }
}