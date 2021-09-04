using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class GameProvider
    {

        public List<int> GetDeckOfCards()
        {
            int[] deckOfCards = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            };
            return deckOfCards.ToList();
        }

        public List<int> ShuffleCards(List<int> cards) {
            // Declaring object for Random class to get random no b/w the range.
            Random random = new Random();
            List<int> shuffledCards = cards.ToList();
            // Iterating over each element one by one.
            for (int i = 0; i < shuffledCards.Count - 1; i++)
            {
                // Getting random no b/w i & length to set random index. i.e Starting from 0-40, 1-40, 2-40 ... so on.
                int j = random.Next(i, cards.Count);

                // Now swapping current element with random index.
                int temp = shuffledCards[i];
                shuffledCards[i] = shuffledCards[j];
                shuffledCards[j] = temp;
            }
            return shuffledCards;
        }

        public void DistributeCards(List<int> shuffledCards, List<int> cardsForPlayer1, List<int> cardsForPlayer2)
        {
            for (int i = 0; i < shuffledCards.Count; i++)
            {
                if (i % 2 != 0)
                {
                    cardsForPlayer1.Add(shuffledCards[i]);
                }
                else
                {
                    cardsForPlayer2.Add(shuffledCards[i]);
                }
            }
        }

        public int DrawCard(Player player)
        {
            if (player.DrawPile.Count < 1)
            {
                player.DrawPile = ShuffleCards(player.DiscardPile);
                player.DiscardPile = new List<int>();
            }
            return player.DrawPile[player.DrawPile.Count - 1];
        }

        public void StartGame(Player player1, Player player2)
        {
            List<int> drawnCards = new List<int>();
            while (GetWinner(player1, player2) == null)
            {
                int player1Card = DrawCard(player1);
                int player2Card = DrawCard(player2);

                Console.WriteLine(player1.PlayerName + " (" + (player1.DrawPile.Count + player1.DiscardPile.Count) + ") cards : " + player1Card);
                Console.WriteLine(player2.PlayerName + " (" + (player2.DrawPile.Count + player2.DiscardPile.Count) + ") cards : " + player2Card);
                
                int roundWinner = 0;
                if (CompareCards(player1Card, player2Card) == player1Card)
                {
                    player1.DiscardPile.Add(player1Card);
                    player1.DiscardPile.Add(player2Card);

                    foreach (int item in drawnCards)
                    {
                        player1.DiscardPile.Add(item);
                    }

                    drawnCards = new List<int>();
                    roundWinner = 1;
                }
                else if (CompareCards(player1Card, player2Card) == player2Card)
                {
                    player2.DiscardPile.Add(player1Card);
                    player2.DiscardPile.Add(player2Card);

                    foreach (int item in drawnCards)
                    {
                        player2.DiscardPile.Add(item);
                    }

                    drawnCards = new List<int>();
                    roundWinner = 2;
                }
                else // CompareCards(player1Card, player2Card) == 0
                {
                    drawnCards.Add(player1Card);
                    drawnCards.Add(player2Card);
                }

                player1.DrawPile.RemoveAt(player1.DrawPile.Count - 1);
                player2.DrawPile.RemoveAt(player2.DrawPile.Count - 1);

                switch (roundWinner)
                {
                    case 0: Console.WriteLine("No winner in this round");
                        break;
                    case 1:
                        Console.WriteLine(player1.PlayerName + " wins this round");
                        break;
                    case 2:
                        Console.WriteLine(player2.PlayerName + " wins this round");
                        break;
                }
                Console.WriteLine();
            }
            Player winner = GetWinner(player1, player2);
            Console.WriteLine(winner.PlayerName + " wins the game!");
        }

        public Player GetWinner(Player player1, Player player2)
        {
            if (player1.DrawPile.Count == 0 && player1.DiscardPile.Count == 0)
                return player2;
            if (player2.DrawPile.Count == 0 && player2.DiscardPile.Count == 0)
                return player1;
            return null;
        }

        public int CompareCards(int card1, int card2)
        {
            if (card1 > card2)
                return card1;
            else if (card2 > card1)
                return card2;
            else
                return 0;
        }
    }
}
