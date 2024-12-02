using System;

namespace SkulWatermelon.Core
{
    public class EventSubscriber
    {
        public Delegate callback;
        public int ID => GetHashCode();

        public void Invoke<T>(T payload)
        {
            if (callback is Action<T> action)
                action(payload);
        }
    }
}