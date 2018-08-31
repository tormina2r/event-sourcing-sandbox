using EventSourcing.ServiceLayer.Events;
using System;
using System.Xml.Serialization;

namespace EventSourcing.Data.Xml.Events
{
    [XmlInclude(typeof(PersonCreated))]
    public abstract class Event : IEvent
    {
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
