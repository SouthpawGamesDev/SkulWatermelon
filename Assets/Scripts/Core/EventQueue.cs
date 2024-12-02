using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SkulWatermelon.Core
{
    public class EventQueue : Singletons.Singleton<EventQueue>
    {
        Dictionary<Type, Dictionary<int, EventSubscriber>> events = new Dictionary<Type, Dictionary<int, EventSubscriber>>();
        
        public void Subscribe<T>(Action<T> callback) where T : IPayload
        {
            var eventSubscriber = new EventSubscriber();
            eventSubscriber.callback = callback;

            var eventSubscriberType = typeof(T);
            Dictionary<int, EventSubscriber> eventSubscribers;

            if (events.ContainsKey(eventSubscriberType) == true)
            {
                events.TryGetValue(eventSubscriberType, out eventSubscribers);
            }
            else
            {
                eventSubscribers = new Dictionary<int, EventSubscriber>();
                eventSubscribers.Add(eventSubscriber.ID, eventSubscriber);
                events.Add(eventSubscriberType, eventSubscribers);
            }
            
            events.TryAdd(eventSubscriberType, eventSubscribers);
        }

        public void Publish<T>(T payload) where T : IPayload
        {
            var type = typeof(T);
            var eventList = events[type];

            foreach (EventSubscriber @event in eventList.Values)
            {
                @event?.Invoke(payload);
            }
        }
        
        public void Update()
        {

        }
    }
}
