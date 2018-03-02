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

            var check = CheckWin(game.FirstPlayerName, game.FirstPlayerScore, game.SecondPlayerScore);
            if (check != "")
            {
                return check;
            }

            check = CheckWin(game.SecondPlayerName, game.SecondPlayerScore, game.FirstPlayerScore);
            if (check != "")
            {
                return check;
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

        private static string CheckWin(string name, int score, int other_score)
        {
            // 第一種 Win
            if (score > 4 && score - other_score >= 2)
            {
                {
                    return name + " Win";
                }
            }

            // 第二種 Win
            if (score == 4 && other_score <= 2)
            {
                {
                    return name + " Win";
                }
            }

            return "";
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