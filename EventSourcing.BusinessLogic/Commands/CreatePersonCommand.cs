using EventSourcing.BusinessLogic.Events;
using EventSourcing.BusinessLogic.Models;
using System;

namespace EventSourcing.BusinessLogic.Commands
{
    public class CreatePersonCommand : Command
    {
        private readonly EventStore _EventBroker;

        public CreatePersonCommand(string firstName, string lastName, EventStore eventBroker)
        {
            FirstName = firstName;
            LastName = lastName;

            _EventBroker = eventBroker;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public override void Perform()
        {
            var person = new Person { Id = Guid.NewGuid(), FirstName = FirstName, LastName = LastName };
            _EventBroker.AddEvent(new PersonCreated(person));
        }
    }
}
