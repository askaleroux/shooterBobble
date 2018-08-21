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
        public event Func<BubbleElement,Vector3> OnBubbleArrived;

        [SerializeField]
        SpriteRenderer _bubbleSprite;

        public int ColorIndex;
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
                OnBubbleArrived(this);
                IsMoving = false;
                rigobody.isKinematic = true;
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

        public void DestoryBubble()
        {
            this.gameObject.SetActive(false);
            Destroy(this);
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