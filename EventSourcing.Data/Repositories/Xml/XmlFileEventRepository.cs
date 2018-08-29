using EventSourcing.Data.Events;
using EventSourcing.Data.Repositories.Xml.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace EventSourcing.Data.Repositories.Xml
{
    public class XmlFileEventRepository : EventRepository
    {
        private readonly string _Path;
        private readonly EventCollection _EventCollection;

        public override IEnumerable<IEvent> Events => _EventCollection.Events;

        public XmlFileEventRepository(string path)
        {
            _Path = path;

            _EventCollection = GetEventCollectionFromFile(path);            
        }

        public override void Add(IEvent @event)
        {
            _EventCollection.Events.Add((Event)@event);
        }

        public override void Save()
        {
            var directory = Path.GetDirectoryName(_Path);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using (var fileStream = File.Create(_Path))
            {
                var serializer = new XmlSerializer(typeof(EventCollection));
                serializer.Serialize(fileStream, _EventCollection);
            }
        }

        private EventCollection GetEventCollectionFromFile(string path)
        {
            var serializer = new XmlSerializer(typeof(EventCollection));

            if (!File.Exists(path))
                return new EventCollection();

            using (var fileStream = File.OpenRead(path))
            {
                try
                {
                    return (EventCollection)serializer.Deserialize(fileStream);
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                    throw;
                }
            }
        }
    }
}