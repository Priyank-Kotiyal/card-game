using System;
using System.Collections.Generic;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameProvider gameProvider = new GameProvider();
            List<int> deckOfCards = gameProvider.GetDeckOfCards();
            List<int> shuffledCards = gameProvider.ShuffleCards(deckOfCards);

            List<int> cardsForPlayer1 = new List<int>();
            List<int> cardsForPlayer2 = new List<int>();

            gameProvider.DistributeCards(shuffledCards, cardsForPlayer1, cardsForPlayer2);

            Player firstPlayer = new Player();
            firstPlayer.SetPlayer("Player 1", cardsForPlayer1, new List<int>());

            Player secondPlayer = new Player();
            secondPlayer.SetPlayer("Player 2", cardsForPlayer2, new List<int>());

            gameProvider.StartGame(firstPlayer, secondPlayer);

            Console.ReadKey();

        }
    }
}
