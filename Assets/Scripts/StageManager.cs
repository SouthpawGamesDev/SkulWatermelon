using Singletons;
using SkulWatermelon.Core;
using SkulWatermelon.InGame;
using SkulWatermelon.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SkulWatermelon.Model
{
    public sealed class StageManager
    {
        // GameManager로 옮기기
        CycleSetting setting;

        public CycleSetting Setting => setting;
        
        Score score;
        public Score Score => score;
        
        //1. 씬로드
        //2. 프리팹 로드
        //3. 생성

        
        
        public void Start(CycleSetting cycleSetting)
        {
            setting = cycleSetting;
            SceneManager.LoadScene("Stage", LoadSceneMode.Additive);
            score = Score.Of(0);
        }

        public void Update()
        {
            Process();
        }

        void Process()
        {
            while (true)
            {
                var headCollisionEvent = GameCycleEventRecord.Instance.PopHeadCollisionEvent();
                if (headCollisionEvent == null)
                    break;
                
                ProcessEvolution(headCollisionEvent.Value);
            }
            
            while (true)
            {
                var createEvent = GameCycleEventRecord.Instance.PopCreationEvent();
                if (createEvent == null)
                    break;
                
                CreateHead(createEvent.Value);
            }
                        
            while (true)
            {
                var generationEvent = GameCycleEventRecord.Instance.PopGenerationEvent();
                if (generationEvent == null)
                    break;
                
                EvolveHead(generationEvent.Value);
            }

            
            
            // 알아서 이벤트처리
        }

        public void End()
        {
            
        }

        void ProcessEvolution(HeadCollisionEventData data)
        {
            var centerPosition = (data.One.transform.position + data.Two.transform.position) / 2;

            Object.DestroyImmediate(data.Two.gameObject);
            Object.DestroyImmediate(data.One.gameObject);

            var generationData = new HeadGenerationData(data.NextLevel, centerPosition, GameManager.Instance.StageManager.Setting.GetRotation());
            GameCycleEventRecord.Instance.RecordGenerationEvent(generationData);
        }
        
        Head CreateHead(HeadGenerationData headGenerationData)
        {
            var headPrefab = GameManager.Instance.StageManager.Setting.GetHeadPrefab(headGenerationData.Level);
            
            var currentHead = GameObject.Instantiate(headPrefab);
            currentHead.transform.position = headGenerationData.Position;
            currentHead.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, headGenerationData.Rotation));

            return currentHead;
        }

        Head EvolveHead(HeadGenerationData headGenerationData)
        {
            var head = CreateHead(headGenerationData);         
            AddScore(head.Score);
            
            return head;
        }

        void AddScore(int value)
        {
            score = Score.Of(score.Amount + value);
        }
        
    }
}
