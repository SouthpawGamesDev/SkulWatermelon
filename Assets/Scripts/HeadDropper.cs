using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
namespace SkulWatermelon.Model
{
    [Serializable]
    public sealed class HeadDropper
    {
        [SerializeField]
        Head headPrefab;

        [SerializeField]
        Vector2 range;

        [SerializeField]
        [Range(1f, 100f)]
        float speed;

        Head currentHead;

        HeadGenerator headGenerator;

        public void Start()
        {
            headGenerator = new HeadGenerator(headPrefab);
            
            currentHead = headGenerator.GetHead();
        }
        
        public void Move(float value)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + value * Time.deltaTime*speed, range.x, range.y), transform.position.y, transform.position.z);
            currentHead.transform.position = transform.position;
        }
        
        public void Drop()
        {
            currentHead.Unhold();
            currentHead = headGenerator.GetHead();
        }
    }
}
