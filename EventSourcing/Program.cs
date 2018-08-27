using EventSourcing.BusinessLogic;
using EventSourcing.BusinessLogic.Models.Events;
using EventSourcing.Data.Repositories.Xml;
using System;

namespace EventSourcing
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new XmlFileEventRepository("c:\\temp\\events.xml");
            var eventModelFactory = new EventModelFactory();

            var eventStore = new AutoPersistEventStore(repository, eventModelFactory);
            eventStore.EventAdded += EventStore_EventAdded;

            Console.WriteLine("All events in repository: ");
            foreach (var @event in eventStore.GetEventStream())
            {
                Console.WriteLine(@event.ToString());
            }
            
            Console.ReadKey();
            repository.Save();
        }

        private static void EventStore_EventAdded(object sender, EventModel e)
        {
            Console.WriteLine($"Event added: {e}");
        }
    }
}
