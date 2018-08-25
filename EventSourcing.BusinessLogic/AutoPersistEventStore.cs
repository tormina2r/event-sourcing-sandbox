using EventSourcing.Data.Events;
using System.Linq;

namespace EventSourcing.BusinessLogic
{
    public class AutoPersistEventStore : EventStore
    {
        private readonly EventRepository _Repository;

        public AutoPersistEventStore(EventRepository repository)
            :base(repository.Events.ToList())
        {
            _Repository = repository;
        }

        public override void AddEvent(Event @event)
        {
            base.AddEvent(@event);
            _Repository.Add(@event);
            _Repository.Save();
        }
    }
}
