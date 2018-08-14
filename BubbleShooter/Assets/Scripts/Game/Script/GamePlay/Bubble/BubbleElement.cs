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

        private BubbleMatrixGeoInfo _matrixGeoInfo;
        private float _movingSpeed;
        private float _isMoving;
        private float _headingAngle;

        BubbleElement(Sprite sprite,BubbleMatrixGeoInfo matrixGeoInfo)
        {
            _bubbleSprite.sprite = sprite;
        }
    }
}