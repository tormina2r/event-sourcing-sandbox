using EventSourcing.BusinessLogic.Models;

namespace EventSourcing.BusinessLogic.Events
{
    public class PersonCreated : Event
    {
        public PersonCreated(Person person)
        {
            Person = person;
        }

        public Person Person { get; }

        public override string ToString()
        {
            return $"{TimeStamp} {nameof(PersonCreated)}: {Person.FirstName} {Person.LastName} ({Person.Id})";
        }
    }
}
