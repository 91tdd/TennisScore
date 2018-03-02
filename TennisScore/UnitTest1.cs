using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private IRepository<Game> repo = Substitute.For<IRepository<Game>>();
        private int gameId = 1;
        private string secondPlayerName = "Tom";
        private string firstPlayerName = "Joey";

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
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenGameRecord(1, 0);
            ScoreShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            GivenGameRecord(2, 0);
            ScoreShouldBe("Thirty Love");
        }

        [TestMethod]
        public void Forty_Love()
        {
            GivenGameRecord(3, 0);
            ScoreShouldBe("Forty Love");
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            GivenGameRecord(0, 1);
            ScoreShouldBe("Love Fifteen");
        }

        [TestMethod]
        public void Deuce()
        {
            GivenGameRecord(3, 3);
            ScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void Deuce_When_4_4()
        {
            GivenGameRecord(4, 4);
            ScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void FirstPlayer_Adv()
        {
            GivenGameRecord(4, 3);
            ScoreShouldBe($"{firstPlayerName} Adv");
        }

        [TestMethod]
        public void SecondPlayer_Adv()
        {
            GivenGameRecord(3, 4);
            ScoreShouldBe($"{secondPlayerName} Adv");
        }

        [TestMethod]
        public void FirstPlayer_Win()
        {
            GivenGameRecord(5, 3);
            ScoreShouldBe($"{firstPlayerName} Win");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            GivenGameRecord(1, 1);
            ScoreShouldBe("Fifteen All");
        }

        private void ScoreShouldBe(string expected)
        {
            Assert.AreEqual(expected, tennisGame.ScoreResult(gameId));
        }

        private void GivenGameRecord(int firstPlayerScore, int secondPlayerScore)
        {
            this.repo.GetGame(gameId).Returns(new Game
            {
                Id = gameId,
                FirstPlayerScore = firstPlayerScore,
                SecondPlayerScore = secondPlayerScore,
                FirstPlayerName = firstPlayerName,
                SecondPlayerName = secondPlayerName
            });
        }
    }
}