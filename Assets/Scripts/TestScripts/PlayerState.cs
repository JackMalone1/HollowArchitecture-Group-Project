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

        /**
         *
         * 
         */
        public Deck Deck { get => _deck; set => _deck = value; }

        private uint _stability;
        private Deck _deck;
    }
}