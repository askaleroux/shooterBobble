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

        BubbleElement(Sprite sprite)
        {
            _bubbleSprite.sprite = sprite;
        }
    }
}