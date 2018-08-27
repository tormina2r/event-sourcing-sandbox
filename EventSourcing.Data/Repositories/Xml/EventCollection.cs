using EventSourcing.Data.Events;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EventSourcing.Data.Repositories.Xml
{
    [Serializable]
    [XmlRoot("EventCollection")]
    public class EventCollection
    {
        [XmlArray("Events")]
        [XmlArrayItem("Event", typeof(IEvent))]
        public List<IEvent> Events { get; } = new List<IEvent>();
    }
}