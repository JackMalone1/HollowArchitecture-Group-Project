#nullable enable

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestScripts
{
    /**
     *
     * 
     */
    public class Deck
    {
        /**
         *
         * 
         */
        public Stack<Card> CurrentCards
        {
            get
            {
                _currentCards ??= new Stack<Card>();
                return _currentCards;
            }
            private set => _currentCards = value;
        }

        /**
         *
         * 
         */
        public List<Card> DiscardPile
        {
            get
            {
                _discardPile ??= new List<Card>();
                return _discardPile;
            }
            private set => _discardPile = value;
        }

        /**
         *
         * 
         */
        public Hand Hand { get => _hand; private set => _hand = value; }

        [Tooltip("Used to draw the initial hand that we will use"), Range(1, 10)]
        private const uint StartingHandSize = 3;

        private Stack<Card>? _currentCards;
        private List<Card>? _discardPile;

        private Hand _hand = new();

        public Deck(List<Card> deckList)
        {
            CurrentCards = new Stack<Card>(deckList);
            DrawCards((int)StartingHandSize);
        }

        /**
         *
         * 
         */
        public void FillWithRandomCardsFromPool(List<Card> cardPool, int cardsToTake)
        {
            if (!cardPool.Any() || cardPool.Count < cardsToTake)
            {
                return;
            }

            CurrentCards = new Stack<Card>(cardPool
                .OrderBy(card => Random.value)
                .Take(cardsToTake));
        }

        /**
         *
         * 
         */
        public void DrawCards(int numberOfCardsToDraw)
        {
            if (!CurrentCards.Any())
            {
                CurrentCards = new Stack<Card>(DiscardPile);
                DiscardPile.Clear();
            }

            if (numberOfCardsToDraw > CurrentCards.Count)
            {
                numberOfCardsToDraw = CurrentCards.Count;
            }

            for (int i = 0; i < numberOfCardsToDraw; i++)
            {
                Hand.AddCard(CurrentCards.Pop());
            }
        }

        /**
         *
         * 
         */
        public void UseCard(int index)
        {
            _discardPile?.Add(Hand.CurrentCards.ElementAt(index));
            Hand.UseCard(index);
        }

        public void ShuffleRemaining()
        {
            CurrentCards.Shuffle();
        }

        public void ShuffleBackDiscardAndDeck()
        {
            _discardPile.ForEach(card => CurrentCards.Push(card));
            _discardPile.Clear();
            ShuffleRemaining();
        }
        
    }
}