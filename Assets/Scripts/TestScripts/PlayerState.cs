using UnityEngine;

namespace TestScripts
{
    /**
     *
     * 
     */
    public class PlayerState
    {
        /**
         *
         * 
         */
        public uint Stability
        {
            get => _stability;
            set => _stability -= value;
        }

        public int Forthcoming
        {
            get => _forthcoming;
            set => _forthcoming += value;
        }

        /**
         *
         * 
         */
        public Deck Deck { get => _deck; set => _deck = value; }

        private uint _stability;
        private int _forthcoming;
        private Deck _deck;
    }
}