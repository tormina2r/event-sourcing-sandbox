using System;
using System.Collections.Generic;

namespace EventSourcing
{
    public interface IEventStore
    {
        void AddEvent(Event @event);

        event EventHandler<Event> EventAdded;

        IEnumerable<Event> GetEventStream();

        IEnumerable<Event> GetEventStream(DateTime pointInTime);
    }
}
