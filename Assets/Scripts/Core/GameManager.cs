using SkulWatermelon.Model;
using SkulWatermelon.Settings;
using UnityEngine;

namespace SkulWatermelon.Core
{
    public sealed class GameManager : Singletons.Singleton<GameManager>
    {
        [SerializeField]
        CycleSetting setting;
        
        public StageManager StageManager => stageManager;
        
        bool loaded;
        StageManager stageManager;
        
        void Awake()
        {
            Load();
        }

        void Update()
        {
            if (loaded == false)
                return;
            
            stageManager.Update();
        }
        
        public void Load()
        {
            // Cycle Start
            stageManager = new StageManager();
            stageManager.Start(setting); 

            loaded = true;
        }
    }
}
