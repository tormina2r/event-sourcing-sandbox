using EventSourcing.BusinessLogic.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventSourcing.BusinessLogic
{
    public class EventStore
    {
        private List<EventModel> _Events;

        public EventStore(IEnumerable<EventModel> events = null)
        {
            _Events = events?.ToList() ?? new List<EventModel>();
        }

        public virtual void AddEvent(EventModel @event)
        {
            _Events.Add(@event);
            OnEventAdded(@event);
        }

        public event EventHandler<EventModel> EventAdded;

        public IEnumerable<EventModel> GetEventStream() => _Events.OrderBy(p => p.TimeStamp);

        public IEnumerable<EventModel> GetEventStream(DateTime pointInTime) => _Events.Where(@event => @event.TimeStamp < pointInTime).OrderBy(p => p.TimeStamp);

        private void OnEventAdded(EventModel @event)
        {
            var handler = EventAdded;
            if (handler != null)
            {
                handler.Invoke(this, @event);
            }
        }        
    }
}
