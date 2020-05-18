using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{    public enum GameState
    {
        Start,
        Running,
        Finished
    }
    public class GameControl
    {
        private static GameControl _instance { get; set; }
        public static GameControl Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new GameControl();

                return _instance;
            }
        }

        private GameControl()
        {
            GameState = GameState.Start;
        }

        #region Props   
        private GameState _gameState;
        public GameState GameState
        {
            get { return _gameState; }
            set { _gameState = value; }
        }
        #endregion

        #region GameObjects
        public PlayerMovement player;
        #endregion

        #region Methods
        public void Pause(bool paused)
        {
            if (paused) Time.timeScale = 0.0f;
            else Time.timeScale = 1.0f;
        }

        public void SetGameState(GameState state)
        {
            GameState = state;

            if(state == GameState.Running)
            {
                Pause(false);
            }
        }
        #endregion
    }
}
