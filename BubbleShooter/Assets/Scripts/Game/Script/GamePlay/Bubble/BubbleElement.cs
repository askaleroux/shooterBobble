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
        public event Action<GameObject> OnCollisionStart;
        public event Action OnBubbleArrived;

        [SerializeField]
        SpriteRenderer _bubbleSprite;

        public bool IsMoving;
        private float _movingSpeed;
        private float _headingAngle;
        private const float FORCE = 20;

        BubbleElement()
        {
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Border"&&IsMoving)
            {
                var rigobody =  this.GetComponent<Rigidbody>();
                var oldVelocity = rigobody.velocity;
                ContactPoint contact = collision.contacts[0];
                Vector3 reflectedVelocity = Vector3.Reflect(oldVelocity, contact.normal);
                rigobody.velocity = reflectedVelocity;
                Quaternion rotation = Quaternion.FromToRotation(oldVelocity, reflectedVelocity);
                transform.rotation = rotation * transform.rotation;
            }

            if (collision.gameObject.tag == "TargetBubble"&&IsMoving)
            {
                var rigobody = this.GetComponent<Rigidbody>();
                rigobody.velocity = Vector3.zero;
                OnBubbleArrived();
                IsMoving = false;
                gameObject.tag = "TargetBubble";
            }
        }

        void Update()
        {
            if (IsMoving)
            {
                Vector3 dir = Quaternion.AngleAxis(_headingAngle, Vector3.forward) * Vector3.right;
                GetComponent<Rigidbody>().AddForce(dir* FORCE);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
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