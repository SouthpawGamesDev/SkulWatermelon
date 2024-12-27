using UnityEngine;
namespace SkulWatermelon.Model
{
    public struct HeadGenerationData
    {
        public int Level;
        public Vector2 Position;
        public float Rotation;

        public HeadGenerationData(int level, Vector2 position, float rotation)
        {
            Level = level;
            Position = position;
            Rotation = rotation;
        }
    }
}