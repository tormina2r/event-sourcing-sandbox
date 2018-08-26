namespace EventSourcing.BusinessLogic.Models.Events
{
    public class PersonCreatedModel : EventModel
    {
        public Person Person { get; set; }
    }
}