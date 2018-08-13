using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{
    enum GameState
    {
        Playing,
        Win,
        Loose
    }

    public class GamePlay : MonoBehaviour
    {
        private GameState _gameState;

        private void Start()
        {
                
        }

        private void _InitializeGame()
        {
            _gameState = GameState.Playing;

        }

        private IEnumerator _Game()
        {
            while(_gameState==GameState.Playing)
            {
                yield return null;
            }
        }

    }
}