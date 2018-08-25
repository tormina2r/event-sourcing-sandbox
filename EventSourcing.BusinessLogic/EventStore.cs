using EventSourcing.Data.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventSourcing.BusinessLogic
{
    public class EventStore
    {
        private List<Event> _Events;

        public EventStore(IEnumerable<Event> events = null)
        {
            _Events = events?.ToList() ?? new List<Event>();
        }

        public virtual void AddEvent(Event @event)
        {
            _Events.Add(@event);
            OnEventAdded(@event);
        }

        public event EventHandler<Event> EventAdded;

        public IEnumerable<Event> GetEventStream() => _Events.OrderBy(p => p.TimeStamp);

        public IEnumerable<Event> GetEventStream(DateTime pointInTime) => _Events.Where(@event => @event.TimeStamp < pointInTime).OrderBy(p => p.TimeStamp);

        private void OnEventAdded(Event @event)
        {
            var handler = EventAdded;
            if (handler != null)
            {
                handler.Invoke(this, @event);
            }
        }        
    }
}
