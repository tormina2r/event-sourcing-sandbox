using System;

namespace EventSourcing.BusinessLogic.Models.Events
{
    public abstract class EventModel
    {
        public EventModel(DateTime? timeStamp = null)
        {
            TimeStamp = timeStamp ?? DateTime.Now;
        }

        public DateTime TimeStamp { get; }

        public abstract override string ToString();
    }
}