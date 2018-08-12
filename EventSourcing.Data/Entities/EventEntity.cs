namespace EventSourcing
{
    public class EventEntity
    {
        public EventEntity(EventType type, object value)
        {
            Type = type;
            Value = value;
        }

        public EventType Type { get; }
        public object Value { get; }
    }
}