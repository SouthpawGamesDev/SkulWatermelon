using System;
using SkulWatermelon.Core;
using SkulWatermelon.Model;
using UnityEngine.PlayerLoop;

namespace SkulWatermelon.Model
{
    public class Evolutioner
    {
        Func<int, Head> getHead;
        
        public Evolutioner(Func<int, Head> getHead)
        {
            this.getHead = getHead;
            
            EventQueue.Instance.Subscribe<CollideData>(Evolve);
        }
        
        public void Evolve(CollideData collideData)
        {
            var centerPosition = (collideData.headOne.transform.position + collideData.headTwo.transform.position) / 2;
            
            collideData.headOne.Hold();
            collideData.headTwo.Hold();
            
            UnityEngine.Object.Destroy(collideData.headOne.gameObject);
            UnityEngine.Object.Destroy(collideData.headTwo.gameObject);
            
            if (GameManager.Instance.GameResourceManager.maximumLevel == collideData.nextLevel)
                return;
            
            var newHead = getHead?.Invoke(collideData.nextLevel);
            newHead.Unhold();
            newHead.transform.position = centerPosition;
            
            
            
            //GameManager.Instance.GameCycle.AddScore(Score.Of(newHead.Score));
        }
    }
}