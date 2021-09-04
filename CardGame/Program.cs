using System;
using System.Collections.Generic;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing game provider.
            GameProvider gameProvider = new GameProvider();

            // Setting deck of Cards.
            List<int> deckOfCards = gameProvider.GetDeckOfCards();

            // Shuffling the cards.
            List<int> shuffledCards = gameProvider.ShuffleCards(deckOfCards);

            // This list will contain first player's card.
            List<int> cardsForPlayer1 = new List<int>();

            // This list will contain second player's card.
            List<int> cardsForPlayer2 = new List<int>();

            // Distributing cards to players one by one from the shuffled cards.
            gameProvider.DistributeCards(shuffledCards, cardsForPlayer1, cardsForPlayer2);

            // Setting First Player. 
            Player firstPlayer = new Player();
            firstPlayer.SetPlayer("Player 1", cardsForPlayer1, new List<int>());

            //Setting Second Player.
            Player secondPlayer = new Player();
            secondPlayer.SetPlayer("Player 2", cardsForPlayer2, new List<int>());

            // Starting game between them.
            gameProvider.StartGame(firstPlayer, secondPlayer);

            Console.ReadKey();

        }
    }
}
