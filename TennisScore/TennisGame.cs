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

            if (game.IsNormalScore())
            {
                return game.IsReadyForWin() ? game.AdvStatus() : game.NormalScore();
            }

            return game.IsDeuce() ? Deuce() : game.SameScore();
        }

        private string Deuce()
        {
            return "Deuce";
        }
    }
}