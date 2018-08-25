using EventSourcing.Data.Events;
using System.Collections.Generic;

namespace EventSourcing
{
    public abstract class EventRepository
    {
        public abstract IEnumerable<Event> Events { get; }

        public abstract void Add(Event @event);        

        public abstract void Save();
    }
}