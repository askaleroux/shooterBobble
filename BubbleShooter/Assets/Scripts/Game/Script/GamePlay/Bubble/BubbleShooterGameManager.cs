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

        [SerializeField]
        private GameObject _shooterGameobject;


        private readonly Vector3 CURRENT_BUBBLE_SCALE = new Vector3(0.85f, 0.85f, 1f);
        private readonly Vector3 NEXT_BUBBLE_SCALE = new Vector3(0.65f, 0.65f, 1f);

        private BubbleElement _currentBubble;
        private BubbleElement _nextBubble;
        private BubbleMatrixGeoInfo _geoInfo;
        private BubbleMatrixManager _gameManager;
        private List<BubbleElement> _controlledBubbles = new List<BubbleElement>();
        private bool isGameFinished;

        private int _rows = 4;
        private int _columns = 8;

        private float _leftBorder = -2.04f;
        private float _rightBorder = 2.04f;
        private float _topBorder = 2.95f;

        private float _bubbleRadius = 0.255f;
        private float _addRowPeriod = 10.0f;


        public void Initialize(Difficulty difficulty)
        {
            _geoInfo = new BubbleMatrixGeoInfo(_leftBorder, _rightBorder, _topBorder, _rows, _columns, _bubbleRadius);
            _gameManager = BubbleMatrixManager.GetInstance(_rows,_columns, _geoInfo, difficulty);
            _currentBubble = _CreateBubble(_currentBubbleRoot, CURRENT_BUBBLE_SCALE);
            _nextBubble = _CreateBubble(_nextBubbleRoot,NEXT_BUBBLE_SCALE);

            for(int i =0;i<_rows;++i)
            {
                AddNewRowToMatrix();
            }
        }

        private BubbleElement _CreateBubble(Transform root,Vector3 scale)
        {
            var bubbleGo = Instantiate(_bubblePrefab, root);
            bubbleGo.transform.SetAsLastSibling();
            bubbleGo.transform.localScale = scale;
            var bubbleElement = bubbleGo.GetComponent<BubbleElement>();
            var colorIndex = UnityEngine.Random.Range(0, Enum.GetNames(typeof(BubbleColor)).Length);
            bubbleElement.SetSprite(_bubbleSprites[colorIndex]);
            _controlledBubbles.Add(bubbleElement);
            return bubbleElement;
        }

        private void Update()
        {
            if((Input.GetKeyDown(KeyCode.Space))&& !isGameFinished)
            {
                _currentBubble.GetComponent<Rigidbody>().isKinematic = false;
                _currentBubble.IsMoving = true;
                _currentBubble.SetShootingBubbleStatus(_GetShootingAngle(), 5f);
                _nextBubble.transform.position = _currentBubble.transform.position;
                _nextBubble.transform.localScale = CURRENT_BUBBLE_SCALE;
                _currentBubble = _nextBubble;
                _nextBubble = _CreateBubble(_nextBubbleRoot, CURRENT_BUBBLE_SCALE);
            }
        }

        public void AddNewRowToMatrix()
        {
			bool overflows = _gameManager.GetBubbleMatrix().ShiftOneRow();
			
			for (int i = 0; i<this._geoInfo.Columns; i++)
            {
				BubbleElement bubble = _CreateBubble(_bubbleContainer.transform,CURRENT_BUBBLE_SCALE);
                bubble.IsMoving = false;
				_gameManager.GetBubbleMatrix().AddBubble(bubble, 0,i);
			}
			
			foreach (var bubble in _controlledBubbles )
            {
				if (bubble != _currentBubble && bubble!=_nextBubble)
                {
					Vector3 position = _gameManager.GetPositionFromCellCoord(_gameManager.GetBubbleMatrix().GetBubbleLocation(bubble));		
					bubble.transform.localPosition = position;
				}
			}
			
			if (overflows)
            {
                OnChangeGameState(GameState.Loose);
				return;
			}
        }

        private float _GetShootingAngle()
        {
            float shooterRotation = _shooterGameobject.transform.eulerAngles.z;

            float ballRotation = 90;
            if (shooterRotation <= 360 && shooterRotation >= 270.0)
            {
                ballRotation = shooterRotation - 270;
            }
            if (shooterRotation <= 90 && shooterRotation >= 0)
            {
                ballRotation = 90 + shooterRotation;
            }

            return ballRotation;
        }

        private bool _CanMoveToPosition(Vector3 position)
        {
            Vector2 location = _gameManager.GetCellCoordFromPosition(position);
            if ((int)location.x <= _geoInfo.Rows - 1)
            {
                return !_gameManager.GetBubbleMatrix().HasBubble((int)location.x, (int)location.y);
            }
            return true;
        }

    }

}