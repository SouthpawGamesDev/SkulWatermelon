using SkulWatermelon.Model;
using System;
using SkulWatermelon.UI;
using UnityEngine;

namespace SkulWatermelon.Core
{
    public class GameCycle
    {
        public HeadGenerator HeadGenerator { get; private set; }
        public Score Score { get; private set; }
        public GameResourceManager GameResourceManager { get; private set; }
        public HeadDropper HeadDropper { get; private set; }
        
        public GameCycle(StageData stageData, GamePolicy gamePolicy)
        {
            Score = Score.Of(0);
            HeadGenerator = new HeadGenerator();
            HeadDropper = new HeadDropper(stageData.headDropperTransform, stageData.headDropperRange, stageData.headDropperSpeed, HeadGenerator, gamePolicy.HeadGenerationPolicy);
            
            HeadDisplayer headDisplayer = new HeadDisplayer(stageData.nextHead, stageData.currentHeadRenderer, HeadDropper);
        }

        public void Update()
        {
            HeadDropper.Update();
        }

        public void AddScore(int amount)
        {
            Score = Score.Of(Score.Amount + amount);
        }
    }
}
