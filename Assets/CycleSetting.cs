using System.Collections.Generic;
using SkulWatermelon.Model;
using UnityEngine;

namespace SkulWatermelon.Settings
{
    [CreateAssetMenu(fileName = "CycleSetting", menuName = "SkulWatermelon/CycleSetting", order = 0)]
    public sealed class CycleSetting : ScriptableObject
    {
        [field: SerializeField]
        public Vector2 RotationRange { get; private set;}
        
        [field: SerializeField]
        public Vector2Int LevelRange { get; private set;}

        [SerializeField]
        List<Head> headResources;
        
        public int HeadMaximumLevel => headResources.Count;
        
        public float GetRotation()
        {
            return UnityEngine.Random.Range(RotationRange.x, RotationRange.y);
        }
        
        public int GetLevel()
        {
            return UnityEngine.Random.Range(LevelRange.x, LevelRange.y);
        }
        
        public Head GetHeadPrefab(int level)
        {
            if (headResources.Count <= level)
                return headResources[0];

            return headResources[level];
        }
    }
}
