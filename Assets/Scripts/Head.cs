using SkulWatermelon.InGame;
using UnityEngine;

namespace SkulWatermelon.Model
{
    public struct HeadData
    {
        public int Level;
        public int Score;
    }
    
    public sealed class Head : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer spriteRenderer;
        
        [SerializeField]
        int level = 0;
        [SerializeField]
        int score = 0;

        HeadData headData;
        
        // 중복 진화 방지
        bool expired = false;
        
        public int Score { get => score; }

        void Awake()
        {
            headData = new HeadData()
            {
                Level = level,
                Score = score,
            };
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var targetHead = collision.gameObject.GetComponent<Head>();
            
            if (targetHead != null)
            {
                if(this.expired == true || targetHead.expired == true)
                    return;
                
                if (targetHead.level != level)
                    return;


                expired = true;
                targetHead.expired = true;
                
                GameCycleEventRecord.Instance.Record(new HeadCollisionEventData(this, targetHead, level + 1));
            }
        }

        public HeadData GetData()
            => headData;
        
        public Sprite GetSprite()
            => spriteRenderer.sprite;
    }
}
