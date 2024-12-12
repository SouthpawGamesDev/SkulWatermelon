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

        public GameCycle(StageData stageData)
        {
            Score = Score.Of(0);
            HeadGenerator = new HeadGenerator();
            HeadDropper = new HeadDropper(stageData.headDropperTransform, stageData.headDropperRange, stageData.headDropperSpeed, HeadGenerator);
            
            HeadDisplayer headDisplayer = new HeadDisplayer(stageData.nextHead, stageData.currentHeadRenderer, HeadDropper);

            TEMPGameLogic.Instance.InjectGameCycle(this);
        }

        public void Update()
        {
            HeadDropper.Update();
        }

        public void AddScore(int amount)
        {
            Score = Score.Of(Score.Amount + amount);
            Debug.Log(Score.Amount);
        }
    }
}
