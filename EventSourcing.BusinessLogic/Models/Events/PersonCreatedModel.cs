namespace EventSourcing.BusinessLogic.Models.Events
{
    public class PersonCreatedModel : EventModel
    {
        public Person Person { get; set; }

        public override string ToString() => $"Person created: {Person.FirstName} {Person.LastName}";
    }
}