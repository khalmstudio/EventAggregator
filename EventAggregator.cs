using System;
using System.Collections.Generic;

namespace KHALMStudio.Scripts.EventSystem
{
    public static class EventAggregator
    {
        private static readonly Dictionary<Type, List<Delegate>> EventSubscribers = new();

        public static void Subscribe<TEvent>(Action<TEvent> subscriber)
        {
            var eventType = typeof(TEvent);
            if (!EventSubscribers.ContainsKey(eventType))
            {
                EventSubscribers[eventType] = new List<Delegate>();
            }

            EventSubscribers[eventType].Add(subscriber);
        }

        public static void Unsubscribe<TEvent>(Action<TEvent> subscriber)
        {
            var eventType = typeof(TEvent);
            if (!EventSubscribers.TryGetValue(eventType, out var eventSubscriber)) return;
            
            eventSubscriber.Remove(subscriber);
        }

        public static void Publish<TEvent>(TEvent publishedEvent)
        {
            var eventType = typeof(TEvent);
            if (!EventSubscribers.TryGetValue(eventType, out var eventSubscriber)) return;
            
            var subscribersCopy = new List<Delegate>(eventSubscriber);
    
            foreach (var subscriber in subscribersCopy)
            {
                (subscriber as Action<TEvent>)?.Invoke(publishedEvent);
            }
        }
    }
}
