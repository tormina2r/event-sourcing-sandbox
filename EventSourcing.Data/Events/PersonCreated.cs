using System;

namespace EventSourcing.Data.Events
{
    [Serializable]
    public class PersonCreated : Event
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
