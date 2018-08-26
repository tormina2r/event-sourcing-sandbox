using System;

namespace EventSourcing.BusinessLogic.Models
{
    public class Person
    {
        public Person(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = LastName;
        }

        public Guid Id { get; } 
        public string FirstName { get; }
        public string LastName { get; }
    }
}
