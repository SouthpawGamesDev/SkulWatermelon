using SkulWatermelon.Model;
using System;
using UnityEngine;

namespace SkulWatermelon.Core
{
    public class GameCycle
    {
        public HeadGenerator HeadGenerator { get; private set; }
        public Score Score { get; private set; }
        public GameResourceManager GameResourceManager { get; private set; }
        public HeadDropper HeadDropper { get; private set; }
        public EventQueue EventQueue { get; private set; }

        public GameCycle(StageData stageData)
        {
            Score = Score.Of(0);
            HeadGenerator = new HeadGenerator();
            HeadDropper = new HeadDropper(stageData.headDropperTransform, stageData.headDropperRange, stageData.headDropperSpeed, HeadGenerator);
            EventQueue = new EventQueue();
        }

        public void Update()
        {
            HeadDropper.Update();
            EventQueue.Update();
        }

        public void AddScore(Score add)
        {
            Score = Score.Of(Score.Amount + add.Amount);
        }



    }
}
