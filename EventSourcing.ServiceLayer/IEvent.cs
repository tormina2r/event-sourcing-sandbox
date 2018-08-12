using System;

namespace EventSourcing.ServiceLayer
{
    public interface IEvent
    {
        DateTime TimeStamp { get; }
    }
}