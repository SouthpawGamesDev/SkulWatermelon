using System;
using System.Collections;
using System.Collections.Generic;
using SkulWatermelon.Core;
using SkulWatermelon.Model;
using UnityEngine;

public class GameLogic
{
    Evolutioner evolutioner;
    
    public GameLogic(GamePolicy gamePolicy)
    {
        evolutioner = new Evolutioner(gamePolicy.HeadEvolutionPolicy);
    }

    public void Invoke(HeadCollisionEventData data)
    {
        evolutioner.Evolve(data);
    }

    public void Invoke(HeadGenerationData headGenerationData)
    {
        var newHead = StageManager.Instance.GameCycle.HeadGenerator.GetHead(headGenerationData);
        newHead.Unhold();
        StageManager.Instance.GameCycle.AddScore(newHead.Score);
    }

}
