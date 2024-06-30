using System;
using UnityEngine;

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
        }

        [SerializeField]
        private TurnPhase _currentPhase;


        private void Start()
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                AdvancePhase();
            }
        }

        public void AdvancePhase()
        {
            _currentPhase++;

            if ((int)_currentPhase >= System.Enum.GetValues(typeof(TurnPhase)).Length)
            {
                _currentPhase = 0;
            }
            
            switch (_currentPhase)
            {
                case TurnPhase.Player:
                    break;
                case TurnPhase.Enemy:
                    AdvancePhase();
                    break;
            }
        }
    }
}