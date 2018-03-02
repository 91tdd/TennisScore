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

            var status = new GameResultStatus().GetStatus(game);
            switch (status)
            {
                case ResultStatus.Deuce:
                    return "Deuce";
                case ResultStatus.All:
                    return $"{GetResult(game.FirstPlayerScore)} All";
                case ResultStatus.Adv:
                    return GetStatus(game, "Adv");
                case ResultStatus.Win:
                    return GetStatus(game, "Win");
                case ResultStatus.Other:
                    return $"{GetResult(game.FirstPlayerScore)} {GetResult(game.SecondPlayerScore)}";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string GetStatus(Game game, string status)
        {
            return game.FirstPlayerScore > game.SecondPlayerScore
                ? $"{game.FirstPlayerName} {status}"
                : $"{game.SecondPlayerName} {status}";
        }

        public string GetResult(int score)
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
                default:
                    return "";

            }
        }
    }

    public class GameResultStatus
    {
        public ResultStatus GetStatus(Game game)
        {
            if (game.FirstPlayerScore >= 3 && game.SecondPlayerScore >= 3 && game.FirstPlayerScore == game.SecondPlayerScore)
            {
                return ResultStatus.Deuce;
            }

            if (game.FirstPlayerScore == game.SecondPlayerScore && game.FirstPlayerScore < 3)
            {
                return ResultStatus.All;
            }

            if (game.FirstPlayerScore <= 3 && game.SecondPlayerScore <= 3)
            {
                return ResultStatus.Other;
            }

            if (game.FirstPlayerScore >= 3 && game.SecondPlayerScore >= 3 &&
                Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 1)
            {
                return ResultStatus.Adv;
            }

            if (game.FirstPlayerScore >= 3 || game.SecondPlayerScore >= 3 &&
                Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) >= 2)
            {
                return ResultStatus.Win;
            }
            throw new Exception();
        }
    }

    public enum ResultStatus
    {
        Deuce,
        All,
        Adv,
        Win,
        Other
    }
}