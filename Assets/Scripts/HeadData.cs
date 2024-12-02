using System.Collections.Generic;
using UnityEngine;

namespace SkulWatermelon.Data
{
    [CreateAssetMenu(menuName = "Data/Head", fileName = "HeadData")]
    public class HeadData : ScriptableObject
    {
        public int level;
        public float scale;
        public float mass;
        public Sprite sprite;
    }
}