#nullable enable

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestScripts
{
    public class Deck
    {
        public Stack<Card> CurrentCards
        {
            get
            {
                _currentCards ??= new Stack<Card>();
                return _currentCards;
            }
            private set => _currentCards = value;
        }

        public List<Card> DiscardPile
        {
            get
            {
                _discardPile ??= new List<Card>();
                return _discardPile;
            }
            private set => _discardPile = value;
        }

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

        public void DrawCards(int NumberOfCardsToDraw)
        {
            if (!CurrentCards.Any())
            {
                CurrentCards = new Stack<Card>(DiscardPile);
                DiscardPile.Clear();
            }

            if (NumberOfCardsToDraw > CurrentCards.Count)
            {
                NumberOfCardsToDraw = CurrentCards.Count;
            }

            for (int i = 0; i < NumberOfCardsToDraw; i++)
            {
                Hand.AddCard(CurrentCards.Pop());
            }
        }
    }
}