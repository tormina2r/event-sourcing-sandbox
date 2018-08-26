﻿using EventSourcing.Data.Events;
using System.Linq;
using EventSourcing.BusinessLogic.Models.Events;

namespace EventSourcing.BusinessLogic
{
    public class AutoPersistEventStore : EventStore
    {
        private readonly EventRepository _Repository;
        private readonly EventModelFactory _EventModelFactory;

        public AutoPersistEventStore(EventRepository repository, EventModelFactory eventModelFactory)
            : base(repository.Events.Select(@event => CreateEventModel(eventModelFactory, @event)))
        {
            _Repository = repository;
            _EventModelFactory = eventModelFactory;
        }

        private static EventModel CreateEventModel(EventModelFactory factory, Event @event) => factory.CreateModel(@event);

        public override void AddEvent(EventModel @event)
        {
            base.AddEvent(@event);
            _Repository.Add(_EventModelFactory.CreateEntity(@event));
            _Repository.Save();
        }
    }
}
