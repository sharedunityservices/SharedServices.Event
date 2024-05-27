using System;
using System.Collections.Generic;

namespace Utility.Events
{
    public static class EventBus
    {
        internal const string DefaultTopic = "default";
        private static readonly Dictionary<string, Dictionary<Type, List<object>>> Listeners = new();
        
        public static void AddListener<T>(EventListener<T> listener) where T : IEvent
        {
            if (!Listeners.ContainsKey(listener.Topic)) Listeners[listener.Topic] = new Dictionary<Type, List<object>>();
            if (!Listeners[listener.Topic].ContainsKey(typeof(T))) Listeners[listener.Topic][typeof(T)] = new List<object>();
            Listeners[listener.Topic][typeof(T)].Add(listener);
        }
        
        public static void RemoveListener<T>(EventListener<T> listener) where T : IEvent
        {
            if (!Listeners.ContainsKey(listener.Topic)) return;
            if (!Listeners[listener.Topic].ContainsKey(typeof(T))) return;
            Listeners[listener.Topic][typeof(T)].Remove(listener);
        }
        
        public static void Invoke<T>(string topic, T eventData) where T : IEvent
        {
            if (!Listeners.ContainsKey(topic)) return;
            if (!Listeners[topic].ContainsKey(typeof(T))) return;
            foreach (var eventListener in Listeners[topic][typeof(T)])
            {
                ((EventListener<T>) eventListener).Callback(eventData);
            }
        }

        public static void Invoke<T>(T eventData) where T : IEvent
        {
            Invoke(DefaultTopic, eventData);
        }
    }
}
