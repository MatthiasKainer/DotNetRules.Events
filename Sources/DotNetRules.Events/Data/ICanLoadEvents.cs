namespace DotNetRules.Events.Data
{
    using System.Collections.Generic;

    public interface ICanLoadEvents
    {
        IEnumerable<BaseEvent> GetAllEvents();

        IEnumerable<TEvents> GetSpecificEventsFromStore<TEvents>() where TEvents : BaseEvent;

        IEnumerable<TEvents> GetEventsFromStoreByEntity<TEvents>() where TEvents : BaseEvent;
    }
}