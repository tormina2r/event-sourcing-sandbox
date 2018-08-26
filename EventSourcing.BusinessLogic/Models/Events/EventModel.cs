using System;

namespace EventSourcing.BusinessLogic.Models.Events
{
    public abstract class EventModel
    {
        public DateTime TimeStamp { get; set; }
    }
}