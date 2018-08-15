using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{
    public enum GameState
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
        public GameState _gameState;


        private void Start()
        {
            _InitializeGame();
            StartCoroutine(_Game());
        }

        private void _InitializeGame()
        {
            _gameState = GameState.Playing;
            GameObject go = Instantiate(_bubbleShooterGameManager, _root);
            go.SetActive(true);
            _manager = go.GetComponent<BubbleShooterGameManager>();
            _manager.Initialize(Difficulty.Easy);
            _manager.OnChangeGameState += _OnChangeGameState;
        }

        private IEnumerator _Game()
        {
            while(_gameState==GameState.Playing)
            {
                yield return null;
            }
        }

        private void _OnChangeGameState(GameState state)
        {
            _gameState = state;
        }

    }
}