using System;
using System.Xml.Serialization;

namespace EventSourcing.Data.Events
{
    [XmlInclude(typeof(PersonCreated))]
    public abstract class Event
    {
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
