using System;
using System.Collections;
using System.Collections.Generic;
using SkulWatermelon.Core;
using SkulWatermelon.Model;
using UnityEngine;

public class TEMPGameLogic
{
    static TEMPGameLogic _instance;

    public static TEMPGameLogic Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TEMPGameLogic();

            }
            return _instance;
        }
    }

    Evolutioner evolutioner = new Evolutioner();
    GameCycle gameCycle;

    public void InjectGameCycle(GameCycle gameCycle)
    {
        this.gameCycle = gameCycle;
    }

    public void SendHeadColideData(Head one, Head two, int nextLevel)
    {
        evolutioner.Evolve(one, two, nextLevel);
    }

    public void SendEvolutionCompletedData(int nextLevel, Vector2 position, float rotation)
    {
        var newHead = gameCycle.HeadGenerator.GetHead(nextLevel, position, rotation);
        newHead.Unhold();
        gameCycle.AddScore(newHead.Score);
    }
}
