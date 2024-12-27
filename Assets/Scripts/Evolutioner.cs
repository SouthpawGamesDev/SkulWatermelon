using System;
using SkulWatermelon.Core;
using SkulWatermelon.Model;
using UnityEngine.PlayerLoop;

namespace SkulWatermelon.Model
{
    public class Evolutioner
    {
        IHeadEvolutionPolicy headEvolutionPolicy;
        public Evolutioner(IHeadEvolutionPolicy headEvolutionPolicy)
        {
            this.headEvolutionPolicy = headEvolutionPolicy;
        }
        
        public void Evolve(HeadCollisionEventData data)
        {
            var centerPosition = (data.One.transform.position + data.Two.transform.position) / 2;
            
            data.One.Hold();
            data.Two.Hold();
            
            UnityEngine.Object.Destroy(data.One.gameObject);
            UnityEngine.Object.Destroy(data.Two.gameObject);
            
            if (GameManager.Instance.GameResourceManager.maximumLevel == data.NextLevel)
                return;
            
            StageManager.Instance.GameLogic.Invoke(new HeadGenerationData(data.NextLevel, centerPosition, headEvolutionPolicy.GetRotation()));
        }
    }
}