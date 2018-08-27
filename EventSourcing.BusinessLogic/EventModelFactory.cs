using System;
using EventSourcing.BusinessLogic.Models.Events;
using EventSourcing.Data.Events;
using EventSourcing.Data.Repositories.Xml.Events;

namespace EventSourcing.BusinessLogic
{
    public class EventModelFactory
    {
        public EventModel CreateModel(IEvent @event)
        {
            var personCreated = @event as IPersonCreated;
            if (personCreated != null)
                return new PersonCreatedModel
                {
                    Person = new Models.Person(personCreated.Id, personCreated.FirstName, personCreated.LastName),
                    TimeStamp = personCreated.TimeStamp                    
                };

            throw new InvalidOperationException($"Unknown event of type: {@event.GetType()}");
        }

        internal Event CreateEntity(EventModel model)
        {
            var personCreatedModel = model as PersonCreatedModel;
            if (personCreatedModel != null)
                return new PersonCreated
                {
                    Id = personCreatedModel.Person.Id,
                    FirstName = personCreatedModel.Person.FirstName,
                    LastName = personCreatedModel.Person.LastName,
                    TimeStamp = personCreatedModel.TimeStamp
                };

            throw new InvalidOperationException($"Unknown event of type: {model.GetType()}");
        }
    }
}