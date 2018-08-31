using System;

namespace EventSourcing.ServiceLayer.Events
{
    public interface IEvent
    {
        DateTime TimeStamp { get; set; }
    }
}