using UnityEngine;

namespace TestScripts
{
    /**
     *
     * 
     */
    public class PlayerState : MonoBehaviour
    {
        /**
         *
         * 
         */
        public uint Stability
        {
            get
            {
                return _stability;
            }
            set => _stability -= value;
        }

        private uint _stability;
    }
}