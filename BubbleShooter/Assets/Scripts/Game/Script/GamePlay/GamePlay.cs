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
        [SerializeField]
        private GameObject _bubbleShooterGameManager;
        [SerializeField]
        private RectTransform _root;

        private BubbleShooterGameManager _manager;
        private GameState _gameState;

        private void Start()
        {
            _InitializeGame();
        }

        private void _InitializeGame()
        {
            _gameState = GameState.Playing;
            GameObject go = Instantiate(_bubbleShooterGameManager, _root);
            _manager = go.GetComponent<BubbleShooterGameManager>();
            _manager.Initialize(Difficulty.Easy);

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