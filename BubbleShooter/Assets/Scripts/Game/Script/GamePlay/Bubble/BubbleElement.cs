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
        public bool IsMoving;
        private float _headingAngle;

        BubbleElement()
        {
            
        }

        public void SetSprite(Sprite sprite)
        {
            _bubbleSprite.sprite = sprite;
        }

        public void SetShootingBubbleStatus(float angle,float speed)
        {
            _headingAngle = angle;
            _movingSpeed = speed;
        }
    }
}