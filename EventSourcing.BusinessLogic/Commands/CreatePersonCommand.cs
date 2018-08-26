using EventSourcing.BusinessLogic.Models.Events;
using System;

namespace EventSourcing.BusinessLogic.Commands
{
    public class CreatePersonCommand : Command
    {
        private readonly EventStore _EventStore;

        public CreatePersonCommand(string firstName, string lastName, EventStore eventBroker)
        {
            FirstName = firstName;
            LastName = lastName;

            _EventStore = eventBroker;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public override void Perform() => _EventStore.AddEvent(new PersonCreatedModel { Person = new Models.Person(Guid.NewGuid(), FirstName, LastName) });
    }
}
