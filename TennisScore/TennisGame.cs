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

            if (game.FirstPlayerScore >= 3 && game.SecondPlayerScore >= 3 && game.FirstPlayerScore == game.SecondPlayerScore)
            {
                return "Deuce";
            }
            if (game.FirstPlayerScore == game.SecondPlayerScore && game.FirstPlayerScore < 3)
            {
                return $"{GetResult(game.FirstPlayerScore)} All";
            }
            if (game.FirstPlayerScore <= 3 && game.SecondPlayerScore <= 3)
            {
                return $"{GetResult(game.FirstPlayerScore)} {GetResult(game.SecondPlayerScore)}";
            }
            if (game.FirstPlayerScore >= 3 && game.SecondPlayerScore >= 3 &&
                Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 1)
            {
                if (game.FirstPlayerScore > game.SecondPlayerScore)
                    return $"{game.FirstPlayerName} Adv";
                if (game.FirstPlayerScore < game.SecondPlayerScore)
                    return $"{game.SecondPlayerName} Adv";
            }
            if (game.FirstPlayerScore >= 3 || game.SecondPlayerScore >= 3 &&
                Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) >= 2)
            {
                if (game.FirstPlayerScore > game.SecondPlayerScore)
                    return $"{game.FirstPlayerName} Win";
                if (game.FirstPlayerScore < game.SecondPlayerScore)
                    return $"{game.SecondPlayerName} Win";
            }

            return "";
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
}