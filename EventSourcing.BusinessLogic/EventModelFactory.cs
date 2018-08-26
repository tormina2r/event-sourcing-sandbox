using System;
using EventSourcing.BusinessLogic.Models.Events;
using EventSourcing.Data.Events;

namespace EventSourcing.BusinessLogic
{
    public class EventModelFactory
    {
        public EventModel CreateModel(Event @event)
        {
            throw new NotImplementedException();
        }

        internal Event CreateEntity(EventModel @event)
        {
            throw new NotImplementedException();
        }
    }
}