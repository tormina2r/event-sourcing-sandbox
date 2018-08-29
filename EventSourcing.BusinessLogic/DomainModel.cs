using System;
using System.Collections.Generic;
using EventSourcing.BusinessLogic.Commands;
using EventSourcing.BusinessLogic.Models.Events;
using EventSourcing.Data.Repositories.Xml;

namespace EventSourcing.BusinessLogic
{
    public class DomainModel
    {
        private readonly EventStore _EventStore;

        public DomainModel()
        {
            _EventStore = new AutoPersistEventStore(new XmlFileEventRepository(), new EventModelFactory());
            _EventStore.EventAdded += _EventStore_EventAdded;
        }

        public event EventHandler EventAdded;

        public void AddPerson(string firstName, string lastName) => new CreatePersonCommand(firstName, lastName, _EventStore).Perform();

        public IEnumerable<EventModel> GetEventModels() => _EventStore.GetEventStream();

        private void _EventStore_EventAdded(object sender, EventModel model) => OnEventAdded(sender);

        private void OnEventAdded(object sender) => EventAdded?.Invoke(sender, EventArgs.Empty);
    }
}
