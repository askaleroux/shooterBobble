using Hanswu.bubble;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hanswu.bubble
{
    public class BubbleShooterGameManager : MonoBehaviour
    {
        public event Action<GameState> OnChangeGameState;

        [SerializeField]
        private Sprite[] _bubbleSprites;

        [SerializeField]
        private GameObject _bubbleContainer;

        [SerializeField]
        private GameObject _bubblePrefab;

        [SerializeField]
        private RectTransform _currentBubbleRoot;

        [SerializeField]
        private RectTransform _nextBubbleRoot;


        private readonly Vector3 CURRENT_BUBBLE_SCALE = new Vector3(0.8f, 0.8f, 0.8f);
        private readonly Vector3 NEXT_BUBBLE_SCALE = new Vector3(0.65f, 0.65f, 0.65f);

        private BubbleElement _currentBubble;
        private BubbleElement _nextBubble;
        private BubbleMatrix _bubbleMatrix;
        private BubbleMatrixGeoInfo _geoInfo;
        private BubbleMatrixManager _gameManager;
        private List<BubbleElement> _controlledBubbles = new List<BubbleElement>();
        private bool isGameFinished;

        private int _rows = 10;
        private int _columns = 10;

        private float _leftBorder = 0.0f;
        private float _rightBorder = 10.5f;
        private float _topBorder = 10.0f;

        private float _bubbleRadius = 0.5f;
        private float _addRowPeriod = 10.0f;


        public void Initialize(Difficulty difficulty)
        {
            _bubbleMatrix = new BubbleMatrix(_rows, _columns);
            _geoInfo = new BubbleMatrixGeoInfo(_leftBorder, _rightBorder, _topBorder, _rows, _columns, _bubbleRadius);
            _gameManager = BubbleMatrixManager.GetInstance(_bubbleMatrix, _geoInfo, difficulty);
            _currentBubble = _CreateBubble(_currentBubbleRoot, CURRENT_BUBBLE_SCALE);
            _nextBubble = _CreateBubble(_nextBubbleRoot,NEXT_BUBBLE_SCALE);
        }

        private BubbleElement _CreateBubble(RectTransform root,Vector3 scale)
        {
            var bubbleGo = Instantiate(_bubblePrefab, root);
            bubbleGo.transform.SetAsLastSibling();
            bubbleGo.transform.localScale = scale;
            var bubbleElement = bubbleGo.GetComponent<BubbleElement>();
            var colorIndex = UnityEngine.Random.Range(0, Enum.GetNames(typeof(BubbleColor)).Length);
            bubbleElement.SetSprite(_bubbleSprites[colorIndex]);
            return bubbleElement;
        }

        private void Update()
        {
            if((Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))&& !isGameFinished)
            {
               
            }
        }

        private void _GetShooterAngle()
        {



        }

    }

}