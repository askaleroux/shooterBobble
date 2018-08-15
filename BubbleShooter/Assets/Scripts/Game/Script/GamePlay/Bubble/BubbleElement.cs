using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{
    public enum BubbleColor
    {
        Purple,
        Blue,
        Red,
        Green,
        Black,
        Orange,
        While,
        Ranbow
    };

    public class BubbleElement : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer _bubbleSprite;

        private float _movingSpeed;
        private bool _isMoving;
        private float _headingAngle;

        BubbleElement()
        {
            
        }

        public void SetSprite(Sprite sprite)
        {
            _bubbleSprite.sprite = sprite;
        }

        public void SetBubbleStatus(bool isMoving,float angle,float speed)
        {
            _isMoving = isMoving;
            _headingAngle = angle;
            _movingSpeed = speed;
        }
    }
}