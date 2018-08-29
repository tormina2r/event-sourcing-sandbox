using System;

namespace EventSourcing.BusinessLogic.Models.Events
{
    public class PersonCreatedModel : EventModel
    {
        public PersonCreatedModel(Guid id, string firstName, string lastName, DateTime? timeStamp = null)
            :base(timeStamp)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString() => $"Person created: {FirstName} {LastName}";
    }
}