using System;
using UnityEngine;

namespace Core
{
    public class GameStateController : MonoBehaviour
    {

        #region Singleton
        public static GameStateController Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
        #endregion
        
        public enum GameState
        {
            Gameplay,
            Pause,
            None
        }

        public GameState gameState;
        

        public void ChangeGameStateTo(GameState state)
        {
            gameState = state;
        }
    }
}
