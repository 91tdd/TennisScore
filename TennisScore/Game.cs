using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class Game
    {
        public int SecondPlayerScore { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string FirstPlayName { get; set; }
        public string SecondPlayerName { get; set; }

        private Dictionary<int, string> scoreMapping = new Dictionary<int, string>
            {
                {0, "Love"},
                {1, "Fifteen"},
                {2, "Thirty"},
                {3, "Forty"},
            };

        public bool IsWin()
        {
            return Math.Abs(this.FirstPlayerScore - this.SecondPlayerScore) > 1;
        }

        public string AdvName()
        {
            return this.FirstPlayerScore > this.SecondPlayerScore
                ? this.FirstPlayName
                : this.SecondPlayerName;
        }

        public bool IsReadyForWin()
        {
            return this.FirstPlayerScore > 3 || this.SecondPlayerScore > 3;
        }

        public string AdvStatus()
        {
            return this.AdvName() + (this.IsWin() ? " Win" : " Adv");
        }

        public bool IsNormalScore()
        {
            return this.FirstPlayerScore != this.SecondPlayerScore;
        }

        public string NormalScore()
        {
            return scoreMapping[this.FirstPlayerScore] + " " + scoreMapping[this.SecondPlayerScore];
        }

        public string SameScore()
        {
            return scoreMapping[this.FirstPlayerScore] + " All";
        }

        public bool IsDeuce()
        {
            return this.FirstPlayerScore >= 3;
        }
    }
}