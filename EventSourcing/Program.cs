using EventSourcing.BusinessLogic;
using EventSourcing.BusinessLogic.Commands;
using EventSourcing.BusinessLogic.Models.Events;
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

            new CreatePersonCommand("Lisa", "Pettersen", eventStore).Perform();

            Console.ReadKey();

            new CreatePersonCommand("Herman", "Andersen", eventStore).Perform();

            Console.ReadKey();

            new CreatePersonCommand("Hennie", "Andersen", eventStore).Perform();

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
