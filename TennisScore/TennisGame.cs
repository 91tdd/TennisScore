using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        private readonly Dictionary<int, string> mapping = new Dictionary<int, string>()
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3, "Forty" }
        };

        private string CalculatorResult(Game game)
        {
            if (game.FirstPlayerScore < 3 || game.SecondPlayerScore <3)
            {
              return $"{mapping[game.FirstPlayerScore]} {mapping[game.SecondPlayerScore]}";
            }
            else
            {
                if (Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) >= 2)
                {
                    if (game.FirstPlayerScore > game.SecondPlayerScore)
                    {
                        return game.FirstPlayerName + " Win";
                    }
                    else
                    {
                    return game.SecondPlayerName +" Win";

                    }
                }
                else
                {
                    if (game.FirstPlayerScore > game.SecondPlayerScore)
                    {
                        return game.FirstPlayerName + " Adv";
                    }
                    else
                    {
                        return game.SecondPlayerName + " Adv";

                    }
                }


            }
        }

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);

            if (game.FirstPlayerScore == game.SecondPlayerScore)
            {

                if (game.FirstPlayerScore < 3)
                {
                    return mapping[game.FirstPlayerScore] + " All";
                    
                }
                else
                {
                    return "Deuce";
                }

            }
            else
            {
                return CalculatorResult(game);
            }

    
        }
    }
}