using SharedServices;
using SharedServices.V1;
using Utility.Events;

namespace Services.Event
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