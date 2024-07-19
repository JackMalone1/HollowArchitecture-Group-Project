using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

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

        private readonly List<CardDisplay> _playerHand = new();
        private readonly List<CardDisplay> _enemyHand = new();

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
            
            _playerState.Deck.DrawCards(2);
            _enemyState.Deck.DrawCards(2);
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
                Destroy(transform.gameObject);
            }

            Transform cardLocation = null;
            _playerState.Deck.DrawCards(1);
            var playerHand = _playerState.Deck.Hand;
            foreach (var cardDisplay in _playerHand)
            {
                Destroy(cardDisplay);  
            }
            _playerHand.Clear();
            int index = 0;
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
                comp.UpdateDisplay(TurnPhase.Player, index);
                position = new Vector3(position.x - .75f, position.y,
                    position.z);
                cardLocation.position = position;
                _playerHand.Add(comp);
                index++;
            }
        }

        public void PlayerUseCard(int index)
        {
            _playerState.Deck.UseCard(index);
            Card card = _playerState.Deck.Hand.CurrentCards.ElementAt(index);
            //use card here
            AdvancePhase();
        }

        private void EnemyTurn()
        {
            foreach (Transform transform in CardHolder.transform)
            {
                Destroy(transform.gameObject);
            }

            Transform cardLocation = null;
            _enemyState.Deck.DrawCards(1);
            var enemyHand = _enemyState.Deck.Hand;
            foreach (var cardDisplay in _enemyHand)
            {
                Destroy(cardDisplay);  
            }
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
                comp.UpdateDisplay(TurnPhase.Enemy, 0);
                position = new Vector3(position.x - .75f, position.y,
                    position.z);
                cardLocation.position = position;
                _enemyHand.Add(comp);
            }

            StartCoroutine(WaitForTime());
        }

        IEnumerator WaitForTime()
        {
            yield return new WaitForSeconds(5.0f);
            //make enemy pick a card here and then switch turn
            var enemyHand = _enemyState.Deck.Hand.CurrentCards.Count;
            int cardToUse = Random.Range(0, enemyHand);
            Card card = _enemyState.Deck.Hand.CurrentCards.ElementAt(cardToUse);
            _enemyState.Deck.UseCard(cardToUse);
            //use card here
            AdvancePhase();
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