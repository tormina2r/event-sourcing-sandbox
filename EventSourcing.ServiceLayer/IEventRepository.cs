using System.Collections.Generic;

namespace EventSourcing.ServiceLayer
{
    public interface IEventRepository
    {
        IEnumerable<IEvent> Events { get; }

        void Save();
    }
}
