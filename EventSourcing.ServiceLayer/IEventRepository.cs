using System.Collections.Generic;
using EventSourcing.ServiceLayer.Events;

namespace EventSourcing
{
    public interface IEventRepository
    {
        IEnumerable<IEvent> Events { get; }

        void Add(IEvent @event);
        void Save();
    }
}