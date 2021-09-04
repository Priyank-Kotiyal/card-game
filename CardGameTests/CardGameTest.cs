using CardGame;
using NUnit.Framework;
using System.Collections.Generic;

namespace CardGameTests
{
    public class Tests
    {
        private GameProvider _gameProvider;
        [SetUp]
        public void Setup()
        {
            _gameProvider = new GameProvider();
        }

        [Test]
        public void ShouldContainFourtyCardsInANewDeck()
        {
            List<int> deckOfCards = _gameProvider.GetDeckOfCards();
            Assert.AreEqual(40, deckOfCards.Count);
        }

        [Test]
        public void ShouldShuffleANewDeck()
        {
            List<int> deckOfCards = _gameProvider.GetDeckOfCards();
            List<int> shuffledDeck = _gameProvider.ShuffleCards(deckOfCards);
            int countSameElementAtIndex = 0;
            for(int i = 0; i < shuffledDeck.Count; i++)
            {
                if (deckOfCards[i] == shuffledDeck[i])
                {
                    countSameElementAtIndex++;
                }
            }
            Assert.AreNotEqual(40, countSameElementAtIndex);
        }

        [Test]
        public void IfDrawPileEmptySetFromDiscardPile()
        {
            Player player = new Player();
            player.SetPlayer("Player 1", new List<int>(), _gameProvider.GetDeckOfCards());
            _gameProvider.DrawCard(player);
            Assert.NotZero(player.DrawPile.Count);
        }

        [Test]
        public void IfDrawThenNextRoundWinnerGetsFourCards()
        {
            Player player1 = new Player();
            List<int> player1Cards = new List<int>();
            player1Cards.Add(3);
            player1Cards.Add(1);
            player1.SetPlayer("Player 1", player1Cards, new List<int>());

            Player player2 = new Player();
            List<int> player2Cards = new List<int>();
            player2Cards.Add(9);
            player2Cards.Add(1);
            player2.SetPlayer("Player 2", player2Cards, new List<int>());

            _gameProvider.StartGame(player1, player2);
            _gameProvider.DrawCard(player2);
            Assert.AreEqual(4, player2.DrawPile.Count);
        }

        [Test]
        public void HigherCardShouldWin()
        {
            int card1 = 9;
            int card2 = 7;
            int card = _gameProvider.CompareCards(card1, card2);
            Assert.AreEqual(card1, card);
        }
    }
}