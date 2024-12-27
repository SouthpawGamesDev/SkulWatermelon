using SkulWatermelon.Data;
using System;
using SkulWatermelon.Core;
using UnityEngine;

namespace SkulWatermelon.Model
{
    public class Head : MonoBehaviour
    {
        [SerializeField]
        new Rigidbody2D rigidbody2D;
        [SerializeField]
        SpriteRenderer spriteRenderer;
        [SerializeField]
        new Collider2D collider;
        [SerializeField]
        int level = 0;
        [SerializeField]
        int score;

        bool evolutionable = false;
        public int Score { get => score; }
        float rotation;

        public void Hold()
        {
            evolutionable = false;
            collider.enabled = false;
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        public void Unhold()
        {
            evolutionable = true;
            collider.enabled = true;
            rigidbody2D.constraints = RigidbodyConstraints2D.None;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (evolutionable == false)
                return;

            var targetHead = collision.gameObject.GetComponent<Head>();
            if (targetHead != null)
            {
                if (targetHead.evolutionable == false)
                    return;

                if (targetHead.level != level)
                    return;

                StageManager.Instance.GameLogic.Invoke(new HeadCollisionEventData(this, targetHead, level + 1));
            }
        }

        public Sprite GetSprite()
        {
            return spriteRenderer.sprite;
        }
    }
}
