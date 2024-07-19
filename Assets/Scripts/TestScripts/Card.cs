#nullable enable

using System.ComponentModel;
using UnityEngine;

namespace TestScripts
{
    public enum CardType
    {
        [Description("Influence")]
        Influence,
        [Description("Reflect")]
        Reflect,
        [Description("Protect")]
        Protect,
        [Description("Unique")]
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

        public Sprite? Sprite { get => sprite; set => sprite = value; }

        public CardType CardType { get => cardType; private set => cardType = value; }
        public bool IsUsable => CardBattleManager.instance.CurrentPhase == TurnPhase.Player;

        [SerializeField]
        private int cardValue;

        [SerializeField]
        private CardType cardType;

        [SerializeField]
        private Sprite? sprite;
    }
}