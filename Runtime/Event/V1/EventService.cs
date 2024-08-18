namespace SharedServices.Event.V1
{
    [UnityEngine.Scripting.Preserve]
    public class EventService : IEventService
    {
        public void AddListener<T>(EventListener<T> listener) where T : IEvent => 
            EventBus.AddListener(listener);

        public void RemoveListener<T>(EventListener<T> listener) where T : IEvent => 
            EventBus.RemoveListener(listener);

        public void AddListener<T>(EventForwarder<T> forwarder) where T : IEvent
        {
            forwarder.AddListener();
        }

        public void RemoveListener<T>(EventForwarder<T> forwarder) where T : IEvent
        {
            forwarder.RemoveListener();
        }

        public void Invoke<T>(T eventInstance) where T : IEvent =>
            EventBus.Invoke(eventInstance);
    }
}