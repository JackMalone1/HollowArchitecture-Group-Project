#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace TestScripts
{
    /**
     *
     * 
     */
    public class Hand
    {
        /**
         *
         * 
         */
        public List<Card> CurrentCards
        {
            get
            {
                return _currentCards;
            }
            
            private set => _currentCards = value;
        }
        
        private List<Card> _currentCards = new();

        /**
         *
         * 
         */
        public void AddCard(Card card)
        {
            CurrentCards.Add(card);
        }

        /**
         *
         * 
         */
        public void UseCard(int index)
        {
            bool exists = CurrentCards.ElementAt(index) != null;
            if (!exists) return;
            
            CurrentCards.RemoveAt(index);
        }
    }
}