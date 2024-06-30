#nullable enable

using UnityEngine;

namespace TestScripts
{
    public enum CardType
    {
        Influence,
        Reflect,
        Protect,
        Unique
    }
    
    [CreateAssetMenu(fileName = "Card", menuName = "CardMiniGame/Card", order = 1)]
    public class Card : ScriptableObject
    {
        public int CardValue
        {
            get => cardValue;
            private set => cardValue = value;
        }

        public CardType CardType { get => cardType; private set => cardType = value; }

        [SerializeField]
        private int cardValue;

        [SerializeField]
        private CardType cardType;
    }
}