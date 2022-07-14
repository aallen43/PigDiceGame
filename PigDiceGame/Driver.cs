using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PigDiceGame.Utilities;

namespace PigDiceGame
{
    internal class Driver
    {
        private ScoreTracker playerScoreTracker;
        private ScoreTracker computerScoreTracker;
        private Dice dice;

        public Driver()
        {
            playerScoreTracker = new ScoreTracker();
            computerScoreTracker = new ScoreTracker();
            dice = new Dice();
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the game of Pig!");
            while(!playerScoreTracker.HasWon && !computerScoreTracker.HasWon)
            {
                RunPlayerTurn();
                RunComputerTurn();
            }
        }

        public void RunPlayerTurn()
        {
            Console.WriteLine();
            Console.WriteLine("Player Turn:");
            while(Console.ReadLine() == "roll" && !playerScoreTracker.HasWon)
            {
                var diceRoll = dice.Roll();
                Console.WriteLine($"Dice Roll: {diceRoll}");
                if (diceRoll == 1)
                {
                    playerScoreTracker.ClearTurnScore();
                    break;
                }
                playerScoreTracker.IncreaseScore(diceRoll);
                Console.WriteLine($"Turn Score: {playerScoreTracker.TurnScore}");
            }
            playerScoreTracker.ClearTurnScore();
            Console.WriteLine($"Player Total Score: {playerScoreTracker.TotalScore}");
        }

        public void RunComputerTurn()
        {
            Console.WriteLine();
            Console.WriteLine("Computer Turn:");
            while(computerScoreTracker.TurnScore != 14)
            {
                var diceRoll = dice.Roll();
                Console.WriteLine(diceRoll);
                if (diceRoll == 1)
                {
                    computerScoreTracker.ClearTurnScore();
                    break;
                }
                computerScoreTracker.IncreaseScore(diceRoll);
            }
        }
    }
}
