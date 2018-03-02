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
            return game.IsDifferentScore()
                ? (game.IsAlreadyForWin() ? game.AdvStatement() : game.NormalScore())
                : (game.IsDeuce() ? Deuce() : game.SameScore());
        }

        private static string Deuce()
        {
            return "Deuce";
        }
    }
}