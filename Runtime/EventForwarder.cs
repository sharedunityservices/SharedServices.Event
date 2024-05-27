using System;
using UnityEngine.Events;

namespace Utility.Events
{
    public class EventForwarder<T> where T : IEvent
    {
        private UnityEvent _triggerEvent;
        private readonly UnityAction _callback;

        public EventForwarder(UnityEvent triggerEvent, string topic, Func<T> eventData)
        {
            _triggerEvent = triggerEvent;
            _callback = () => EventBus.Invoke(topic, eventData());
        }
        
        public EventForwarder(UnityEvent triggerEvent, Func<T> eventData)
        {
            _triggerEvent = triggerEvent;
            _callback = () => EventBus.Invoke(eventData());
        }
        
        public EventForwarder(UnityEvent triggerEvent, string topic)
        {
            _triggerEvent = triggerEvent;
            var instance = Activator.CreateInstance<T>();
            _callback = () => EventBus.Invoke(topic, instance);
        }
        
        public EventForwarder(UnityEvent triggerEvent)
        {
            _triggerEvent = triggerEvent;
            var instance = Activator.CreateInstance<T>();
            _callback = () => EventBus.Invoke(instance);
        }
        
        public void AddListener()
        {
            _triggerEvent.AddListener(_callback);
        }
        
        public void RemoveListener()
        {
            _triggerEvent.RemoveListener(_callback);
        }
    }
}