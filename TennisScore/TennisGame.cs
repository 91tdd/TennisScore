using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        private Dictionary<int,string> ScoreMapping = new Dictionary<int, string>
        {
            {0,"Love" },
            {1,"Fifteen"},
            {2,"Thirty"},
            {3,"Forty"},

        };
        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);
            if (IsGameEnd(game))
                return (game.FirstPlayerScore > game.SecondPlayerScore ? game.FirstPlayerName : game.SecondPlayerName) + " Win";

            if (IsAdv(game))
                return (game.FirstPlayerScore > game.SecondPlayerScore? game.FirstPlayerName : game.SecondPlayerName) +" Adv";
            if (game.FirstPlayerScore - game.SecondPlayerScore == 0 && game.FirstPlayerScore >=3)              
                return "Deuce";
            if (game.FirstPlayerScore + game.SecondPlayerScore == 0)
                return "Love All";
            if (game.FirstPlayerScore == game.SecondPlayerScore)
                return ScoreMapping[game.FirstPlayerScore] + " " + "All";
            return ScoreMapping[game.FirstPlayerScore] + " " + ScoreMapping[game.SecondPlayerScore];
        }

        private static bool IsAdv(Game game)
        {
            return game.FirstPlayerScore >= 3 && game.SecondPlayerScore >= 3 &&
                   Math.Abs(game.FirstPlayerScore-game.SecondPlayerScore) == 1;
        }

        private static bool IsGameEnd(Game game)
        {
            return game.FirstPlayerScore >= 3 && game.SecondPlayerScore >= 3 &&
                   Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 2;
        }
    }
}