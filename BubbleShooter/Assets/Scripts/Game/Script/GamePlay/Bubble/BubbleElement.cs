using System;
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
        public event Action OnDetectMotionStop;
        public event Action<GameObject> OnCollisionStart;

        [SerializeField]
        SpriteRenderer _bubbleSprite;

        private float _movingSpeed;
        public bool IsMoving;
        private float _headingAngle;

        BubbleElement()
        {
            
        }

        void OnTriggerEnter(Collider collider)
        {
            if (IsMoving)
            {
                IsMoving = false;
                if (OnCollisionStart != null)
                {
                    OnCollisionStart(this.gameObject);
                }
            }
        }

        void Update()
        {
            if (IsMoving)
            {
                this.transform.Translate(Vector3.right * this._movingSpeed * Mathf.Cos(Mathf.Deg2Rad * _headingAngle) * Time.deltaTime);
                this.transform.Translate(Vector3.up * this._movingSpeed * Mathf.Sin(Mathf.Deg2Rad * _headingAngle) * Time.deltaTime);
                //if (this.motionDelegate != null)
                //{
                //    if (!this.motionDelegate(this.transform.position))
                //    {
                //        this.transform.Translate(Vector3.left * _movingSpeed * Mathf.Cos(Mathf.Deg2Rad * _headingAngle) * Time.deltaTime);
                //        this.transform.Translate(Vector3.down * _movingSpeed * Mathf.Sin(Mathf.Deg2Rad * _headingAngle) * Time.deltaTime);
                //        this.IsMoving = false;
                //        if (collisionDelegate != null)
                //        {
                //            collisionDelegate(this.gameObject);
                //        }
                //    }
                //    else
                //    {
                //        _UpdateDirection();
                //    }
                //}
            }
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

        private void _UpdateDirection()
        {

            /*TODO: Piority Medium
			 * Warning, since we are updating after moving, there is a chance that 
			 * we could fall outside of the border if there was not sufficent time between 
			 * two clock ticks. Improvement: Move only until the border coordinate max, and if there is an excess,
			 * move the excess in the opposite direction 
			 * 
			 */

            //if (this.transform.position.x + this.radius >= this.rightBorder || this.transform.position.x - this.radius <= this.leftBorder)
            //{
            //    this.angle = 180.0f - this.angle;
            //    if (this.transform.position.x + this.radius >= this.rightBorder)
            //        this.transform.position = new Vector3(this.rightBorder - this.radius, this.transform.position.y, this.transform.position.z);
            //    if (this.transform.position.x - this.radius <= this.leftBorder)
            //        this.transform.position = new Vector3(this.leftBorder + this.radius, this.transform.position.y, this.transform.position.z);
            //}

            //if (this.transform.position.y + this.radius >= this.topBorder)
            //{
            //    this.isMoving = false;
            //    if (collisionDelegate != null)
            //    {
            //        collisionDelegate(this.gameObject);
            //    }
            //}
        }
    }
}