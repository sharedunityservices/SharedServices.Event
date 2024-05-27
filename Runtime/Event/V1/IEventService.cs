using SharedServices.V1;

namespace SharedServices.Event.V1
{
    public interface IEventService : IService
    {
        void AddListener<T>(EventListener<T> listener) where T : IEvent;
        void RemoveListener<T>(EventListener<T> listener) where T : IEvent;
        void AddListener<T>(EventForwarder<T> forwarder) where T : IEvent;
        void RemoveListener<T>(EventForwarder<T> forwarder) where T : IEvent;
        void Invoke<T>(T eventInstance) where T : IEvent;
    }
}