using SkulWatermelon.Core;
using UnityEngine;

namespace SkulWatermelon.Model
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField]
        StageData stageData;
        public GameCycle GameCycle { get; private set; }
        
        void Awake()
        {
            GameCycle = new GameCycle(stageData);
        }

        void Update()
        {
            GameCycle.Update();
        }
    }
}
