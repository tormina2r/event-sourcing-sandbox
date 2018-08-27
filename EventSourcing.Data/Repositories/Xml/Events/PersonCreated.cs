using EventSourcing.Data.Events;
using System;

namespace EventSourcing.Data.Repositories.Xml.Events
{
    [Serializable]
    public class PersonCreated : Event, IPersonCreated
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{TimeStamp} {nameof(PersonCreated)}: {FirstName} {LastName} ({Id})";
        }
    }
}
