using System;

namespace EventSourcing.Data.Events
{
    public interface IPersonCreated: IEvent
    {
        string FirstName { get; set; }
        Guid Id { get; set; }
        string LastName { get; set; }

        string ToString();
    }
}