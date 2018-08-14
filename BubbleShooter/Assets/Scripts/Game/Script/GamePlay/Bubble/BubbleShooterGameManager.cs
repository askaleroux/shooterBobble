using Hanswu.bubble;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hanswu.bubble
{
    public class BubbleShooterGameManager : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] _bubbleSprites;

        [SerializeField]
        private GameObject _bubbleContainer;

        [SerializeField]
        private GameObject _bubbleShooter;

        [SerializeField]
        private BubbleElement _currentBubble;

        [SerializeField]
        private BubbleElement _nextBubble;


        private BubbleMatrix _bubbleMatrix;
        private List<BubbleElement> _controlledBubbles = new List<BubbleElement>();

        private int rows = 10;
        private int columns = 10;

        public void Initialize(Difficulty difficulty)
        {
            _bubbleMatrix = new BubbleMatrix(rows, columns);
            
        }


        private BubbleElement _CreateBubble()
        {
            return null;
        }

       

    }

}