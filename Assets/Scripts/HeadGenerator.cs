using SkulWatermelon.Core;
using System;
using UnityEngine;
namespace SkulWatermelon.Model
{
    [Serializable]
    public class HeadGenerator
    {
        public Head GetHead(HeadGenerationData headGenerationData)
        {
            Head headPrefab = GameManager.Instance.GameResourceManager.GetHeadPrefab(headGenerationData.Level);
            Head currentHead = GameObject.Instantiate(headPrefab);
            currentHead.transform.position = headGenerationData.Position;
            currentHead.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, headGenerationData.Rotation));
            currentHead.Hold();
            return currentHead;
        }
    }
}
