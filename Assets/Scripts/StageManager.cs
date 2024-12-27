using Singletons;
using SkulWatermelon.Core;
using UnityEngine;

namespace SkulWatermelon.Model
{
    public class StageManager : Singleton<StageManager>
    {
        [SerializeField]
        StageData stageData;
        public GameCycle GameCycle { get; private set; }
        public GameLogic GameLogic { get; private set; }

        [SerializeField]
        GamePolicy gamePolicy;

        
        void Awake()
        {
            GameCycle = new GameCycle(stageData, gamePolicy);
            GameLogic = new GameLogic(gamePolicy);
        }

        void Update()
        {
            GameCycle.Update();
        }
    }
}
