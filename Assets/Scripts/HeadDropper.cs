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

        public event Action HeadDropped;

        public HeadDropper(Transform transform, Vector2 range, float speed, HeadGenerator headGenerator)
        {
            this.transform = transform;
            this.range = range;
            this.speed = speed;
            this.headGenerator = headGenerator;
        }

        public void Move(float value)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + value * Time.deltaTime * speed, range.x, range.y), transform.position.y, transform.position.z);
        }

        public void Drop()
        {
            var head = headGenerator.GetHead();
            head.Unhold();
            head.transform.position = transform.position;
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
