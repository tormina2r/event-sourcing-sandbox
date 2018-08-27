using EventSourcing.Data.Events;
using System;
using System.Xml.Serialization;

namespace EventSourcing.Data.Repositories.Xml.Events
{
    [XmlInclude(typeof(PersonCreated))]
    public abstract class Event : IEvent
    {
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
