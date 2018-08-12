using EventSourcing.BusinessLogic.Events;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace EventSourcing.BusinessLogic
{
    public class AutoPersistEventStore : EventStore
    {
        private readonly EventRepository _Repository;

        public AutoPersistEventStore(EventRepository repository)
            :base(repository.Events.Select(CreateModel))
        {
            _Repository = repository;
        }

        private static Event CreateModel(EventEntity entity)
        {
            switch (entity.Type)
            {
                case EventType.PersonCreated:
                    return JsonConvert.DeserializeObject<PersonCreated>(entity.Value.ToString());
                default:
                    throw new InvalidOperationException($"Unknown event type: {entity.Type.ToString()}");
            }
        }

        public override void AddEvent(Event @event)
        {
            base.AddEvent(@event);
            _Repository.Add(@event.Type, @event);
            _Repository.Save();
        }
    }
}
