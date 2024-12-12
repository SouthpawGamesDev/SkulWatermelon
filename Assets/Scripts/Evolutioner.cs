using System;
using SkulWatermelon.Core;
using SkulWatermelon.Model;
using UnityEngine.PlayerLoop;

namespace SkulWatermelon.Model
{
    public class Evolutioner
    {
        public void Evolve(Head headOne, Head headTwo, int nextLevel)
        {
            var centerPosition = (headOne.transform.position + headTwo.transform.position) / 2;
            
            headOne.Hold();
            headTwo.Hold();
            
            UnityEngine.Object.Destroy(headOne.gameObject);
            UnityEngine.Object.Destroy(headTwo.gameObject);
            
            if (GameManager.Instance.GameResourceManager.maximumLevel == nextLevel)
                return;
            
            TEMPGameLogic.Instance.SendEvolutionCompletedData(nextLevel, centerPosition, 합쳐졌을때로테이션을알아오는함수());
        }
        
        // TODO : 정책 클래스로 빼야함
        float 합쳐졌을때로테이션을알아오는함수()
        {
            return UnityEngine.Random.Range(-180f, 180f); 
        }
    }
}