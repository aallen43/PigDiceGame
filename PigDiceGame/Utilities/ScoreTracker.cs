using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame.Utilities
{
    internal class ScoreTracker
    {
        public int TotalScore { get; private set; }
        public int TurnScore { get; private set; }
        public bool HasWon { get { return TotalScore == 21 || TurnScore == 21; } }

        public void IncreaseScore(int amount)
        {
            TurnScore += amount;
        }
        public void DecreaseScore(int amount)
        {
            TurnScore -= amount;
        }
        public void ClearTurnScore()
        {
            TurnScore = 0;
        }
        public void CalculateTurnScore()
        {
            TotalScore += TurnScore;
        }
    }
}
