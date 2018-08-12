using System.Collections.Generic;

namespace EventSourcing
{
    public abstract class EventRepository
    {
        public abstract IEnumerable<EventEntity> Events { get; }

        public abstract void Add(EventType type, object value);        

        public abstract void Save();
    }
}