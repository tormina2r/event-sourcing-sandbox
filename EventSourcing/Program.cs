using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventSourcing
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new EventRepository();
            var eventBroker = new EventBroker(repository);
            eventBroker.EventAdded += EventBroker_EventAdded;
            eventBroker.EventReplayed += EventBroker_EventReplayed;

            new CreatePersonCommand("Lisa", "Pettersen", eventBroker).Perform();

            Console.ReadKey();

            new CreatePersonCommand("Herman", "Andersen", eventBroker).Perform();

            Console.ReadKey();

            new CreatePersonCommand("Hennie", "Andersen", eventBroker).Perform();

            Console.WriteLine("All events in repository: ");
            foreach (var @event in repository.Events)
            {
                Console.WriteLine(@event.ToString());
            }

            Console.ReadKey();

            Console.WriteLine("Playing all events: ");
            
            eventBroker.ReplayAllEvents();

            Console.ReadKey();

            var timeStamp = repository.Events[1].TimeStamp;

            Console.WriteLine("PlayUpTo second event: ");

            eventBroker.PlayUpTo(timeStamp);

            Console.ReadKey();
        }

        private static void EventBroker_EventReplayed(object sender, Event e)
        {
            Console.WriteLine($"Event was replayed: {e}");
        }

        private static void EventBroker_EventAdded(object sender, Event e)
        {
            Console.WriteLine($"Event added to repository: {e}");
        }
    }

    class EventBroker
    {
        private readonly EventRepository _Repository;

        public EventBroker(EventRepository repository)
        {
            _Repository = repository;
        }

        internal void AddEvent(PersonCreated personCreated)
        {
            _Repository.Events.Add(personCreated);
            OnEventAdded(personCreated);
        }

        internal event EventHandler<Event> EventAdded;

        internal event EventHandler<Event> EventReplayed;

        private void OnEventAdded(Event @event)
        {
            var handler = EventAdded;
            if (handler != null)
            {
                handler.Invoke(this, @event);
            }
        }

        private void OnEventReplayed(Event @event)
        {
            var handler = EventReplayed;
            if (handler != null)
            {
                handler.Invoke(this, @event);
            }
        }

        internal void ReplayAllEvents()
        {
            Replay(_Repository.Events);
        }

        internal void PlayUpTo(DateTime timeStamp)
        {
            var events = _Repository.Events.Where(p => p.TimeStamp <= timeStamp);
            Replay(events);
        }

        private void Replay(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                OnEventReplayed(@event);
            }
        }
    }

    abstract class Command
    {
        public abstract void Perform();
    }

    class CreatePersonCommand: Command
    {
        private readonly EventBroker _EventBroker;

        public CreatePersonCommand(string firstName, string lastName, EventBroker eventBroker)
        {
            FirstName = firstName;
            LastName = lastName;

            _EventBroker = eventBroker;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public override void Perform()
        {
            var person = new Person { Id = Guid.NewGuid(), FirstName = FirstName, LastName = LastName };
            _EventBroker.AddEvent(new PersonCreated(person));
        }
    }

    internal class EventRepository
    {
        public List<Event> Events { get; } = new List<Event>();
    }

    internal abstract class Event
    {
        public abstract override string ToString();
        public DateTime TimeStamp { get; } = DateTime.Now;
    }

    internal class PersonCreated : Event
    {
        public PersonCreated(Person person)
        {
            Person = person;
        }

        public Person Person { get; }

        public override string ToString()
        {
            return $"{TimeStamp} {nameof(PersonCreated)}: {Person.FirstName} {Person.LastName} ({Person.Id})";
        }
    }

    class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
