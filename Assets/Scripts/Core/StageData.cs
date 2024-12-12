using SkulWatermelon.Model;
using System;
using SkulWatermelon.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SkulWatermelon.Core
{
    [Serializable]
    public class StageData
    {
        public Head headPrefab;
        public Transform headDropperTransform;
        public Vector2 headDropperRange;
        public float headDropperSpeed;
        public Image nextHead;
        public SpriteRenderer currentHeadRenderer;
    }
}