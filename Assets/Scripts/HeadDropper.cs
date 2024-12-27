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
        IHeadGenerationPolicy headGenerationPolicy;
        
        public int currentLevel { get; private set; }
        public int nextLevel { get; private set; }
        public float currentRotation { get; private set; }
        
        public event Action HeadDropped;

        public HeadDropper(Transform transform, Vector2 range, float speed, HeadGenerator headGenerator, IHeadGenerationPolicy headGenerationPolicy)
        {
            this.transform = transform;
            this.range = range;
            this.speed = speed;
            this.headGenerator = headGenerator;
            this.headGenerationPolicy = headGenerationPolicy;
            
            currentLevel = headGenerationPolicy.GetLevel();
            nextLevel = headGenerationPolicy.GetLevel();
            currentRotation = headGenerationPolicy.GetRotation();
        }

        public void Move(float value)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + value * Time.deltaTime * speed, range.x, range.y), transform.position.y, transform.position.z);
        }

        public void Drop()
        {
            var head = headGenerator.GetHead(new HeadGenerationData(currentLevel, transform.position, currentRotation));
            head.Unhold();
            
            currentRotation = headGenerationPolicy.GetRotation();
            currentLevel = nextLevel;
            nextLevel = headGenerationPolicy.GetLevel();
            
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
    }
}
