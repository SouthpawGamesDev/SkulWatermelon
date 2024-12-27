using System;
using UnityEngine;

namespace SkulWatermelon.Model
{
    [Serializable]
    public class GamePolicy
    {
        [SerializeReference, SubclassSelector]
        IHeadGenerationPolicy headGenerationPolicy;

        [SerializeReference, SubclassSelector]
        IHeadEvolutionPolicy headEvolutionPolicy;
        
        public IHeadGenerationPolicy HeadGenerationPolicy
        {
            get
            {
                return headGenerationPolicy;
            }
        }
        
        public IHeadEvolutionPolicy HeadEvolutionPolicy
        {
            get
            {
                return headEvolutionPolicy;
            }
        }
    }
    
    public interface IHeadGenerationPolicy
    {
        public float GetRotation();
        public int GetLevel();
    }

    [System.Serializable]
    public class DefaultHeadGenerationPolicy : IHeadGenerationPolicy
    {
        public float GetRotation()
        {
            return UnityEngine.Random.Range(-180f, 180f);
        }
        public int GetLevel()
        {
            return UnityEngine.Random.Range(0, 4);
        }
    }

    public interface IHeadEvolutionPolicy
    {
        public float GetRotation();
    }

    [System.Serializable]
    public class DefaultHeadEvolutionPolicy : IHeadEvolutionPolicy
    {
        public float GetRotation()
        {
            return UnityEngine.Random.Range(-180f, 180f);
        }
    }
}
