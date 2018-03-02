using System;
using System.Collections.Generic;

namespace TennisScore
{
    public static class GameExtension
    {
        private static Dictionary<int, string> scoreLookUp = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        public static string SameScore(this Game game)
        {
            return scoreLookUp[game.FirstPlayerScore] + " All";
        }

        public static bool IsDeuce(this Game game)
        {
            return game.FirstPlayerScore >= 3;
        }

        public static bool IsDifferentScore(this Game game)
        {
            return game.FirstPlayerScore != game.SecondPlayerScore;
        }

        public static string NormalScore(this Game game)
        {
            return scoreLookUp[game.FirstPlayerScore] + " " + scoreLookUp[game.SecondPlayerScore];
        }

        public static bool IsAlreadyForWin(this Game game)
        {
            return game.FirstPlayerScore > 3 || game.SecondPlayerScore > 3;
        }

        private static bool IsAdv(this Game game)
        {
            return Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 1;
        }

        private static string AdvPlayer(this Game game)
        {
            var advPlayer = game.FirstPlayerScore > game.SecondPlayerScore
                ? game.FirstPlayerName
                : game.SecondPlayerName;
            return advPlayer;
        }

        public static string AdvStatement(this Game game)
        {
            return AdvPlayer(game) + (IsAdv(game) ? " Adv" : " Win");
        }
    }
}