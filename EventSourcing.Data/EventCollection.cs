using EventSourcing.Data.Xml.Events;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EventSourcing.Data.Xml
{
    [Serializable]
    [XmlRoot("EventCollection")]
    public class EventCollection
    {
        [XmlArray("Events")]
        [XmlArrayItem("Event", typeof(Event))]
        public List<Event> Events { get; } = new List<Event>();
    }
}