using SkulWatermelon.Core;
using System;
using UnityEngine;
namespace SkulWatermelon.Model
{
    [Serializable]
    public class HeadGenerator
    {
        public Head GetHead(int level, Vector2 position, float rotation)
        {
            Head headPrefab = GameManager.Instance.GameResourceManager.GetHeadPrefab(level);
            Head currentHead = GameObject.Instantiate(headPrefab);
            currentHead.transform.position = position;
            currentHead.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, rotation));
            currentHead.Hold();
            return currentHead;
        }
    }
}
