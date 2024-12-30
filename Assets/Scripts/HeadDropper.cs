using SkulWatermelon.Core;
using System;
using SkulWatermelon.InGame;
using UnityEngine;

namespace SkulWatermelon.Model
{
    public sealed class HeadDropper
    {
        public struct HeadData
        {
            public int Level;
            public float Rotation;
        }
        
        Player.HeadDropperSetting setting;
        HeadData currentData;
        public HeadData CurrentData => currentData;
        HeadData nextData;
        public HeadData NextData => nextData;
        
        
        public event Action HeadDropped;

        public HeadDropper(Player.HeadDropperSetting setting)
        {
            this.setting = setting;
            currentData = new HeadData()
            {
                Level = GameManager.Instance.StageManager.Setting.GetLevel(),
                Rotation = GameManager.Instance.StageManager.Setting.GetRotation()
            };
            
            nextData = new HeadData()
            {
                Level = GameManager.Instance.StageManager.Setting.GetLevel(),
            };
            
        }

        public void Move(float value)
        {
            var transform = setting.transform;
            
            float nextX = Mathf.Clamp(transform.position.x + value * Time.deltaTime * setting.speed, setting.range.x, setting.range.y);
            float nextY = setting.transform.position.y;
            
            setting.transform.position = new Vector2(nextX, nextY);
        }

        public void Drop()
        {
            GameCycleEventRecord.Instance.RecordCreationEvent(new HeadGenerationData(currentData.Level, setting.transform.position, currentData.Rotation));
            ReadyToNext();
            
            HeadDropped?.Invoke();
        }

        void ReadyToNext()
        {
            currentData = new HeadData()
            {
                Level = nextData.Level,
                Rotation =  GameManager.Instance.StageManager.Setting.GetRotation()
            };
            
            nextData = new HeadData()
            {
                Level = GameManager.Instance.StageManager.Setting.GetLevel()
            };
            
        }
    }
}
