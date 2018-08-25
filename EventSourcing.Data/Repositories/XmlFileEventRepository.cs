using EventSourcing.Data.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace EventSourcing
{
    public class XmlFileEventRepository : EventRepository
    {
        private readonly string _Path;
        private readonly EventCollection _EventCollection;

        public override IEnumerable<Event> Events => _EventCollection.Events;

        public XmlFileEventRepository(string path)
        {
            _Path = path;

            _EventCollection = GetEventCollectionFromFile(path);            
        }

        public override void Add(Event @event)
        {
            _EventCollection.Events.Add(@event);
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