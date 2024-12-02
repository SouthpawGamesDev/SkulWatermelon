using SkulWatermelon.Core;
using System;
using UnityEngine;
namespace SkulWatermelon.Model
{
    [Serializable]
    public class HeadGenerator
    {
        public int current { get; private set; }
        public int next { get; private set; }
        public float currentRotation { get; private set; }

        Evolutioner evolutioner;
        
        public HeadGenerator()
        {
            current = UnityEngine.Random.Range(0, 4);
            next = UnityEngine.Random.Range(0, 4);
            evolutioner = new Evolutioner(GetHead);
        }

        public Head Generate(int level)
        {
            Head headPrefab = GameManager.Instance.GameResourceManager.GetHeadPrefab(level);
            Head currentHead = GameObject.Instantiate(headPrefab);
            return currentHead;
        }

        public Head GetHead()
        {
            var currentHead = GetHead(current);
            current = next;
            currentRotation = UnityEngine.Random.Range(-180f, 180f);
            next = UnityEngine.Random.Range(0, 4);

            return currentHead;
        }

        public Head GetHead(int level)
        {
            Head headPrefab = GameManager.Instance.GameResourceManager.GetHeadPrefab(level);
            Head currentHead = GameObject.Instantiate(headPrefab);
            currentHead.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, currentRotation));
            currentHead.Hold();
            return currentHead;
        }
    }
}
