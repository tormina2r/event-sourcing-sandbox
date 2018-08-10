namespace EventSourcing
{
    class AutoPersistEventStore : EventStore
    {
        private readonly EventRepository _Repository;

        public AutoPersistEventStore(EventRepository repository)
            :base(repository.Events)
        {
            _Repository = repository;
        }

        public override void AddEvent(Event @event)
        {
            base.AddEvent(@event);
            _Repository.Events.Add(@event);
            _Repository.Save();
        }
    }
}
