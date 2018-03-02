using System;
using System.Collections.Generic;

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

            Dictionary<int, string> scoreMapping = new Dictionary<int, string>
            {
                {0, "Love"},
                {1, "Fifteen"},
                {2, "Thirty"},
                {3, "Forty"},
            };

            if (game.FirstPlayerScore != game.SecondPlayerScore)
            {
                if (game.FirstPlayerScore > 3 || game.SecondPlayerScore > 3)
                {
                    return AdvName(game) + (IsWin(game) ? " Win" : " Adv");
                }

                return scoreMapping[game.FirstPlayerScore] + " " + scoreMapping[game.SecondPlayerScore];
            }

            if (game.FirstPlayerScore >= 3)
            {
                return "Deuce";
            }

            return scoreMapping[game.FirstPlayerScore] + " All";
        }

        private static string AdvName(Game game)
        {
            return game.FirstPlayerScore > game.SecondPlayerScore
                ? game.FirstPlayName
                : game.SecondPlayerName;
        }

        private static bool IsWin(Game game)
        {
            return Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) > 1;
        }
    }
}