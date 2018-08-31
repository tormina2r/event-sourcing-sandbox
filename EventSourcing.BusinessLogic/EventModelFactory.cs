using System;
using EventSourcing.BusinessLogic.Models.Events;
using EventSourcing.Data.Xml.Events;
using EventSourcing.ServiceLayer.Events;

namespace EventSourcing.BusinessLogic
{
    public class EventModelFactory
    {
        public EventModel CreateModel(IEvent @event)
        {
            if (@event is IPersonCreated personCreated)
                return new PersonCreatedModel(personCreated.Id, personCreated.FirstName, personCreated.LastName, personCreated.TimeStamp);

            throw new InvalidOperationException($"Unknown event of type: {@event.GetType()}");
        }

        internal Event CreateEntity(EventModel model)
        {
            if (model is PersonCreatedModel personCreatedModel)
                return new PersonCreated
                { 
                    Id = personCreatedModel.Id,
                    FirstName = personCreatedModel.FirstName,
                    LastName = personCreatedModel.LastName,
                    TimeStamp = personCreatedModel.TimeStamp
                };

            throw new InvalidOperationException($"Unknown event of type: {model.GetType()}");
        }
    }
}