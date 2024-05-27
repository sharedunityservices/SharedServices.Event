using System;

namespace SharedServices.Event.V1
{
    public class EventListener<T> where T : IEvent
    {
        public string Topic { get; }
        public Action<T> Callback { get; }
        
        public EventListener(string topic, Action<T> callback)
        {
            Topic = topic;
            Callback = callback;
        }
        
        public EventListener(Action<T> callback)
        {
            Topic = EventBus.DefaultTopic;
            Callback = callback;
        }
    }
}