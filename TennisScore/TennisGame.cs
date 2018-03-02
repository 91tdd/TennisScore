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

        private Dictionary<int, string> scoreLookUp = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);
            if (game.FirstPlayerScore != game.SecondPlayerScore)
            {
                if (IsAlreadyForWin(game))
                {
                    if (IsAdv(game))
                    {
                        return AdvPlayer(game) + " Adv";
                    }
                }
                return scoreLookUp[game.FirstPlayerScore] + " " + scoreLookUp[game.SecondPlayerScore];
            }

            if (game.FirstPlayerScore >= 3)
            {
                return "Deuce";
            }
            return "Love All";
        }

        private static bool IsAlreadyForWin(Game game)
        {
            return game.FirstPlayerScore > 3 || game.SecondPlayerScore > 3;
        }

        private static bool IsAdv(Game game)
        {
            return Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 1;
        }

        private static string AdvPlayer(Game game)
        {
            var advPlayer = game.FirstPlayerScore > game.SecondPlayerScore
                ? game.FirstPlayerName
                : game.SecondPlayerName;
            return advPlayer;
        }
    }
}