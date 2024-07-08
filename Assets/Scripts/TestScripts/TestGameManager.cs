using System;
using UnityEngine;

namespace TestScripts
{
    public class TestGameManager : MonoBehaviour
    {
        public static TestGameManager instance = null;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
            
            DontDestroyOnLoad(gameObject);

            DateTime lastTimePlayed = new DateTime((long)PlayerPrefs.GetFloat(StaticValues.timeLastPlayed));
            
            DateTime now = DateTime.Now;
            
            Debug.Log((now - lastTimePlayed).Days);
            Debug.Log((now - lastTimePlayed).Minutes);
            Debug.Log((now - lastTimePlayed).Seconds);
            
            PlayerPrefs.SetFloat(StaticValues.timeLastPlayed, now.Ticks);
        }
    }
}