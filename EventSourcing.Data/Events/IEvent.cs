using System;

namespace EventSourcing.Data.Events
{
    public interface IEvent
    {
        DateTime TimeStamp { get; set; }
    }
}