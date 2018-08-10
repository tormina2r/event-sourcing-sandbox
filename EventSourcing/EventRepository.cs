using System;
using System.Collections.Generic;

namespace EventSourcing
{
    internal class EventRepository
    {
        public EventRepository()
        {
        }

        public List<Event> Events { get; internal set; } = new List<Event>();

        internal void Save()
        {
            //TODO
        }
    }
}