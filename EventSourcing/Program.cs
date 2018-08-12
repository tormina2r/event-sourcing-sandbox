using EventSourcing.BusinessLogic;
using EventSourcing.BusinessLogic.Commands;
using EventSourcing.BusinessLogic.Events;
using System;

namespace EventSourcing
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventStore = new AutoPersistEventStore(new XmlFileEventRepository());
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
        }

        private static void EventStore_EventAdded(object sender, Event e)
        {
            Console.WriteLine($"Event added: {e}");
        }
    }
}
