using EventSourcing.Data.Events;
using System.Collections.Generic;

namespace EventSourcing
{
    public abstract class EventRepository
    {
        public abstract IEnumerable<IEvent> Events { get; }

        public abstract void Add(IEvent @event);        

        public abstract void Save();
    }
}