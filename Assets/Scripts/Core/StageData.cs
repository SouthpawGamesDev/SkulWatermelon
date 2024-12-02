using SkulWatermelon.Model;
using System;
using UnityEngine;

namespace SkulWatermelon.Core
{
    [Serializable]
    public class StageData
    {
        public Head headPrefab;
        public Transform headDropperTransform;
        public Vector2 headDropperRange;
        public float headDropperSpeed;
    }
}