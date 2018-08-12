using System;

namespace EventSourcing.BusinessLogic.Events
{
    public abstract class Event
    {
        internal readonly EventType Type;
                
        public DateTime TimeStamp { get; } = DateTime.Now;
    }
}
