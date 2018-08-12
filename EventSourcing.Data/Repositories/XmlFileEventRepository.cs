using System;
using System.Collections.Generic;

namespace EventSourcing
{
    public class XmlFileEventRepository : EventRepository
    {
        public override IEnumerable<EventEntity> Events => throw new NotImplementedException();

        public override void Add(EventType type, object value)
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}