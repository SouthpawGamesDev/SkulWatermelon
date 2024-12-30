using System.Collections.Generic;
using SkulWatermelon.Model;

namespace SkulWatermelon.InGame
{
    public sealed class GameCycleEventRecord : Singletons.Singleton<GameCycleEventRecord>
    {
        public Queue<HeadCollisionEventData> collisionEvents { get; private set; }

        public Queue<HeadGenerationData> creationEvents { get; private set; }
        
        public Queue<HeadGenerationData> generationEvents { get; private set; }
        
        
        
        public void Record(HeadCollisionEventData gameCycleEvent)
        {
            collisionEvents.Enqueue(gameCycleEvent);
        }

        public HeadCollisionEventData? PopHeadCollisionEvent()
        {
            if (collisionEvents.Count <= 0)
                return null;
            
            var @event = collisionEvents.Dequeue();
            
            return @event;
        }
        
        
        
        
        public void RecordCreationEvent(HeadGenerationData generationData)
        {
            creationEvents.Enqueue(generationData);
        }
        
        
        public HeadGenerationData? PopCreationEvent()
        {
            if (creationEvents.Count <= 0)
                return null;
            
            return creationEvents.Dequeue();
        }

        
        
        
        public void RecordGenerationEvent(HeadGenerationData generationData)
        {
            generationEvents.Enqueue(generationData);
        }
        
        
        public HeadGenerationData? PopGenerationEvent()
        {
            if (generationEvents.Count <= 0)
                return null;
            
            return generationEvents.Dequeue();
        }
        
        

        public void Awake()
        {
            collisionEvents = new Queue<HeadCollisionEventData>();
            creationEvents = new Queue<HeadGenerationData>();
            generationEvents = new Queue<HeadGenerationData>();
        }
    }
}
