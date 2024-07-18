using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestScripts
{

    public enum TurnPhase
    {
        Player,
        Enemy
    }
    

    public class CardBattleManager : MonoBehaviour
    {
        public static CardBattleManager instance;

        private void Awake()
        {
            instance = this;
            DialogueSystem.GetInstance().StopStory();
        }


        public TurnPhase CurrentPhase { get => currentPhase; private set => currentPhase = value; }

        public GameObject card;

        public GameObject CardHolder;

        public Transform cardLocation;

        [SerializeField]
        private TurnPhase currentPhase;
        
        private PlayerState _playerState;
        
        private PlayerState _enemyState;

        private List<CardDisplay> _playerHand = new List<CardDisplay>();
        private List<CardDisplay> _enemyHand = new List<CardDisplay>();

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

            var enumerator = PlayerData.SetCountry();
            var data = enumerator.Current;
            
            HandlePhase();
        }

        void HandlePhase()
        {
            switch (currentPhase)
            {
                case TurnPhase.Player:
                    PlayerTurn();
                    break;
                case TurnPhase.Enemy:
                    EnemyTurn();
                    break;
            }
        }

        private void PlayerTurn()
        {
            foreach (Transform transform in CardHolder.transform)
            {
                UnityEngine.Object.Destroy(transform.gameObject);
            }

            Transform cardLocation = null;
            _playerState.Deck.DrawCards(2);
            var playerHand = _playerState.Deck.Hand;
            _playerHand.Clear();
            foreach (var cardInHand in playerHand.CurrentCards)
            {
                var cardDisplay = Instantiate(card, CardHolder.transform);
                if (cardLocation == null)
                {
                    cardLocation = cardDisplay.transform;
                }
                var position = cardLocation.position;
                CardDisplay comp = cardDisplay.GetComponent<CardDisplay>();
                comp.card = cardInHand;
                comp.UpdateDisplay();
                position = new Vector3(position.x - .75f, position.y,
                    position.z);
                cardLocation.position = position;
            }
        }

        private void EnemyTurn()
        {
            foreach (Transform transform in CardHolder.transform)
            {
                UnityEngine.Object.Destroy(transform.gameObject);
            }

            Transform cardLocation = null;
            _enemyState.Deck.DrawCards(2);
            var enemyHand = _enemyState.Deck.Hand;
            _enemyHand.Clear();
            foreach (var cardInHand in enemyHand.CurrentCards)
            {
                var cardDisplay = Instantiate(card, CardHolder.transform);
                if (cardLocation == null)
                {
                    cardLocation = cardDisplay.transform;
                }
                var position = cardLocation.position;
                CardDisplay comp = cardDisplay.GetComponent<CardDisplay>();
                comp.card = cardInHand;
                comp.UpdateDisplay();
                position = new Vector3(position.x - .75f, position.y,
                    position.z);
                cardLocation.position = position;
            }
        }

        public void AdvancePhase()
        {
            currentPhase++;

            if ((int)currentPhase >= System.Enum.GetValues(typeof(TurnPhase)).Length)
            {
                currentPhase = 0;
            }
            
            HandlePhase();
        }
        
    }
}