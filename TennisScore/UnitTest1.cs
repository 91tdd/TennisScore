using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(0, 0, "Love All")]
        [DataRow(1, 0, "Fifteen Love")]
        [DataRow(2, 0, "Thirty Love")]
        [DataRow(3, 0, "Forty Love")]

        [DataRow(0, 1, "Love Fifteen")]
        [DataRow(0, 2, "Love Thirty")]
        [DataRow(0, 3, "Love Forty")]

        [DataRow(1, 1, "Fifteen All")]
        [DataRow(2, 2, "Thirty All")]

        [DataRow(4, 3, "Joey Adv")]
        [DataRow(3, 4, "Tom Adv")]

        [DataRow(3, 3, "Deuce")]
        [DataRow(4, 4, "Deuce")]

        [DataRow(5, 3, "Joey Win")]
        [DataRow(3, 5, "Tom Win")]

        [DataRow(4, 2, "Joey Win")]
        [DataRow(2, 4, "Tom Win")]

        [DataRow(4, 1, "Joey Win")]
        [DataRow(1, 4, "Tom Win")]
        public void TennisScore_Test_第一人分數_第二人分數_預期結果(int firstPlayerScore, int secondPlayerScore, string result)
        {
            var firstPlayer = "Joey";
            var sencondPlayer = "Tom";
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game
            {
                Id = gameId,
                FirstPlayerScore = firstPlayerScore,
                SecondPlayerScore = secondPlayerScore,
                FirstPlayerName = firstPlayer,
                SecondPlayerName = sencondPlayer
            });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual(result, scoreResult);
        }
    }
}