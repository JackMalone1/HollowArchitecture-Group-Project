using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestScripts
{
    /**
     *
     * 
     */
    public enum TurnPhase
    {
        Player,
        Enemy
    }
    
    /**
     *
     * 
     */
    public class CardBattleManager : MonoBehaviour
    {
        public static CardBattleManager instance;

        private void Awake()
        {
            instance = this;
        }

        /**
         *
         * 
         */
        public TurnPhase CurrentPhase { get => currentPhase; private set => currentPhase = value; }

        [SerializeField]
        private TurnPhase currentPhase;
        
        private PlayerState _playerState;
        
        private PlayerState _enemyState;

        private void Start()
        {
            var cards = Resources.LoadAll("ScriptableObjects/Cards").ToList();
            List<Card> cardsList = new List<Card>();
            cards.ForEach(x =>
            {
                cardsList.Add(x as Card);
            });

            var playerDeck = new Deck(new List<Card>());
            playerDeck.FillWithRandomCardsFromPool(cardsList, 5);
            
            _playerState = new PlayerState();
            _playerState.Deck = playerDeck;
            
            var enemyDeck = new Deck(new List<Card>());
            enemyDeck.FillWithRandomCardsFromPool(cardsList, 5);
            
            _enemyState = new PlayerState();
            _enemyState.Deck = enemyDeck;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                AdvancePhase();
            }
        }

        /**
         *
         * 
         */
        public void AdvancePhase()
        {
            currentPhase++;

            if ((int)currentPhase >= System.Enum.GetValues(typeof(TurnPhase)).Length)
            {
                currentPhase = 0;
            }
            
            switch (currentPhase)
            {
                case TurnPhase.Player:
                    break;
                case TurnPhase.Enemy:
                    AdvancePhase();
                    break;
            }
        }

        /**
         *
         * 
         */
        public void EndPlayerTurn()
        {
            AdvancePhase();
        }
    }
}