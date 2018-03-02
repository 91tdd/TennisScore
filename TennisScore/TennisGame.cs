using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        private Dictionary<int, string> scoreMapping = new Dictionary<int, string>
            {
                {0, "Love"},
                {1, "Fifteen"},
                {2, "Thirty"},
                {3, "Forty"},
            };

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);

            if (IsNormalScore(game))
            {
                return IsReadyForWin(game) ? AdvStatus(game) : NormalScore(game);
            }

            return IsDeuce(game) ? "Deuce" : SameScore(game);
        }

        private static bool IsDeuce(Game game)
        {
            return game.FirstPlayerScore >= 3;
        }

        private string SameScore(Game game)
        {
            return scoreMapping[game.FirstPlayerScore] + " All";
        }

        private string NormalScore(Game game)
        {
            return scoreMapping[game.FirstPlayerScore] + " " + scoreMapping[game.SecondPlayerScore];
        }

        private static bool IsNormalScore(Game game)
        {
            return game.FirstPlayerScore != game.SecondPlayerScore;
        }

        private static string AdvStatus(Game game)
        {
            return AdvName(game) + (IsWin(game) ? " Win" : " Adv");
        }

        private static bool IsReadyForWin(Game game)
        {
            return game.FirstPlayerScore > 3 || game.SecondPlayerScore > 3;
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