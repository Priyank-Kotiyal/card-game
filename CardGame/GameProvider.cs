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
            // Setting static cards in deck.
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
            // Iterating over shuffled cards. And assigning cards to player alternatively.
            for (int i = 0; i < shuffledCards.Count; i++)
            {
                // Cards at Odd index will be assigned to first player.
                if (i % 2 != 0)
                {
                    cardsForPlayer1.Add(shuffledCards[i]);
                }
                else // Cards at Even index will be assigned to second player.
                {
                    cardsForPlayer2.Add(shuffledCards[i]);
                }
            }
        }

        public int DrawCard(Player player)
        {
            // If Drwa pile is empty then shuffling DiscardPile and putting it in DrawPile.
            // Also resetting the discard pile.
            if (player.DrawPile.Count < 1)
            {
                player.DrawPile = ShuffleCards(player.DiscardPile);
                player.DiscardPile = new List<int>();
            }
            // Picking last(top of deck) element from the pile.
            return player.DrawPile[player.DrawPile.Count - 1];
        }

        public void StartGame(Player player1, Player player2)
        {
            List<int> drawnCards = new List<int>();
            // Running the loop/Round until we get the winner.
            while (GetWinner(player1, player2) == null)
            {
                // Drawing card from each player.
                int player1Card = DrawCard(player1);
                int player2Card = DrawCard(player2);
                
                // Printing the current status at start.
                Console.WriteLine(player1.PlayerName + " (" + (player1.DrawPile.Count + player1.DiscardPile.Count) + ") cards : " + player1Card);
                Console.WriteLine(player2.PlayerName + " (" + (player2.DrawPile.Count + player2.DiscardPile.Count) + ") cards : " + player2Card);
                
                // This is used to keep who wins/loses/draws the round.
                int roundWinner = 0;
                // Fetching higher card.
                int higherCard = CompareCards(player1Card, player2Card);
                // Checking which card is higher. If player 1 has higher then he wins.
                if (higherCard == player1Card)
                {
                    // Putting both cards in Player1's discard pile.
                    player1.DiscardPile.Add(player1Card);
                    player1.DiscardPile.Add(player2Card);
                    // Putting cards from previous drawn rounds in player1's discard pile.
                    foreach (int item in drawnCards)
                    {
                        player1.DiscardPile.Add(item);
                    }
                    // Clearing drawn pile.
                    drawnCards = new List<int>();
                    // Setting Player1 as winner.
                    roundWinner = 1;
                }
                // Checking which card is higher. If player 2 has higher then he wins.
                else if (higherCard == player2Card)
                {
                    // Putting both cards in Player2's discard pile.
                    player2.DiscardPile.Add(player1Card);
                    player2.DiscardPile.Add(player2Card);
                    // Putting cards from previous drawn rounds in player2's discard pile.
                    foreach (int item in drawnCards)
                    {
                        player2.DiscardPile.Add(item);
                    }
                    // Clearing drawn pile.
                    drawnCards = new List<int>();
                    // Setting Player2 as winner.
                    roundWinner = 2;
                }
                else // higherCard == 0
                {
                    // Putting both cards in drawn pile.
                    drawnCards.Add(player1Card);
                    drawnCards.Add(player2Card);
                }

                // Removing top cards as they are moved to either drawn pile and player's dicard pile.
                player1.DrawPile.RemoveAt(player1.DrawPile.Count - 1);
                player2.DrawPile.RemoveAt(player2.DrawPile.Count - 1);

                // Printing message for round.
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
            // Fetching winner for the game.
            Player winner = GetWinner(player1, player2);
            Console.WriteLine(winner.PlayerName + " wins the game!");
        }

        public Player GetWinner(Player player1, Player player2)
        {
            // If any player's both DrawPile and Discard Pile are empty then other player wins.
            if (player1.DrawPile.Count == 0 && player1.DiscardPile.Count == 0)
                return player2;
            if (player2.DrawPile.Count == 0 && player2.DiscardPile.Count == 0)
                return player1;
            return null;
        }

        public int CompareCards(int card1, int card2)
        {
            // Returning higher card and 0 in case of draw.
            if (card1 > card2)
                return card1;
            else if (card2 > card1)
                return card2;
            else
                return 0;
        }
    }
}
