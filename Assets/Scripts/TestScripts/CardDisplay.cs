
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TestScripts
{
    public class CardDisplay : MonoBehaviour
    {
        public Card card;

        public Image image;

        public void UpdateDisplay(TurnPhase currentPhase, int cardIndex)
        {
            image.sprite = card.Sprite;
            var canvas = transform.GetChild(0);
            var background = canvas.transform.GetChild(0).GetComponent<Image>();
            var name = canvas.transform.GetChild(1).GetComponent<TextMeshPro>();
            background = image;
            if (name != null)
            {
                name.text = card.CardType.GetDescription();
            }

            if (currentPhase == TurnPhase.Player)
            {
                var button = canvas.GetChild(3).GetComponent<Button>();
                button.onClick.AddListener(delegate { CardBattleManager.instance.PlayerUseCard(cardIndex); });
            }
        }

        public void ChangePhase()
        {
            CardBattleManager.instance.AdvancePhase();
        }
    }
}