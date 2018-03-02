using System;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);

            // 第一種 Win
            if (game.FirstPlayerScore > 4 &&
                game.FirstPlayerScore - game.SecondPlayerScore >= 2)
            {
                return game.FirstPlayerName + " Win";
            }

            // 第二種 Win
            if (game.FirstPlayerScore == 4 &&
                game.SecondPlayerScore <= 2)
            {
                return game.FirstPlayerName + " Win";
            }

            // 第一種 Win
            if (game.SecondPlayerScore > 4 &&
                game.SecondPlayerScore - game.FirstPlayerScore >= 2)
            {
                return game.SecondPlayerName + " Win";
            }

            // 第二種 Win
            if (game.SecondPlayerScore == 4 &&
                game.FirstPlayerScore <= 2)
            {
                return game.SecondPlayerName + " Win";
            }

            // 平手
            if (game.FirstPlayerScore >= 3 && game.SecondPlayerScore >= 3
                && game.FirstPlayerScore == game.SecondPlayerScore)
            {
                return "Deuce";
            }

            // Adv
            if (game.FirstPlayerScore >= 3 && game.SecondPlayerScore >= 3
                && (game.FirstPlayerScore - game.SecondPlayerScore) == 1)
            {
                return game.FirstPlayerName + " Adv";
            }

            if (game.FirstPlayerScore >= 3 && game.SecondPlayerScore >= 3
                && (game.SecondPlayerScore - game.FirstPlayerScore) == 1)
            {
                return game.SecondPlayerName + " Adv";
            }

            // All
            if (game.FirstPlayerScore == game.SecondPlayerScore)
            {
                switch (game.FirstPlayerScore)
                {
                    case 0:
                        return "Love All";
                    case 1:
                        return "Fifteen All";
                    case 2:
                        return "Thirty All";
                }
            }

            return GetScoreName(game.FirstPlayerScore) + " " + GetScoreName((game.SecondPlayerScore));
        }

        string GetScoreName(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
            }

            return "";
        }
    }
}