using SkulWatermelon.Core;
using System;
using UnityEngine;
namespace SkulWatermelon.Model
{
    public sealed class HeadDropper
    {
        Transform transform;
        Vector2 range;
        float speed;
        HeadGenerator headGenerator;

        public int currentLevel { get; private set; }
        public int nextLevel { get; private set; }
        public float currentRotation { get; private set; }
        
        public event Action HeadDropped;

        public HeadDropper(Transform transform, Vector2 range, float speed, HeadGenerator headGenerator)
        {
            this.transform = transform;
            this.range = range;
            this.speed = speed;
            this.headGenerator = headGenerator;

            currentLevel = 헤드만들때헤드레벨을알아오는정책함수();
            nextLevel = 헤드만들때헤드레벨을알아오는정책함수();
            currentRotation = 헤드만들때헤드로테이션을알아오는정책함수();
        }

        public void Move(float value)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + value * Time.deltaTime * speed, range.x, range.y), transform.position.y, transform.position.z);
        }

        public void Drop()
        {
            var head = headGenerator.GetHead(currentLevel, transform.position, currentRotation);
            head.Unhold();
            
            currentRotation = 헤드만들때헤드로테이션을알아오는정책함수();
            currentLevel = nextLevel;
            nextLevel = 헤드만들때헤드레벨을알아오는정책함수();
            
            HeadDropped?.Invoke();
        }

        public void Update()
        {
            var input = GameManager.Instance.input;
            float moveValue = input.GetMoveInput();
            Move(moveValue);

            if (input.GetDropInput())
                Drop();
        }

        // TODO : 정책 클래스로 빼야함
        int 헤드만들때헤드레벨을알아오는정책함수()
        {
            return UnityEngine.Random.Range(0, 4);
        }

        float 헤드만들때헤드로테이션을알아오는정책함수()
        {
            return UnityEngine.Random.Range(-180f, 180f);
        }
    }
}
