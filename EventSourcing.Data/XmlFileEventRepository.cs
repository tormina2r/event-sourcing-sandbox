using EventSourcing.Data.Xml;
using EventSourcing.Data.Xml.Events;
using EventSourcing.ServiceLayer.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace EventSourcing.Data.Repositories.Xml
{
    public class XmlFileEventRepository : IEventRepository
    {
        private readonly string _Path;
        private readonly EventCollection _EventCollection;

        public IEnumerable<IEvent> Events => _EventCollection.Events;

        public XmlFileEventRepository(string path = null)
        {
            _Path = path ?? GetExecutingPath();

            _EventCollection = GetEventCollectionFromFile(_Path);            
        }

        public void Add(IEvent @event)
        {
            _EventCollection.Events.Add((Event)@event);
        }

        public void Save()
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

        private string GetExecutingPath()
        {
            var location = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var directory = new FileInfo(location.AbsolutePath).Directory.FullName;

            return $"{directory}\\events.xml";
        }
    }
}