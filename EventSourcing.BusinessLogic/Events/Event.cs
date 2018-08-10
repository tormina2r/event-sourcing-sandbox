using System;

namespace EventSourcing.Events
{
    public abstract class Event
    {
        public abstract override string ToString();
        public DateTime TimeStamp { get; } = DateTime.Now;
    }
}
